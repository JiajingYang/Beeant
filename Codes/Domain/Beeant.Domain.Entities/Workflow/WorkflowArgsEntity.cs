using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using Beeant.Domain.Entities.Account;
using Configuration;
using Winner;
using Winner.Filter;
using Winner.Persistence;

namespace Beeant.Domain.Entities.Workflow
{

    [Serializable]
    public class WorkflowArgsEntity
    {
        #region 输入参数

        /// <summary>
        /// 当前执行的任务
        /// </summary>
        public TaskEntity Task { get; set; }
        #endregion

        #region 当前获取的内容
        /// <summary>
        /// 当前执行的任务
        /// </summary>
        public TaskEntity DataTask { get; set; }
        /// <summary>
        /// 当前节点未完成任务
        /// </summary>
        public IList<TaskEntity> CurrentOtherTasks { get; set; }
        /// <summary>
        /// 错误信息
        /// </summary>
        public IList<ErrorInfo> Errors { get; set; }
        /// <summary>
        /// 引擎
        /// </summary>
        public WorkflowEngineEntity Engine { get; set; }

        private FlowEntity _flow;
        /// <summary>
        /// 当前工作流
        /// </summary>
        public FlowEntity Flow
        {
            get
            {
                if (_flow != null)
                    return _flow;
                var flowId = Engine.GetFlowIdByNodeIdHandle(NodeId);
                if (flowId==0 && Engine.GetFlowHandle == null)
                    return null;
                _flow = Engine.GetFlowHandle(flowId);
                return _flow;
            }
        }

        public long NodeId
        {
            get
            {
                return DataTask == null ? Task.GetVariable<long>("NodeId") : DataTask.GetVariable<long>("NodeId");
            }
        }
        
        private NodeEntity _node;
        /// <summary>
        /// 当前节点
        /// </summary>
        public NodeEntity Node
        {
            get
            {
                if (_node != null)
                    return _node;
                if (Flow == null || Flow.Nodes == null )
                    return null;
                _node = Flow.Nodes.FirstOrDefault(it => it.Id == NodeId);
                return _node;
            }
            set
            {
                _node = value;
            }
        }
     
    
        /// <summary>
        /// 添加错误信息
        /// </summary>
        public virtual void AddError(ErrorInfo error)
        {
            Errors = Errors ?? new List<ErrorInfo>();
            Errors.Add(error);
        }

        /// <summary>
        /// 添加错误信息
        /// </summary>
        /// <param name="propertyName"></param>
        /// <param name="paramters"></param>
        public virtual void AddError(string propertyName, params object[] paramters)
        {
            Errors = Errors ?? new List<ErrorInfo>();
            var error = Creator.Get<IValidation>().GetErrorInfo(GetType().FullName, propertyName);
            error.Message = string.Format(error.Message, paramters);
            Errors.Add(error);
        }

        /// <summary>
        /// 添加错误信息
        /// </summary>
        /// <param name="name"></param>
        /// <param name="propertyName"></param>
        /// <param name="paramters"></param>
        public virtual void AddErrorByName(string name, string propertyName, params object[] paramters)
        {
            Errors = Errors ?? new List<ErrorInfo>();
            var error = Creator.Get<IValidation>().GetErrorInfo(name, propertyName);
            error.Message = string.Format(error.Message, paramters);
            Errors.Add(error);
        }

        /// <summary>
        /// 验证是否通过
        /// </summary>
        public virtual bool IsValidate
        {
            get { return Errors == null || Errors.Count == 0; }
        }

        #endregion

