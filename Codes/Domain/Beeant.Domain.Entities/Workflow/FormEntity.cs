using System;
using Beeant.Domain.Entities.Account;

namespace Beeant.Domain.Entities.Workflow
{
    [Serializable]
    public class FormEntity : BaseEntity<FormEntity>
    {
        public RequestEntity Request { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 标签
        /// </summary>
        public string Tag { get; set; }
        /// <summary>
        /// 账号
        /// </summary>
        public AccountEntity Account { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string From { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        public string Body { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }

       


    }
}
