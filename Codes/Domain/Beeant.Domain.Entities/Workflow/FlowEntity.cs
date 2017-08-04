using System;
using System.Collections.Generic;
using Beeant.Domain.Entities.Account;

namespace Beeant.Domain.Entities.Workflow
{
    [Serializable]
    public class FlowEntity : BaseEntity<FlowEntity>
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 账号
        /// </summary>
        public AccountEntity Account { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 服务类
        /// </summary>
        public string ClassName { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public int Sequence { get; set; }
    
        /// <summary>
        /// 状态
        /// </summary>
        public IList<NodeEntity> Nodes { get; set; }
    


    }
}
