using System;

namespace Beeant.Domain.Entities.Order
{
    [Serializable]
    public class OrderCardEntity : BaseEntity<OrderCardEntity>
    {
        /// <summary>
        /// 订单信息 
        /// </summary>
        public OrderEntity Order { get; set; }
        /// <summary>
        /// 关键字
        /// </summary>
        public string Key { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 标签
        /// </summary>
        public string Tag { get; set; }
        /// <summary>
        /// 卡号
        /// </summary>
        public string Number { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }

        public OrderCardEntity DataEntity { get; set; }
        protected override void SetAddBusiness()
        {
            Key = Key ?? "";
            base.SetAddBusiness();
        }
    }
}