        #region 创建流程
        /// <summary>
        /// 生成流程
        /// </summary>
        public virtual void Create()
        {
      
            if (Flow == null || Flow.Nodes == null || Task==null || Task.Consumer == null || Node==null)
                return;
            if (Task.SaveType!=SaveType.Add)
            {
                var taskStatus = CheckTask();
                if(taskStatus== TaskStatusType.Waiting)
                    return;
                var nodes = GetNextNodes(Node,taskStatus == TaskStatusType.Passed);
                Task.NextTasks=new List<TaskEntity>();
                foreach (var node in nodes)
                {
                    var task = new TaskEntity
                    {
                        Account = new AccountEntity {Id = node.GetTaskAccountId()},
                        Channel = Task.Channel,
                        OverTime = DateTime.Now.AddMinutes(node.Timeout),
                        Level = Task.Level,
                        Consumer = Task.Consumer,
                        Status = TaskStatusType.Waiting,
                        Type = node.NodeType == NodeType.Any ? TaskType.Any : TaskType.All,
                        Remark = Task.Remark,
                        PreviousKey = "",
                        NextKey = "",
                        SaveType = SaveType.Add
                    };
                    task.SetVariable("NodeId",node.Id);
                    CreateMessage(node, task);
                    Task.NextTasks.Add(task);
                }
                Task.Consumer.Tasks = new List<TaskEntity>{ Task };
                SetEntityStatus(nodes);
            }
            else
            {
                CreateMessage(Node,Task);
            }
        }
        #region 得到消息
        /// <summary>
        /// 创建消息
        /// </summary>
        /// <param name="node"></param>
        /// <param name="task"></param>
        protected virtual void CreateMessage(NodeEntity node,TaskEntity task)
        {
            if(node.NodeMessages==null || node.NodeMessages.Count==0)
                return;
 
            task.Messages = task.Messages ?? new List<MessageEntity> ();
            foreach (var nodeMessage in node.NodeMessages)
            {
                var url = ConfigurationManager.GetSetting<string>(nodeMessage.Url);
                url = string.IsNullOrWhiteSpace(url) ? nodeMessage.Url : url;
                var message = new MessageEntity
                {
                    Task = task,
                    Type = MessageType.Default,
                    Title = nodeMessage.Title,
                    Detail = nodeMessage.Detail,
                    Url = url,
                    SaveType = SaveType.Add
                };
                task.Messages.Add(message);
            }
        }
        #endregion

        /// <summary>
        /// 确定是否生成
        /// </summary>
        /// <returns></returns>
        protected virtual TaskStatusType CheckTask()
        {
            if (CurrentOtherTasks == null || CurrentOtherTasks.Count==0 || DataTask==null)
                return Task.Status;
            if (DataTask.Type == TaskType.Any)
            {
                if (Task.Status == TaskStatusType.Passed)
                    return TaskStatusType.Passed;
              return  TaskStatusType.Waiting;
            }
            if (DataTask.Type == TaskType.All)
            {
                if (Task.Status == TaskStatusType.Rejected)
                    return TaskStatusType.Rejected;
                return TaskStatusType.Waiting;
            }
            return Task.Status;
        }


        /// <summary>
        /// 得到下一个节点
        /// </summary>
        /// <returns></returns>
        protected virtual IList<NodeEntity> GetNextNodes(NodeEntity currentNode,bool isPass)
        {
            if (currentNode == null)
                return null;
            var nodes = new List<NodeEntity>();
            var name = isPass ? currentNode.PassName : currentNode.RejectName;
            foreach (var node in Flow.Nodes.Where(it => it.Name == name))
            {
                if (CheckNodeCondition(node))
                {
                    switch (node.ConditionType)
                    {
                        case ConditionType.Create:
                            nodes.Add(node);
                            break;
                        case ConditionType.UnCreate:
                            break;
                        case ConditionType.Skip:
                            return GetNextNodes(Flow.Nodes.FirstOrDefault(it => it.PassName == currentNode.PassName), isPass);
                    }

                }
            }
            return nodes;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        protected virtual bool CheckNodeCondition(NodeEntity node)
        {
            if (node == null || node.Conditions == null || node.Conditions.Count == 0)
                return true;
            if (node.ConditionDelegate != null)
                return node.ConditionDelegate(this);
            var infos = new List<object> { Task.Consumer as object };
            foreach (var condition in node.Conditions)
            {
                if (string.IsNullOrEmpty(condition.InspectExp))
                    continue;
                if (!infos.AsQueryable().Where(condition.InspectExp, condition.ArgumentArray).Any())
                {
                    return false;
                }
            }
            return true;
        }

        #endregion
        #region 设置状态
        /// <summary>
        /// 设置业务状态
        /// </summary>
        protected virtual void SetEntityStatus(IList<NodeEntity> nextNodes)
        {
            var entity = Task.Consumer as BaseEntity;
            foreach (var nextNode in nextNodes)
            {
                if (string.IsNullOrEmpty(nextNode.StatusName) || string.IsNullOrWhiteSpace(nextNode.StatusValue))
                    continue;
                Creator.Get<Winner.Base.IProperty>()
                    .SetValue(entity, nextNode.StatusName, nextNode.StatusValue);
                if (entity.SaveType == SaveType.None)
                {
                    entity.SaveType = SaveType.Modify;
                    entity.SetProperty(nextNode.StatusName);
                }
                else if (entity.SaveType == SaveType.Modify && entity.Properties != null)
                {
                    entity.SetProperty(nextNode.StatusName);
                }
            }
        }
        #endregion

    }
    [Serializable]
    public class WorkflowEngineEntity
    {

     
        /// <summary>
        /// 得到组委托
        /// </summary>
        public Func<long, FlowEntity> GetFlowHandle { get; set; }
        /// <summary>
        /// 得到组委托
        /// </summary>
        public Func<long, long> GetFlowIdByNodeIdHandle { get; set; }

    }
}
