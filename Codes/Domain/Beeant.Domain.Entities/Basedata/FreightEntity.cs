using System;
using System.Collections.Generic;
using System.Linq;
using Component.Extension;
using Beeant.Domain.Entities.Account;
using Beeant.Domain.Entities.Gis;

namespace Beeant.Domain.Entities.Basedata
{
    [Serializable]
    public class FreightEntity : BaseEntity<FreightEntity>
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 配送方式
        /// </summary>
        public FreightType Type { get; set; }

        /// <summary>
        /// 标签
        /// </summary>
        public string TypeName
        {
            get { return Type.GetName(); }
        }

        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 满额免运费
        /// </summary>
        public decimal FullFreePrice { get; set; }

        /// <summary>
        /// 首次数量
        /// </summary>
        public int DefaultCount { get; set; }

        /// <summary>
        /// 首次价格
        /// </summary>
        public decimal DefaultPrice { get; set; }

        /// <summary>
        /// 续重数量
        /// </summary>
        public int ContinueCount { get; set; }

        /// <summary>
        /// 续重价格
        /// </summary>
        public decimal ContinuePrice { get; set; }


        /// <summary>
        /// 所属账户
        /// </summary>
        public AccountEntity Account { get; set; }

        private string _region;

        /// <summary>
        /// 区域
        /// </summary>
        public string Region
        {
            get { return _region; }
            set
            {
                _region = value;
                _regions = value.DeserializeJson<List<FreightRegionEntity>>();
            }
        }

        private IList<FreightRegionEntity> _regions;

        /// <summary>
        /// 运价方式
        /// </summary>
        public IList<FreightRegionEntity> Regions
        {
            get
            {
                if (_regions != null)
                    return _regions;
                if (string.IsNullOrWhiteSpace(_region))
                    return null;
                _regions = _region.DeserializeJson<List<FreightRegionEntity>>();
                return _regions;
            }
            set
            {
                _regions = value;
                _region = value.SerializeJson();
            }
        }

        #region 计算

        /// <summary>
        /// 价格
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// 成本
        /// </summary>
        public decimal Cost { get; set; }

        /// <summary>
        /// 计算 
        /// </summary>
        public FreightCalculatorEntity Calculator { get; set; }

        /// <summary>
        /// 确认是否包邮
        /// </summary>
        /// <returns></returns>
        public virtual void Set(FreightCalculatorEntity calculator)
        {
            Calculator = calculator;
            switch (Type)
            {
                case FreightType.Distribution:
                    SetDistribution(calculator);
                    break;
                case FreightType.Express:
                    SetRegionPrice(calculator);
                    break;
            }

        }

        /// <summary>
        /// 设置配送
        /// </summary>
        /// <param name="calculator"></param>
        protected virtual void SetDistribution(FreightCalculatorEntity calculator)
        {
            if (calculator.Area == null || string.IsNullOrEmpty(calculator.Area.Value))
                return;
            Price = calculator.Area.Value.Convert<decimal>();
            if (calculator.Count > DefaultCount)
            {
                var overCount = calculator.Count - DefaultCount;
                var priceCount = (int) Math.Ceiling((double) overCount / (ContinueCount == 0 ? 1 : ContinueCount));
                Price = Price + priceCount * ContinuePrice;
            }
            Cost = Price;
            if (FullFreePrice > 0 && FullFreePrice <= calculator.PayAmount)
            {
                Price = 0;
            }

        }

        /// <summary>
        /// 设置配送
        /// </summary>
        /// <param name="calculator"></param>
        /// <param name="price"></param>
        /// <param name="defaultCount"></param>
        protected virtual decimal GetDistribution(FreightCalculatorEntity calculator, decimal price, int defaultCount)
        {
            if (calculator.Count > defaultCount)
            {
                var overCount = calculator.Count - defaultCount;
                var priceCount = (int) Math.Ceiling((double) overCount / (ContinueCount == 0 ? 1 : ContinueCount));
                price = price + priceCount * ContinuePrice;
            }
            return price;

        }

