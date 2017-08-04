using System;
using System.Collections.Generic;
using Component.Extension;
using Beeant.Domain.Entities.Workflow;
using Beeant.Domain.Services;
using Beeant.Domain.Services.Utility;
using Winner.Filter;
using Winner.Persistence;
using System.Linq;
using System.Text;
using System.Web;
using Beeant.Application.Services.Sys;
using Beeant.Domain.Entities;
using Winner.Persistence.Linq;

namespace Beeant.Application.Services.Workflow
{
    public class WorkflowEngineApplicationService : MarshalByRefObject, IWorkflowEngineApplicationService,IEventApplicationService
    {
   
 
       
        /// <summary>
        /// 存储实例
        /// </summary>
        public virtual IRepository Repository { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ICacheRepository CacheRepository { get; set; }
        /// <summary>
        /// 服务领域
        /// </summary>
        public IDictionary<long,IDomainService> DomainServices { get; set; }
 
        /// <summary>
        /// 处理工作流
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public virtual bool Handle(WorkflowArgsEntity args)
        {
            if (args.Task == null)
                return false;
            FillDataTask(args);
            FillCurrentOtherTasks(args);
            var entity = args.Task.Consumer as BaseEntity;
            entity = entity.Id == 0 ? entity : GetEntityByConditions(args);
            args.Task.Consumer = entity as ITaskTab;
           var unitofworks = GetHandleUnitofworks(args);
            if (unitofworks == null)
                return false;
            var rev = Winner.Creator.Get<IContext>().Commit(unitofworks);
            if (rev)
            {
                args.Task.SendMessage();
            }
            return rev;
        }
        /// <summary>
        /// 得到对象
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        protected virtual BaseEntity GetEntityByConditions(WorkflowArgsEntity args)
        {
            var entity = args.Task.Consumer as BaseEntity;
            var query = new QueryInfo();
            var select = new StringBuilder();
            select.Append("*");
            if (args.Node.Conditions != null)
            {
                foreach (var condition in args.Node.Conditions.Where(condition => condition.SelectExpArray != null))
                {
                    @select.Append(",");
                    @select.Append(condition.SelectExp);
                }
            }
            var entityName = string.Format("{0},{1}", entity.GetType().FullName,
                entity.GetType().Module.ToString().Replace(".dll", ""));
            query.Select(select.ToString()).Where("Id==@Id").From(entityName)
                .SetParameter("Id", entity.Id);
            return Repository.GetEntities<BaseEntity>(query).FirstOrDefault();
        }

        /// <summary>
        /// 得到添加Untiofwork
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public virtual IList<IUnitofwork> GetHandleUnitofworks(WorkflowArgsEntity args)
        {
            if (args == null)
                return null;
            args.Engine = GetWorkflowEngineEntity();
            var domainService = DomainServices.ContainsKey(args.Flow.Id) ? DomainServices[args.Flow.Id] : null;
            if (domainService == null) return null;
            var entity = args.Task.Consumer as BaseEntity;
            var unitofworks = domainService.Handle(entity);
            if (unitofworks == null)
            {
                args.Errors = args.Errors ?? new List<ErrorInfo>();
                args.Errors.AddList(entity.Errors);
                return null;
            }
            return unitofworks;
        }
        /// <summary>
        /// 填充任务
        /// </summary>
        /// <param name="args"></param>
        protected virtual void FillDataTask(WorkflowArgsEntity args)
        {
            if(args.Task.SaveType==SaveType.Add)
                return;
            args.DataTask = Repository.Get<TaskEntity>(args.Task.Id);
        }
        /// <summary>
        /// 填充任务
        /// </summary>
        /// <param name="args"></param>
        protected virtual void FillCurrentOtherTasks(WorkflowArgsEntity args)
        {
            if (args.DataTask==null)
                return;
            var query=new QueryInfo();
            query.Query<TaskEntity>()
                .Where(it => it.Key == args.DataTask.Key && it.Status == TaskStatusType.Waiting)
                .Select(it => new object[] {it.Id,it.Status });
            args.CurrentOtherTasks = Repository.GetEntities<TaskEntity>(query);
        }


        #region 得到工作流
        /// <summary>
        /// 得到工作流
        /// </summary>
        /// <returns></returns>
        public virtual WorkflowArgsEntity GetWorkflowArgs() 
        {
            var workflowArgs = new WorkflowArgsEntity
            {
                Engine = GetWorkflowEngineEntity()
            };
            return workflowArgs;
        }
        /// <summary>
        /// 缓存锁
        /// </summary>

        private static object CacheLocker = new object();
        /// <summary>
        /// 得到缓存值
        /// </summary>

        private static string CacheKey = "WorkflowEngineArgs";
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected virtual WorkflowEngineEntity GetWorkflowEngineEntity()
        {
            var engine = CacheRepository.Get<WorkflowEngineEntity>(CacheKey);
            if (engine == null)
            {
                lock (CacheLocker)
                {
                    engine = CacheRepository.Get<WorkflowEngineEntity>(CacheKey);
                    if (engine == null)
                    {
                        engine = SetArgsCache();
                    }
                }
            }
            return engine;

        }
        /// <summary>
        /// 设置缓存
        /// </summary>
        /// <returns></returns>
        protected virtual WorkflowEngineEntity SetArgsCache()
        {
            var args = new WorkflowEngineEntity();
            args.GetFlowHandle = GetFlow;
            args.GetFlowIdByNodeIdHandle = GetFlowIdByNodeId;
            CacheRepository.Set(CacheKey, args, DateTime.MaxValue);
            return args;
        }

        
 

        #region 工作流

        /// <summary>
        /// 得到缓存值
        /// </summary>

        private static string FlowCacheKey = "WorkflowEngineFlow";
        /// <summary>
        /// 得到缓存值
        /// </summary>
        /// <returns></returns>
        protected virtual string GetFlowCacheKey(long id)
        {
            return string.Format("{0}{1}", FlowCacheKey, id);
        }

        /// <summary>
        /// 得到角色
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        protected virtual FlowEntity GetFlow(long id)
        {
            var key = GetFlowCacheKey(id);
            var value = CacheRepository.Get<FlowEntity>(key);
            if (value == null)
            {
                var query = new QueryInfo();
                query.Query<FlowEntity>()
                    .Select(
                        it => new object[]
                        {
                        it,
                        it.Nodes.Select(s =>new object[] {s,s.NodeAccounts.Select(n=>n),s.Conditions.Select(n=>n)}),
                        });
                value = Repository.GetEntities<FlowEntity>(query)?.FirstOrDefault();
                CacheRepository.Set(key, value, DateTime.MaxValue);
            }
            CreateArgsService(value);
            return value;
        }
        private static object DomainServiceLocker=new object();

        /// <summary>
        /// 生成
        /// </summary>
        /// <param name="flow"></param>
        protected virtual void CreateArgsService(FlowEntity flow)
        {
            lock (DomainServiceLocker)
            {
                if (flow == null)
                    return;
                var domainService = CreateDomainService(flow);
                if (flow.Nodes == null)
                    return;
                foreach (var node in flow.Nodes)
                {
                    SetNodeDelegate(node, domainService);
                }
                if (DomainServices.ContainsKey(flow.Id))
                    DomainServices.Remove(flow.Id);
                DomainServices.Add(flow.Id, domainService);
            }
        
        }
        /// <summary>
        /// 得到缓存值
        /// </summary>

        private static string NodeCacheKey = "WorkflowEngineNode";
        /// <summary>
        /// 得到缓存值
        /// </summary>
        /// <returns></returns>
        protected virtual string GetNodeCacheKey(long id)
        {
            return string.Format("{0}{1}", NodeCacheKey, id);
        }
        /// <summary>
        /// 得到角色
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        protected virtual long GetFlowIdByNodeId(long id)
        {
            var key = GetNodeCacheKey(id);
            var value = CacheRepository.Get<string>(key);
            if (value == null)
            {
                var query = new QueryInfo();
                query.Query<NodeEntity>()
                    .Select(it => it.Flow.Id);
                var flowId = Repository.GetEntities<NodeEntity>(query)?.FirstOrDefault()?.Flow?.Id;
                if (flowId.HasValue)
                {
                    CacheRepository.Set(key, flowId, DateTime.MaxValue);
                    value = flowId.ToString();
                }
                   
            }
            return value.Convert<long>();
        }
        #endregion




        /// <summary>
        /// 添加服务
        /// </summary>
        /// <param name="flow"></param>
        protected virtual IDomainService CreateDomainService(FlowEntity flow)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(flow.ClassName)) return null;
                var t = Type.GetType(flow.ClassName);
                if (t == null) return null;
                return Activator.CreateInstance(t) as IDomainService;
            }
            catch (Exception ex)
            {
                Winner.Creator.Get<Winner.Log.ILog>().AddException(ex);
            }
            return null;
        }

        /// <summary>
        /// 设置节点委托
        /// </summary>
        /// <param name="node"></param>
        /// <param name="domainService"></param>
        protected virtual void SetNodeDelegate(NodeEntity node,IDomainService domainService)
        {
            try
            {
                if(!string.IsNullOrEmpty(node.ConditionMethod))
                    node.ConditionDelegate = (DelegateNodeMethod)Delegate.CreateDelegate(typeof(DelegateNodeMethod), domainService, node.ConditionMethod);
                if (!string.IsNullOrEmpty(node.BeforeMethod))
                    node.BeforeDelegate = (DelegateNodeMethod)Delegate.CreateDelegate(typeof(DelegateNodeMethod), domainService, node.BeforeMethod);
                if (!string.IsNullOrEmpty(node.AfterMethod))
                    node.AfterDelegate = (DelegateNodeMethod)Delegate.CreateDelegate(typeof(DelegateNodeMethod), domainService, node.AfterMethod);
            }
            catch (Exception ex)
            {
                Winner.Creator.Get<Winner.Log.ILog>().AddException(ex);
            }

        }

        #endregion

        #region 执行事件

        /// <summary>
        /// 执行
        /// </summary>
        /// <param name="url"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public virtual bool Execute(string url, string name)
        {
            switch (name)
            {
                case "ClearWorkflowCache":
                    ClearWorkflowCache(url);
                    break;
            }
            return true;
        }
        /// <summary>
        /// 清除缓存
        /// </summary>
        protected virtual void ClearWorkflowCache(string url)
        {
            var flowid = HttpUtility.ParseQueryString(url).Get("flowid");
            var key = GetFlowCacheKey(flowid.Convert<long>());
            CacheRepository.Remove(key);
        }
        
        #endregion
    }
}
