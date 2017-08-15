using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Web;
using Aop.Api;
using Aop.Api.Request;
using Aop.Api.Response;
using Aop.Api.Util;
using Component.Extension;
using Configuration;
using Beeant.Domain.Entities.Finance;
using Beeant.Domain.Entities.Log;
using Winner.Persistence;

namespace Beeant.Repository.Services.Finance
{
    public class AliPaylineRepository : PaylineRepository
    {
        private dynamic _aliPayConfig;
        public dynamic AliPayConfig
        {
            get
            {
                if (_aliPayConfig == null)
                    _aliPayConfig = ConfigurationManager.GetSetting<string>("AliPay").DeserializeJson<dynamic>();
                return _aliPayConfig;
            }
        }
        /// <summary>
        /// 合作伙伴
        /// </summary>
        public string Url
        {
            get { return AliPayConfig.Url; }
        }
        /// <summary>
        /// 合作伙伴
        /// </summary>
        public string AppId
        {
            get { return AliPayConfig.AppId; }
        }

        /// <summary>
        /// 密钥
        /// </summary>
        public string PrivateKey
        {
            get
            {
                return AliPayConfig.PrivateKey;
            }
        }

        /// <summary>
        /// 支付宝邮箱
        /// </summary>
        public string AliPayPublicKey
        {
            get
            {
                return AliPayConfig.AliPayPublicKey;
            }
        }

        #region 创建


        private IAopClient _aopClient;
        protected virtual IAopClient AopClient
        {
            get
            {
                if (_aopClient == null)
                    _aopClient = new DefaultAopClient(Url, AppId, PrivateKey, "json", "1.0", "RSA2", AliPayPublicKey, "UTF-8", false);
                return _aopClient;
            }
        }
        /// <summary>
        /// 创建
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public override bool Create(PaylineEntity info)
        {
            var rev = false;
            switch (info.ChannelType)
            {
                case Domain.Entities.ChannelType.Mobile:
                    rev= CreateByWap(info);break;
                case Domain.Entities.ChannelType.Website:
                    rev = CreateByPage(info); break;
            }
            LogHelper.AddEcho(new EchoEntity
            {
                Method = "Beeant.Repository.Services.Finance.AliPaylineRepository.Create",
                Request = info.Request,
                Response ="" ,
                Remark = "",
                Url = HttpContext.Current.Request.Url.ToString(),
                Key = info.Number,
                SaveType = SaveType.Add
            });
            return rev;
        }

        /// <summary>
        /// 手机支付
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        protected virtual bool CreateByWap(PaylineEntity info)
        {
            var builder = new StringBuilder("{");
            builder.AppendFormat("\"body\":\"{0}\",", info.TypeName);
            builder.AppendFormat("\"subject\":\"{0}\",", info.TypeName);
            builder.AppendFormat("\"out_trade_no\":\"{0}\",", info.Number);
            builder.AppendFormat("\"total_amount\":\"{0}\",", info.Amount != 0 || info.PaylineItems == null ? info.Amount : info.PaylineItems.Sum(it => it.Amount));
            builder.AppendFormat("\"product_code\":\"{0}\",", "QUICK_WAP_PAY");//FAST_INSTANT_TRADE_PAY
            builder.Append("}");

            AlipayTradeWapPayRequest request = new AlipayTradeWapPayRequest();
            request.BizContent = builder.ToString();
            var processUrl = string.Format("{0}/AliPay/Process",
                ConfigurationManager.GetSetting<string>("DistributedOutsidePayUrl"));
            var returnUrl = string.Format("{0}?returnurl={1}&returntitle={2}&autoreturnurl={3}&autoreturntitle={4}"
                , processUrl,HttpContext.Current.Request["returnurl"]
                , HttpContext.Current.Request["returntitle"]
                , HttpContext.Current.Request["autoreturnurl"]
                , HttpContext.Current.Request["autoreturntitle"]);
            request.SetReturnUrl(returnUrl);
            request.SetNotifyUrl(processUrl);
            AlipayTradeWapPayResponse response = AopClient.pageExecute(request);
            info.Request = response.Body;
      
            return true;
        }

        /// <summary>
        /// PC 支付
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        protected virtual bool CreateByPage(PaylineEntity info)
        {
            var builder = new StringBuilder("{");
            //订单描述，可空
            builder.AppendFormat("\"body\":\"订单支付{0}\",", info.Number);
            //订单标题
            builder.AppendFormat("\"subject\":\"订单支付{0}\",", info.Number);
            //商户订单号，64个字符以内、可包含字母、数字、下划线；需保证在商户端不重复
            builder.AppendFormat("\"out_trade_no\":\"{0}\",", info.Number);
            //订单总金额
            builder.AppendFormat("\"total_amount\":\"{0}\",", info.Amount != 0 || info.PaylineItems == null ? info.Amount : info.PaylineItems.Sum(it => it.Amount));
            //销售产品码，与支付宝签约的产品码名称。 注：目前仅支持FAST_INSTANT_TRADE_PAY
            builder.AppendFormat("\"product_code\":\"{0}\"", "FAST_INSTANT_TRADE_PAY");
            builder.Append("}");

            AlipayTradePagePayRequest request = new AlipayTradePagePayRequest();

            request.BizContent = builder.ToString();
            var processUrl = string.Format("{0}/AliPay/Process",
                ConfigurationManager.GetSetting<string>("DistributedOutsidePayUrl"));
            request.SetReturnUrl(processUrl);
            request.SetNotifyUrl(processUrl);
            AlipayTradePagePayResponse response = AopClient.pageExecute(request);
            info.Request = response.Body;
            return true;
        }

