using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Beeant.Basic.Services.Mvc.Extension;
using Beeant.Basic.Services.Mvc.Extension.Mobile;
using Beeant.Basic.Services.Mvc.FilterAttribute;
using Beeant.Distributed.Outside.Pay.Models;
using Beeant.Domain.Entities.Finance;
using Winner.Persistence;
using Winner.Persistence.Linq;

namespace Beeant.Distributed.Outside.Pay.Controllers
{

    public class WechatPayController : PayController
    {
        #region 创建
        /// <summary>
        /// 创建
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [AuthorizeFilter]
        public virtual ActionResult Create(PaylineModel model)
        {
            if (string.IsNullOrWhiteSpace(Request["code"]))
            {
                var url = Request.Url.ToString();
                url = string.Format("{0}/Wechat/Oauth?url={1}", this.GetUrl("DistributedOutsideReceptionUrl"),
                    Server.UrlEncode(url));
                var wechat = this.Wechat();
                url = wechat.CreateAuthorityUrl(url, true);
                return Redirect(url);
            }
            var weinxinUser = this.Wechat().GetAuthorityUser();
            if (weinxinUser != null && weinxinUser.ContainsKey("openid") )
            {
                var openid = weinxinUser["openid"].ToString();
                model.Forms = model.Forms ?? new Dictionary<string, string>
                {
                    {"openid", openid}
                };
                return Create(model, PaylineType.Wechat);
            }
            return Result(model);
        }
        /// <summary>
        /// 通知
        /// </summary>
        public virtual ActionResult Process()
        {
            return Process(PaylineType.Wechat);
        }
        /// <summary>
        /// 创建
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [AuthorizeFilter]
        public virtual ActionResult Qr(PaylineModel model)
        {
            return View("Qr");
        }
        /// <summary>
        /// 创建
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        [AuthorizeFilter]
        public virtual ActionResult Success(string number)
        {
            PaylineModel model = new PaylineModel();
            var query = new QueryInfo();
            query.Query<PaylineEntity>().Where(it => it.Number == number && it.Status== PaylineStatusType.Success);
            model.Payline = this.GetEntities<PaylineEntity>(query)?.FirstOrDefault();
            return View("~/Views/Pay/Success.cshtml");
        }
        /// <summary>
        /// 创建
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [AuthorizeFilter]
        public virtual ActionResult Refund(PaylineModel model)
        {
            return Refund(model, PaylineType.Wechat);
        }

        #endregion
    }
}
