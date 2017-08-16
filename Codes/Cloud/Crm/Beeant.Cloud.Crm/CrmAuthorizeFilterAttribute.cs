using System;
using Beeant.Basic.Services.Mvc.FilterAttribute;
using System.Web.Mvc;
using Component.Sdk;
using Dependent;
using Beeant.Application.Services;
using Beeant.Basic.Services.Mvc.Extension.Mobile;
using Beeant.Domain.Entities;
using Beeant.Domain.Entities.Agent;
using Beeant.Domain.Entities.Crm;
using Component.Extension;

namespace Beeant.Cloud.Crm
{
    public class CrmAuthorizeFilterAttribute :RoleFilterAttribute
    {

 
        /// <summary>
        /// 
        /// </summary>
        public override WechatSdk WechatSdk
        {
            get { return ThirtyPartyExtension.Wechat(null); }
            set { base.WechatSdk = value; }
        }

        /// <summary>
        /// 跳转
        /// </summary>
        /// <param name="filterContext"></param>
        public override void RedirectPage(ActionExecutingContext filterContext)
        {
            if (Identity == null)
            {
                base.RedirectPage(filterContext);
            }
            else
            {
                filterContext.Result =
                    new RedirectResult("/Shared/NoAuthorize");
            }
        }
    

        /// <summary>
        /// 检查权限
        /// </summary>
        /// <returns></returns>
        public override bool CheckFilter(ActionExecutingContext filterContext)
        {
            if (Identity == null)
                return false;
            long tmcId = GetCrmId(filterContext);
            var crm = Ioc.Resolve<IApplicationService, CrmEntity>().GetEntity<CrmEntity>(tmcId);
            filterContext.Controller.ViewBag.CrmId = tmcId;
            filterContext.Controller.ViewBag.Crm = crm;
            filterContext.Controller.ViewBag.IsMainAccount = crm != null && Identity != null && crm.Account != null && crm.Account.Id == Identity.Id;
            var isMainAccount = crm != null  && crm.Account != null && crm.Account.Id == Identity.Id;
            var rev = crm != null && crm.ExpireDate>=DateTime.Now && (isMainAccount || VerifyResource(filterContext, Identity.Id));
            return rev;
        }

        /// <summary>
        /// 得到编号
        /// </summary>
        /// <param name="filterContext"></param>
        /// <returns></returns>
        protected virtual long GetCrmId(ActionExecutingContext filterContext)
        {
            var tmcid = filterContext.RouteData.Values["tmcid"] ?? filterContext.HttpContext.Request["tmcid"];
            if (tmcid != null)
            {
                return tmcid.Convert<long>();
            }
            return Identity == null ? 0 : Identity.GetNumber<long>("CrmId"); ;
        }
      
     

      
    }
}