        #endregion

        #region 处理

        /// <summary>
        /// 处理
        /// </summary>
        /// <returns></returns>
        public override PaylineEntity Process()
        {
            var sPara = GetResponse();
            bool isVerify = VerifyProcess(sPara);
            var number = sPara.ContainsKey("out_trade_no") ? sPara["out_trade_no"] : "";
            var info = GetPayline(number);
            if (info == null || info.Amount != sPara["total_amount"].Convert<decimal>())
                return null;
            info.OutNumber = sPara["trade_no"];
            info.Status = isVerify ? PaylineStatusType.Success : PaylineStatusType.Failure;
            info.SetProperty(it => it.OutNumber);
            info.SetProperty(it => it.Status);
            info.SaveType = SaveType.Modify;
            LogHelper.AddEcho(new EchoEntity
            {
                Method = "Beeant.Repository.Services.Finance.AliPaylineRepository.Process",
                Request = "",
                Response = sPara.SerializeJson(),
                Remark = "",
                Url = HttpContext.Current.Request.Url.ToString(),
                Key = number,
                SaveType = SaveType.Add
            });
            return info;
        }


        /// <summary>
        /// 得到请求参数
        /// </summary>
        /// <returns></returns>
        protected override IDictionary<string, string> GetResponse()
        {
            var request = HttpContext.Current.Request;
            var sArray = new SortedDictionary<string, string>();
            NameValueCollection coll = request.Form.AllKeys.Contains("notify_id")
                                           ? request.Form
                                           : request.QueryString;

            foreach (string key in coll.AllKeys)
            {
                sArray.Add(key, coll[key]);
            }
            return sArray;
        }

        /// <summary>
        /// 验证
        /// </summary>
        /// <param name="inputPara"></param>
        /// <returns></returns>
        protected override bool VerifyProcess(IDictionary<string, string> inputPara)
        {
            return AlipaySignature.RSACheckV1(inputPara, AliPayPublicKey, "UTF-8", "RSA2", false);
        }


        #endregion
        /// <summary>
        /// 得到支付结果
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        protected virtual string GetPayResult(string number)
        {
            var builder = new StringBuilder("{");
            builder.AppendFormat("\"out_trade_no\":\"{0}\",", number);
            builder.Append("}");
            AlipayTradeQueryRequest request = new AlipayTradeQueryRequest();
            request.BizContent = builder.ToString();
            AlipayTradeQueryResponse response = AopClient.pageExecute(request);
            return response.TradeStatus;
        }
        /// <summary>
        /// 检查
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public override bool Check(PaylineEntity info)
        {
            if (string.IsNullOrEmpty(info.OutNumber) || info.Status != PaylineStatusType.Waiting || string.IsNullOrEmpty(info.Number))
                return false;
            var result = GetPayResult(info.Number);
            if (string.IsNullOrEmpty(result) || result == "WAIT_BUYER_PAY")
                return false;
            if (result == "TRADE_SUCCESS" || result == "TRADE_FINISHED")
                info.Status = PaylineStatusType.Success;
            else
                info.Status = PaylineStatusType.Failure;
            info.SaveType = SaveType.Modify;
            info.SetProperty(it => it.Status);
            return true;
        }


        #region 退款

        public override bool Refund(PaylineEntity info)
        {
            var builder = new StringBuilder("{");
            //订单支付时传入的商户订单号,不能和 trade_no同时为空。
            builder.AppendFormat("\"out_trade_no\":\"{0}\",", info.Number);
            //支付宝交易号，和商户订单号不能同时为空  2017开头
            builder.AppendFormat("\"trade_no\":\"{0}\",", info.OutNumber);
            //需要退款的金额，该金额不能大于订单金额,单位为元，支持两位小数
            builder.AppendFormat("\"refund_amount\":\"{0}\",", 0 - info.Amount);
            //	退款的原因说明
            builder.AppendFormat("\"refund_reason\":\"{0}\",", "测试退款");
            //	标识一次退款请求，同一笔交易多次退款需要保证唯一，如需部分退款，则此参数必传。
            builder.AppendFormat("\"out_request_no\":\"{0}\"", info.Number);
            ////商户的操作员编号
            //builder.AppendFormat("\"operator_id\":\"{0}\"", "FAST_INSTANT_TRADE_PAY");
            ////	商户的门店编号
            //builder.AppendFormat("\"store_id\":\"{0}\"", "FAST_INSTANT_TRADE_PAY");
            ////商户的终端编号
            //builder.AppendFormat("\"terminal_id\":\"{0}\"", "FAST_INSTANT_TRADE_PAY");
            builder.Append("}");

            AlipayTradeRefundRequest request = new AlipayTradeRefundRequest();

            request.BizContent = builder.ToString();

            AlipayTradeRefundResponse response = AopClient.Execute(request);
            info.Request = response.Body;
            LogHelper.AddEcho(new EchoEntity
            {
                Method = "Beeant.Repository.Services.Finance.AliPaylineRepository.Refund",
                Request = request.BizContent,
                Response = response.Body,
                Remark = "",
                Url = HttpContext.Current.Request.Url.ToString(),
                Key = info.Number,
                SaveType = SaveType.Add
            });
            if (response.Msg == "Success")
            {
                info.OutNumber = response.TradeNo;
                info.Status = PaylineStatusType.Success;
                return true;
            }

            return false;
        }

        #endregion


    }
}
