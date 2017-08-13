using Beeant.Basic.Services.Mvc.FilterAttribute;
using System.Web.Mvc;
using Component.Sdk;
using Dependent;
using Beeant.Application.Services;
using Beeant.Basic.Services.Mvc.Extension.Mobile;
using Beeant.Domain.Entities;
using Beeant.Domain.Entities.Workflow;
using Component.Extension;

namespace Beeant.Cloud.Workflow
{
    public class WorkflowAuthorizeFilterAttribute :RoleFilterAttribute
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
            long tmcId = GetWorkflowId(filterContext);
            var flow = Ioc.Resolve<IApplicationService, FlowEntity>().GetEntity<FlowEntity>(tmcId);
            filterContext.Controller.ViewBag.WorkflowId = tmcId;
            filterContext.Controller.ViewBag.Workflow = flow;
            filterContext.Controller.ViewBag.IsMainAccount = flow != null && Identity != null && flow.Account != null && flow.Account.Id == Identity.Id;
            var isMainAccount = flow != null  && flow.Account != null && flow.Account.Id == Identity.Id;
            var rev = flow != null && (isMainAccount || VerifyResource(filterContext, Identity.Id));
            return rev;
        }

        /// <summary>
        /// 得到编号
        /// </summary>
        /// <param name="filterContext"></param>
        /// <returns></returns>
        protected virtual long GetWorkflowId(ActionExecutingContext filterContext)
        {
            var tmcid = filterContext.RouteData.Values["tmcid"] ?? filterContext.HttpContext.Request["tmcid"];
            if (tmcid != null)
            {
                return tmcid.Convert<long>();
            }
            return Identity == null ? 0 : Identity.GetNumber<long>("WorkflowId"); ;
        }
      
     

      
    }
}
