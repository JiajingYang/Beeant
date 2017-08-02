using System;
using Beeant.Domain.Entities.Account;


namespace Beeant.Domain.Entities.Workflow
{

    [Serializable]
    public class HistoryEntity : BaseEntity<HistoryEntity>
    {



        /// <summary>
        /// 账户
        /// </summary>
        public AccountEntity Account { get; set; }
        /// <summary>
        /// 编号
        /// </summary>

        public string Number { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public TaskStatusType Status { get; set; }
        /// <summary>
        /// 超时时间
        /// </summary>
        public DateTime OverTime { get; set; }
        /// <summary>
        /// 渠道
        /// </summary>
        public string Channel { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public string StatusName => Status.GetName();
      
    }
}
