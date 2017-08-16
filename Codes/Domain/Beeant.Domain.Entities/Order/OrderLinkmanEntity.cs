using System;

namespace Beeant.Domain.Entities.Order
{
    [Serializable]
    public class OrderLinkmanEntity : BaseEntity<OrderLinkmanEntity>
    {
        /// <summary>
        /// 总订单标识Id
        /// </summary>
        public OrderEntity Order { get; set; }
        /// <summary>
        /// 编号
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// 联系人姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 手机号码
        /// </summary>
        public string Mobile { get; set; }

        /// <summary>
        /// 邮件
        /// </summary>
        public string Email { get; set; }
        
        public OrderLinkmanEntity DataEntity { get; set; }
        /// <summary>
        /// 设置添加业务
        /// </summary>
        protected override void SetAddBusiness()
        {
            Key = Key ?? "";
          
        }
    }
}
