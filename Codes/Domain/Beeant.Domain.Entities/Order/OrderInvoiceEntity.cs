﻿using System;
using Winner.Persistence;

namespace Beeant.Domain.Entities.Order
{


    [Serializable]
    public class OrderInvoiceEntity : BaseEntity<OrderInvoiceEntity>
    {
        /// <summary>
        /// 订单
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
        /// 收款金额
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 收款记录
        /// </summary>
        public string Number { get; set; }
        /// <summary>
        /// 数据
        /// </summary>
        public OrderInvoiceEntity DataEntity { get; set; }

        /// <summary>
        /// 设置添加业务
        /// </summary>
        protected override void SetAddBusiness()
        {
            Key = Key ?? "";
            InvokeItemLoader("Order");
            SetOrder(Amount);

        }

        /// <summary>
        /// 设置修改业务
        /// </summary>
        protected override void SetModifyBusiness()
        {
            if (!HasSaveProperty(it => it.Amount))
                return;
            InvokeItemLoader("DataEntity");
            if (DataEntity == null || DataEntity.Amount == Amount)
                return;
            InvokeItemLoader("Order");
            SetOrder(Amount - DataEntity.Amount);

        }


        /// <summary>
        /// 设置删除订单
        /// </summary>
        protected override void SetRemoveBusiness()
        {
            InvokeItemLoader("DataEntity");
            if (Order != null && Order.SaveType == SaveType.Remove) return;
            InvokeItemLoader("Order");
            SetOrder(0 - DataEntity.Amount);

        }

        /// <summary>
        /// 设置订单
        /// </summary>
        /// <param name="amount"></param>
        protected virtual void SetOrder(decimal amount)
        {
            if (Order == null || Order.SaveType == SaveType.Remove) return;
            Order.InvoiceAmount += amount;
            if (Order.SaveType == SaveType.None)
            {
                Order.SetProperty(it => it.InvoiceAmount);
                Order.SaveType = SaveType.Modify;
            }
            else if (Order.Properties != null)
            {
                Order.SetProperty(it => it.InvoiceAmount);
            }
        }
    



    }
    
}
