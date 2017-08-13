using System.Linq;
using System.Web.Mvc;
using Component.Extension;
using Beeant.Basic.Services.Mvc.Extension;
using Beeant.Cloud.Workflow.Website.Config.Models.Home;
using Beeant.Domain.Entities.Site;
using Winner.Persistence;
using Winner.Persistence.Linq;

namespace Beeant.Cloud.Workflow.Website.Config.Controllers.Home
{
    [WorkflowAuthorizeFilterAttribute(IsVerifyRole=true)]
    public class HomeController : WorkflowAuthorizeBaseController
    {
        /// <summary>
        /// 首页
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            var model = new HomeModel();
            return View(GetViewPath("~/Views/Home/index.cshtml"), model);
        }
      
    }
}
