using System;
using System.Collections.Generic;
using Beeant.Domain.Entities.Account;
using Component.Extension;

namespace Beeant.Domain.Entities.Workflow
{
    [Serializable]
    public class TaskEntity : BaseEntity<TaskEntity>
    {
        
        /// <summary>
        /// 用户
        /// </summary>
        public AccountEntity Account { get; set; }
        /// <summary>
        /// 数据
        /// </summary>
        public string Number { get; set; }
        /// <summary>
        /// 超时时间
        /// </summary>
        public DateTime OverTime { get; set; }
        /// <summary>
        /// 是否处理
        /// </summary>
        public TaskStatusType Status { get; set; }

        /// <summary>
        /// 处理时间
        /// </summary>
        public DateTime HandleTime { get; set; } = DateTime.MaxValue.GetDefault();
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 新任务
        /// </summary>
        public IList<TaskEntity> Tasks { get; set; }
        /// <summary>
        /// 处理实体
        /// </summary>
        public BaseEntity Consumer { get; set; }


    }
}
