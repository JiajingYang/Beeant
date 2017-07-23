﻿using System;

namespace Beeant.Domain.Entities.Order
{
    [Serializable]
    public class OrderAttachmentEntity : BaseEntity<OrderAttachmentEntity>
    {
        /// <summary>
        /// 总订单标识Id
        /// </summary>
        public OrderEntity Order { get; set; }
        /// <summary>
        /// 标签
        /// </summary>
        public string Tag { get; set; }
        /// <summary>
        /// 关键字
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// 附件名称（标题）
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 编号
        /// </summary>
        public  string Number { get; set; }
        /// <summary>
        /// 附件路径
        /// </summary>
        public string FileName { get; set; }
        /// <summary>
        /// 图片全路径
        /// </summary>
        public string FullFileName
        {
            get { return this.GetFullFileName(FileName); }
        }
        /// <summary>
        /// 附件文件流
        /// </summary>
        public byte[] FileByte { get; set; }
        /// <summary>
        /// 得到文件全路径
        /// </summary>
        public string DownFileUrl
        {
            get { return this.GetDownLoadUrl(FileName); }
        }

        protected override void SetAddBusiness()
        {
            Key = Key ?? "";
            base.SetAddBusiness();
        }


    }
}
