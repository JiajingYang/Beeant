using Beeant.Domain.Entities.Account;

namespace Beeant.Domain.Entities.Workflow
{
    public class NodeAccountEntity : BaseEntity<NodeAccountEntity>
    {
        /// <summary>
        /// 账号
        /// </summary>
        public AccountEntity Account { get; set; }
        /// <summary>
        /// 节点
        /// </summary>
        public NodeEntity Node { get; set; }
    }
}
