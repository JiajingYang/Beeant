using System.Collections.Generic;
using System.Linq;
using Beeant.Domain.Entities.Account;
using Beeant.Domain.Entities.Workflow;
using Component.Extension;
using Winner.Filter;
using Winner.Persistence;
using Winner.Persistence.Linq;

namespace Beeant.Domain.Services.Workflow
{
    public class TaskDomainService : RealizeDomainService<TaskEntity>
    {

        #region 业务

        /// <summary>
        /// 订单审批
        /// </summary>
        public IDomainService ConsumerDomainService { get; set; }

        private IDictionary<string, IUnitofworkHandle> _itemHandles;
        /// <summary>
        /// 处理
        /// </summary>
        protected override IDictionary<string, IUnitofworkHandle> ItemHandles
        {
            get
            {
                return _itemHandles ?? (_itemHandles = new Dictionary<string, IUnitofworkHandle>
                {
                    {"Tasks", new UnitofworkHandle<TaskEntity>{DomainService= this}}
                });
            }
            set
            {
                base.ItemHandles = value;
            }
        }

        /// <summary>
        /// 处理业务
        /// </summary>
        /// <param name="unitofworks"></param>
        /// <param name="info"></param>
        /// <returns></returns>
        protected override bool SetBusiness(IList<IUnitofwork> unitofworks, TaskEntity info)
        {
            var rev= base.SetBusiness(unitofworks, info);
            if (rev)
            {
                var tab = info.Consumer as ITaskTab;
                if (tab == null)
                    return false;
                tab.Tasks = new List<TaskEntity> {info};
                tab.Tasks.AddList(info.Tasks);
                var units = ConsumerDomainService.Handle(info.Consumer);
                if (units == null)
                {
                    info.Errors = info.Errors ?? new List<ErrorInfo>();
                    info.Errors.AddList(info.Consumer.Errors);
                    rev = false;
                }
            }
            return rev;
        }

        #region 添加验证
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        protected override bool ValidateAdd(TaskEntity info)
        {
            return ValidateAccount(info) && ValidateTask(info); 
        }
   
  

        /// <summary>
        /// 验证订单
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        protected virtual bool ValidateAccount(TaskEntity info)
        {
            if (!info.HasSaveProperty(it => it.Account.Id) || info.Account.Id==0)
                return true;
            if (info.Account != null && info.Account.SaveType == SaveType.Add)
                return true;
            if (info.Account != null && info.Account.Id != 0)
            {
                if (Repository.Get<AccountEntity>(info.Account.Id) != null)
                    return true;
            }
            info.AddErrorByName(typeof(AccountEntity).FullName, "NoExist");
            return false;
        }
        /// <summary>
        /// 验证订单
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        protected virtual bool ValidateTask(TaskEntity info)
        {
            var query=new QueryInfo();
            query.Query<TaskEntity>()
                .Where(it => it.Number == info.Number && it.Account.Id==info.Account.Id && it.Status == TaskStatusType.Waiting)
                .Select(it => it.Id);
            var infos = Repository.GetEntities<TaskEntity>(query);
            if (infos != null && infos.Count > 0)
            {
                info.AddErrorByName(typeof(TaskEntity).FullName, "TaskWaiting");
                return false;
            }
            return true;
        }

        #endregion


        #endregion


    }
}

