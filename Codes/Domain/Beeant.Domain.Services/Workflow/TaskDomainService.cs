using System.Collections.Generic;
using System.Linq;
using Beeant.Domain.Entities;
using Beeant.Domain.Entities.Account;
using Beeant.Domain.Entities.Utility;
using Beeant.Domain.Entities.Workflow;
using Beeant.Domain.Services.Utility;
using Component.Extension;
using Winner.Filter;
using Winner.Mail;
using Winner.Persistence;
using Winner.Persistence.Linq;

namespace Beeant.Domain.Services.Workflow
{
    public class TaskDomainService : RealizeDomainService<TaskEntity>
    {

        #region 业务
        /// <summary>
        /// 邮件
        /// </summary>
        public IEmailRepository EmailRepository { get; set; }
        /// <summary>
        /// 短信
        /// </summary>
        public IMobileRepository MobileRepository { get; set; }
        /// <summary>
        /// 队列
        /// </summary>
        public IQueueRepository QueueRepository { get; set; }

        /// <summary>
        /// 消息
        /// </summary>
        public IDomainService MessageDomainService { get; set; }

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
                    {"NextTasks", new UnitofworkHandle<TaskEntity>{DomainService= this}},
                    {"Tasks", new UnitofworkHandle<TaskEntity>{Repository= Repository}},
                    {"History", new UnitofworkHandle<HistoryEntity>{Repository= Repository}}
                });
            }
            set
            {
                base.ItemHandles = value;
            }
        }

        private IDictionary<string, ItemLoader<TaskEntity>> _itemLoaders;
        /// <summary>
        /// 处理
        /// </summary>
        protected override IDictionary<string, ItemLoader<TaskEntity>> ItemLoaders
        {
            get
            {
                return _itemLoaders ?? (_itemLoaders = new Dictionary<string, ItemLoader<TaskEntity>>
                {
                    {"DataEntity", LoadDataEntity},
                    {"Tasks", LoadTasks}
                });
            }
            set
            {
                base.ItemLoaders = value;
            }
        }
        /// <summary>
        /// 加载原始数据
        /// </summary>
        /// <param name="info"></param>
        protected virtual void LoadDataEntity(TaskEntity info)
        {
            if (info.SaveType == SaveType.Add || info.DataEntity!=null) return;
            info.DataEntity = Repository.Get<TaskEntity>(info.Id);
        }
        /// <summary>
        /// 填充订单明细
        /// </summary>
        /// <param name="info"></param>
        protected virtual void LoadTasks(TaskEntity info)
        {
            if (info.SaveType == SaveType.Add) return;
            LoadDataEntity(info);
            if (info.DataEntity == null)
                return;
            var query = new QueryInfo();
            query.Query<TaskEntity>()
                .Where(it => (it.Key == info.DataEntity.Key || it.Key== info.DataEntity.NextKey)
                && (it.Status== TaskStatusType.Waiting || it.Status== TaskStatusType.Created))
                .Select(it=>new object[]{it.Id,it.Key,it.Status,it.NextKey,it.Type});
            info.Tasks = Repository.GetEntities<TaskEntity>(query);
        }

        /// <summary>
        /// 处理业务
        /// </summary>
        /// <param name="unitofworks"></param>
        /// <param name="info"></param>
        /// <returns></returns>
        protected override bool SetBusiness(IList<IUnitofwork> unitofworks, TaskEntity info)
        {
            var rev = base.SetBusiness(unitofworks, info) && HandleConsumer(unitofworks, info) &&
                      HandleMessages(unitofworks, info);
            return rev;
        }

        /// <summary>
        /// 处理
        /// </summary>
        /// <param name="unitofworks"></param>
        /// <param name="info"></param>
        /// <returns></returns>
        protected virtual bool HandleConsumer(IList<IUnitofwork> unitofworks, TaskEntity info)
        {
            var rev = info.Consumer.HandleTask(info);
            return rev;
        }

        /// <summary>
        /// 处理
        /// </summary>
        /// <param name="unitofworks"></param>
        /// <param name="info"></param>
        /// <returns></returns>
        protected virtual bool HandleMessages(IList<IUnitofwork> unitofworks, TaskEntity info)
        {
            if (info.Messages == null)
                return true;
            foreach (var message in info.Messages)
            {
                message.Task = info;
                message.Url = info.SignUrl(message.Url, message.Type.ToString());
            }
            IList<MessageEntity> messages = info.Messages.Where(it => it.SaveType == SaveType.Add).ToList();
            var units = MessageDomainService.Handle(messages);
            if (units == null)
            {
                info.Errors = info.Errors ?? new List<ErrorInfo>();
                foreach (var message in messages)
                {
                    info.Errors.AddList(message.Errors);
                }
                return false;
            }
            unitofworks.AddList(units);
            info.SendMessageHandle = SendMessage;
            return true;
        }
        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="info"></param>
        protected virtual void SendMessage(TaskEntity info)
        {
            if (info.Messages == null || info.Messages.Count == 0)
                return;
            foreach (var message in info.Messages)
            {
                switch (message.Type)
                {
                    case MessageType.Default:
                        SendDefaultMesssage(message);
                        break;
                    case MessageType.Email:
                       SendEmailMesssage(message);
                        break;
                    case MessageType.Mobile:
                        SendMobileMesssage(message);
                        break;
                }
            }
        }
        /// <summary>
        /// 发送系统消息
        /// </summary>
        /// <param name="message"></param>
        protected virtual void SendDefaultMesssage(MessageEntity message)
        {
            var detail = message.Detail.Replace("【Remark】", message.Task.Remark).Replace("【Url】", message.Url);
            var name = MessageEntity.GetMessageTag(message.Task.Account.Id);
            QueueRepository.Open(name, 5);
            QueueRepository.Push(name, detail);
        }

        /// <summary>
        /// 发送邮件
        /// </summary>
        /// <param name="message"></param>
        protected virtual void SendEmailMesssage(MessageEntity message)
        {
            var account = Repository.Get<AccountEntity>(message.Task.Account.Id);
            if (account == null || string.IsNullOrEmpty(account.Email))
                return;
            var detail = message.Detail.Replace("【Remark】", message.Task.Remark).Replace("【Url】", message.Url);
            EmailRepository.Send(new EmailEntity
            {
                IsLog = true,
                Mail = new MailInfo {Subject = message.Title, Body = detail, ToMails = new[] { account.Email}}
            });
        }

        /// <summary>
        /// 发送手机号码
        /// </summary>
        /// <param name="message"></param>
        protected virtual void SendMobileMesssage(MessageEntity message)
        {
            var account = Repository.Get<AccountEntity>(message.Task.Account.Id);
            if (account == null || string.IsNullOrEmpty(account.Mobile))
                return;
            var detail = message.Detail.Replace("【Remark】", message.Task.Remark).Replace("【Url】", message.Url);
            MobileRepository.Send(new MobileEntity { Body = detail, ToMobiles = new[] { account.Mobile } });
        }

        #region 添加验证
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        protected override bool ValidateAdd(TaskEntity info)
        {
            return ValidateConsumer(info) &&　ValidateAccount(info) && ValidateTask(info, null); 
        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        protected override bool ValidateModify(TaskEntity info)
        {
            var dataInfo = Repository.Get<TaskEntity>(info.Id);
            if (dataInfo == null)
                return false;
            return ValidateConsumer(info) && ValidateTask(info, dataInfo);
        }
        /// <summary>
        /// 验证订单
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        protected virtual bool ValidateConsumer(TaskEntity info)
        {
            if (info.Consumer != null)
            {
                return true;
            }
            info.AddError("ConsumerIsNull");
            return false;
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
        /// <param name="dataInfo"></param>
        /// <returns></returns>
        protected virtual bool ValidateTask(TaskEntity info, TaskEntity dataInfo)
        {
            if (!info.HasSaveProperty(it => it.Status) || info.SaveType == SaveType.Add)
                return true;
            if (dataInfo != null && dataInfo.Status == TaskStatusType.Waiting)
                return true;
            info.AddErrorByName(typeof(TaskEntity).FullName, "TaskHandled");
            return false;
        }

        #endregion


        #endregion


    }
}

