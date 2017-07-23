using System.Web.Mvc;
using Beeant.Basic.Services.Mvc.Bases;
using Beeant.Basic.Services.Mvc.FilterAttribute;
using Component.Extension;

namespace Beeant.Distributed.Outside.Pay.Controllers
{

    public class SharedController : SharedBaseController
    {
        /// <summary>
        /// 得到二维码
        /// </summary>
        /// <returns></returns>
        [AuthorizeFilter]
        public ActionResult GetQrCode(string url)
        {
            var bs = QrEncodHelper.Create(url);
            return File(bs, "image/jpeg");
        }

    }
}
