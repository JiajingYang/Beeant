using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Beeant.Domain.Entities.Account;
using Winner.Persistence;

namespace Beeant.Domain.Entities.Workflow
{
    public interface ITaskTab
    {
        /// <summary>
        /// 订单任务
        /// </summary>
        IList<TaskEntity> Tasks { get; set; }
        /// <summary>
        /// 设置任务
        /// </summary>
        /// <param name="task"></param>
        /// <returns></returns>
        bool HandleTask(TaskEntity task);

    }
    [Serializable]
    public enum TaskType
    {
        /// <summary>
        /// 所以通过
        /// </summary>
        All = 1,
        /// <summary>
        /// 任意
        /// </summary>
        Any = 2
    }

    [Serializable]
    public enum TaskStatusType
    {
        /// <summary>
        /// 创建
        /// </summary>
        Created = 1,
        /// <summary>
        /// 可以操作
        /// </summary>
        Waiting = 2,
        /// <summary>
        /// 通过
        /// </summary>
        Passed = 3,
        /// <summary>
        /// 拒绝
        /// </summary>
        Rejected = 4,
        /// <summary>
        /// 关闭
        /// </summary>
        Closed = 5
    }
    [Serializable]
    public class TaskEntity : BaseEntity<TaskEntity>
    {
        
        /// <summary>
        /// 用户
        /// </summary>
        public AccountEntity Account { get; set; }
        /// <summary>
        /// 标签
        /// </summary>
        public string Tag { get; set; }
        /// <summary>
        /// 级别
        /// </summary>
        public string Level { get; set; }
        /// <summary>
        /// 数据
        /// </summary>
        public string Number { get; set; }
        /// <summary>
        /// 当前任务
        /// </summary>
        public string Key { get; set; }
        /// <summary>
        /// 上一个审核任务
        /// </summary>
        public string PreviousKey { get; set; }
        /// <summary>
        /// 下一个审核任务
        /// </summary>
        public string NextKey { get; set; }
        /// <summary>
        /// 超时时间
        /// </summary>
        public DateTime OverTime { get; set; }
        /// <summary>
        /// 是否处理
        /// </summary>
        public TaskStatusType Status { get; set; }
        /// <summary>
        /// 类型
        /// </summary>
        public TaskType Type { get; set; }
        /// <summary>
        /// 渠道
        /// </summary>
        public string Channel { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 原数据
        /// </summary>
        public TaskEntity DataEntity { get; set; }
        /// <summary>
        /// 新任务
        /// </summary>
        public IList<TaskEntity> NextTasks { get; set; }
        /// <summary>
        /// 新任务
        /// </summary>
        public IList<TaskEntity> Tasks { get; set; }
        /// <summary>
        /// 处理实体
        /// </summary>
        public ITaskTab Consumer { get; set; }
        /// <summary>
        ///  消息
        /// </summary>
        public IList<MessageEntity> Messages { get; set; }
        /// <summary>
        /// 历史记录
        /// </summary>
        public HistoryEntity History { get; set; }
        /// <summary>
        /// 添加
        /// </summary>
        protected override void SetAddBusiness()
        {
            Key = Key ?? Guid.NewGuid().ToString().Replace("-", "");
            if (NextTasks != null)
            {
                NextKey = Guid.NewGuid().ToString().Replace("-", "");
                foreach (var task in NextTasks)
                {
                    task.Status = TaskStatusType.Created;
                    task.Key = NextKey;
                    task.PreviousKey = Key;
                }
            }
            
        }
        /// <summary>
        /// 加载任务
        /// </summary>
        protected override void SetModifyBusiness()
        {
            if(HasSaveProperty(it=>it.Status))
                return;
            if (Status != TaskStatusType.Rejected && Status != TaskStatusType.Passed)
                return;
            InvokeItemLoader("Tasks");
            if (DataEntity == null)
                return;
            var nextKey= string.IsNullOrWhiteSpace(DataEntity.NextKey)? Guid.NewGuid().ToString().Replace("-", ""): DataEntity.NextKey;
            var currentTasks = Tasks.Where(it => it.Key == DataEntity.Key).ToList();
            var nextTasks = Tasks.Where(it => it.Key == DataEntity.NextKey).ToList();
            foreach (var task in currentTasks)
            {
                if (Status == TaskStatusType.Passed && task.Type == TaskType.Any ||Status == TaskStatusType.Rejected && task.Type == TaskType.All)
                {
                    task.Status = TaskStatusType.Closed;
                    task.SaveType = SaveType.Modify;
                    task.SetProperty(it => it.Status);
                }
            }
            var nextTaskStatus =
                currentTasks.All(it => it.Status == TaskStatusType.Closed) && Status == TaskStatusType.Passed
                    ? TaskStatusType.Waiting
                    : TaskStatusType.Created;
            if (nextTaskStatus== TaskStatusType.Waiting)
            {
                foreach (var task in nextTasks)
                {
                    task.Status = TaskStatusType.Waiting;
                    task.SaveType = SaveType.Modify;
                    task.SetProperty(it => it.Status);
                }
            }
            if (NextTasks != null)
            {
                foreach (var task in NextTasks)
                {
                    task.Key = nextKey;
                    task.Status = nextTaskStatus;
                    task.PreviousKey = Key;
                }
            }
            History = new HistoryEntity
            {
                Account = Account ?? DataEntity.Account,
                OverTime = DataEntity.OverTime,
                Number = DataEntity.Number,
                Level=DataEntity.Level,
                Channel = Channel,
                Status = Status,
                Remark = Remark,
                SaveType = SaveType.Add
            };
        }

  
        /// <summary>
        /// 签名Url
        /// </summary>
        /// <param name="url"></param>
        public virtual string SignUrl(string url)
        {
            if (string.IsNullOrWhiteSpace(url))
                return "";
            var timespan = DateTime.Now.Ticks.ToString();
            var mark = Winner.Creator.Get<Winner.Base.ISecurity>().EncryptSign(timespan);
            url = string.Format("{0}?taskId={1}&accountid={2}&timespan={3}&mark={4}", url, Id, Account?.Id, timespan, mark);
            return url;
        }
        /// <summary>
        /// 得到消息
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public virtual bool CheckSign(string url)
        {
            var timespan = HttpUtility.ParseQueryString(url).Get("timespan");
            var mark = HttpUtility.ParseQueryString(url).Get("mark");
            if (string.IsNullOrEmpty(mark) || string.IsNullOrEmpty(timespan))
                return false;
            var mk = Winner.Creator.Get<Winner.Base.ISecurity>().EncryptSign(timespan);
            if (mark.ToLower() == mk.ToLower())
                return false;
            return true;
        }

        public Action<TaskEntity> SendMessageHandle { get; set; }
        /// <summary>
        /// 发送消息
        /// </summary>
        public virtual void SendMessage()
        {
            SendMessage(this);
        }
        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="task"></param>
        protected virtual void SendMessage(TaskEntity task)
        {
            if (task.SendMessageHandle != null)
            {
                task.SendMessageHandle.BeginInvoke(this, null, null);
            }
            if (task.NextTasks != null)
            {
                foreach (var nextTask in task.NextTasks)
                {
                    SendMessage(nextTask);
                }
            }
            if (task.Tasks != null)
            {
                foreach (var currentTask in task.Tasks)
                {
                    SendMessage(currentTask);
                }
            }
        }
    }
}