        /// <summary>
        /// 得到价格
        /// </summary>
        /// <param name="calculator"></param>
        /// <returns></returns>
        public virtual void SetRegionPrice(FreightCalculatorEntity calculator)
        {

            var region = Regions?.FirstOrDefault(it => it.GetRegionArray() != null
                                                       &&
                                                       (it.GetRegionArray().Contains(calculator.Province) ||
                                                        it.GetRegionArray().Contains(calculator.City)
                                                        || it.GetRegionArray().Contains(calculator.County)));
            var defaultPrice = region == null ? DefaultPrice : region.DefaultPrice;
            var defaultCount = region == null ? DefaultCount : region.DefaultCount;
            if (FullFreePrice > 0 && FullFreePrice <= calculator.PayAmount)
            {
                Price = 0;
                Cost = GetRegionPrice(calculator, region, defaultPrice, defaultCount);
            }
            Price = Cost = GetRegionPrice(calculator, region, defaultPrice, defaultCount);
        }

        /// <summary>
        /// 得到价格
        /// </summary>
        /// <param name="calculator"></param>
        /// <param name="region"></param>
        /// <param name="defaultPrice"></param>
        /// <param name="defaultCount"></param>
        /// <returns></returns>
        protected virtual decimal GetRegionPrice(FreightCalculatorEntity calculator, FreightRegionEntity region,
            decimal defaultPrice, int defaultCount)
        {

            var continuePrice = region == null ? ContinuePrice : region.ContinuePrice;
            var continueCount = region == null ? ContinueCount : region.ContinueCount;
            if (calculator.Count > defaultCount)
            {
                var overCount = calculator.Count - defaultCount;
                var priceCount = (int) Math.Ceiling((double) overCount / (continueCount == 0 ? 1 : continueCount));
                return defaultPrice + priceCount * continuePrice;
            }
            return defaultPrice;
        }

        /// <summary>
        /// 得到续重价格
        /// </summary>
        /// <returns></returns>
        public virtual decimal GetContinuePrice(FreightCalculatorEntity calculator)
        {
            if (Type == FreightType.Take)
                return 0;
            if (Type == FreightType.Distribution)
            {
                return GetDistribution(calculator, 0, 0);
            }
            if (Type == FreightType.Express)
            {
                var region = Regions?.FirstOrDefault(it => it.GetRegionArray() != null
                                                           &&
                                                           (it.GetRegionArray().Contains(calculator.Province) ||
                                                            it.GetRegionArray().Contains(calculator.City)
                                                            || it.GetRegionArray().Contains(calculator.County)));
                return GetRegionPrice(calculator, region, 0, 0);
            }
            return 0;
        }

        #endregion
    }

    [Serializable]
    public class FreightRegionEntity 
    {

        /// <summary>
        /// 城市
        /// </summary>
        public string Region { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 首次数量
        /// </summary>
        public int DefaultCount { get; set; }
        /// <summary>
        /// 首次价格
        /// </summary>
        public decimal DefaultPrice { get; set; }
        /// <summary>
        /// 续重数量
        /// </summary>
        public int ContinueCount { get; set; }
        /// <summary>
        /// 续重价格
        /// </summary>
        public decimal ContinuePrice { get; set; }

        private string[] _egionArray;

        /// <summary>
        /// 区域
        /// </summary>
        public string[] GetRegionArray()
        {

            if (_egionArray != null)
                return _egionArray;
            if (string.IsNullOrEmpty(Region))
                return null;
            _egionArray = Region.Split(',');
            return _egionArray;
        }

    }
    [Serializable]
    public class FreightCalculatorEntity
    {
        /// <summary>
        /// 省份
        /// </summary>
        public string Province { get; set; }

        /// <summary>
        /// 城市
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// 县
        /// </summary>
        public string County { get; set; }

        /// <summary>
        /// 支付单金额
        /// </summary>
        public decimal PayAmount { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// 区域
        /// </summary>
        public AreaEntity Area { get; set; }


        /// <summary>
        /// 计算
        /// </summary>
        /// <param name="region"></param>
        /// <returns></returns>
        public virtual bool Calculate(string[] region)
        {
            if (region == null)
                return false;
            return region.Contains(Province) || region.Contains(City) || region.Contains(County);
        }
    }

}
