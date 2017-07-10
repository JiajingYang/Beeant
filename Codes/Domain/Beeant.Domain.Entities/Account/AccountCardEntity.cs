using System;

namespace Beeant.Domain.Entities.Account
{
    [Serializable]
    public class AccountCardEntity : BaseEntity<AccountCardEntity>
    {
        /// <summary>
        /// 账户信息 
        /// </summary>
        public AccountEntity Account { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 卡类型
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// 标签
        /// </summary>
        public string Tag { get; set; }
        /// <summary>
        /// 卡号
        /// </summary>
        public string Number { get; set; }

    }
}
