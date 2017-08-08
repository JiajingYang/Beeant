using System.Web;
using System.Web.Routing;
using Beeant.Basic.Services.Mvc.Bases;
using Beeant.Basic.Services.Mvc.Extension;
using Beeant.Domain.Entities;
using Beeant.Domain.Entities.Cms;
using Beeant.Domain.Entities.Hr;
using Beeant.Domain.Entities.Workflow;
using Component.Extension;
using Configuration;

namespace Beeant.Cloud.Workflow
{
    public class WorkflowAuthorizeBaseController : BaseController
    {
        /// <summary>
        /// 站点Id
        /// </summary>
        public virtual long WorkflowId
        {
            get
            {
                if (ViewBag.WorkflowId != null)
                    return ViewBag.WorkflowId;
                var tmcid = RouteData.Values["tmcid"] ?? HttpContext.Request["tmcid"];
                if (tmcid != null)
                {
                    ViewBag.WorkflowId = tmcid.Convert<long>();
                }
                else
                {
                    ViewBag.WorkflowId = Identity == null ? 0 : Identity.GetNumber<long>("WorkflowId");
                }
                return ViewBag.WorkflowId;
            }
        }
 
        /// <summary>
        /// 站点Id
        /// </summary>
        public virtual long HrId
        {
            get
            {
                if (ViewBag.HrId == null)
                    ViewBag.HrId = Identity == null ? 0 : Identity.GetNumber<long>("HrId");
                return ViewBag.HrId;
            }
        }
        /// <summary>
        /// 站点Id
        /// </summary>
        public virtual long CmsId
        {
            get
            {
                if (ViewBag.CmsId == null)
                    ViewBag.CmsId = Identity == null ? 0 : Identity.GetNumber<long>("CmsId");
                return ViewBag.CmsId;
            }
        }
        /// <summary>
        /// 身份验证
        /// </summary>
        public virtual FlowEntity Flow
        {
            get
            {
                if (WorkflowId == 0)
                    return null;
                if (ViewBag.Workflow == null)
                    ViewBag.Workflow = this.GetEntity<FlowEntity>(WorkflowId);
                return ViewBag.Workflow;
            }
        }


        /// <summary>
        /// 身份验证
        /// </summary>
        public virtual HrEntity Hr
        {
            get
            {
                if (HrId == 0)
                    return null;
                if (ViewBag.Hr == null)
                    ViewBag.Hr = this.GetEntity<HrEntity>(HrId);
                return ViewBag.Hr;
            }
        }
        /// <summary>
        /// 身份验证
        /// </summary>
        public virtual CmsEntity Cms
        {
            get
            {
                if (CmsId == 0)
                    return null;
                if (ViewBag.Cms == null)
                    ViewBag.Cms = this.GetEntity<CmsEntity>(HrId);
                return ViewBag.Cms;
            }
        }
        /// <summary>
        /// 站点Id
        /// </summary>
        public virtual bool IsMainAccount
        {
            get
            {
                if (ViewBag.IsMainAccount!=null)
                  return ViewBag.IsMainAccount;
                ViewBag.IsMainAccount = Flow != null && Identity!=null && Flow.Account!=null && Flow.Account.Id== Identity.Id;
                return ViewBag.IsMainAccount;
            }
        }

        /// <summary>
        /// 得到路径
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        protected virtual string GetViewPath(string path)
        {
            string lang = null;
            HttpCookie cookie = System.Web.HttpContext.Current.Request.Cookies["language"];
            if (cookie != null)
            {
                cookie.Domain = ConfigurationManager.GetSetting<string>("Domain");
                cookie.Secure = false;
                cookie.Path = "/";
                lang= System.Web.HttpContext.Current.Server.UrlDecode(cookie.Value);
            }
            return GetViewPath(path, lang);
        }
        /// <summary>
        /// 订单查询识别码
        /// </summary>
        public virtual string RouteOpenId
        {
            get { return string.Format("WorkflowId{0}", WorkflowId); }
        }
    }
}
