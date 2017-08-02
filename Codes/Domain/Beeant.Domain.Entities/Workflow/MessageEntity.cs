using System;
using Beeant.Domain.Entities.Account;

namespace Beeant.Domain.Entities.Workflow
{
    [Serializable]
    public enum MessageType
    {

        /// <summary>
        /// 默认
        /// </summary>
        Default = 1,
        /// <summary>
        /// 邮箱
        /// </summary>
        Email = 2,
        /// <summary>
        /// 短信
        /// </summary>
        Mobile = 4
    }
    [Serializable]
    public class MessageEntity : BaseEntity<MessageEntity>
    {
       
   
        /// <summary>
        /// 任务
        /// </summary>
        public TaskEntity Task { get; set; }
        /// <summary>
        /// 类型
        /// </summary>
        public MessageType Type { get; set; }
    
        /// <summary>
        /// 处理地址
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        public string Detail { get; set; }
    }
}
