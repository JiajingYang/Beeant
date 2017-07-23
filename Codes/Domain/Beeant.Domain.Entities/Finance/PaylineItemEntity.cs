using System;
using Beeant.Domain.Entities.Order;

namespace Beeant.Domain.Entities.Finance
{


    [Serializable]
    public class PaylineItemEntity : BaseEntity<PaylineItemEntity>
    {
        /// <summary>
        /// 关键字
        /// </summary>
        public string Key { get; set; }
        /// <summary>
        /// 订单
        /// </summary>
        public OrderEntity Order { get; set; }
        /// <summary>
        /// 支付记录
        /// </summary>
        public PaylineEntity Payline { get; set; }
        /// <summary>
        /// 金额
        /// </summary>
        public decimal Amount { get; set; }

        protected override void SetAddBusiness()
        {
            Key = Key ?? "";
            if (Payline != null)
                Payline.Amount += Amount;
            base.SetAddBusiness();
        }
    }
}
