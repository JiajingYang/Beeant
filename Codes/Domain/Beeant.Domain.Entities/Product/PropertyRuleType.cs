﻿using System;

namespace Beeant.Domain.Entities.Product
{
    [Serializable]
    public enum PropertyRuleType
    {
        /// <summary>
        /// 添加时验证
        /// </summary>
        Add=1,
        /// <summary>
        /// 修改时验证
        /// </summary>
        Modify=2,
        /// <summary>
        /// 删除时验证
        /// </summary>
        Remove=3
    }
}
