using System;

namespace Beeant.Domain.Entities.Basedata
{
    [Serializable]
    public enum FreightType 
    {
        /// <summary>
        /// 快递
        /// </summary>
        Express=1,
        /// <summary>
        /// 配送
        /// </summary>
        Distribution = 2,
        /// <summary>
        /// 自取
        /// </summary>
        Take = 3
    }

}
