using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Beeant.Basic.Services.Mvc.Bases;
using Beeant.Basic.Services.Mvc.Extension;
using Beeant.Basic.Services.Mvc.FilterAttribute;
using Beeant.Distributed.Outside.Version.Models;
using Component.Extension;
using Dependent;

namespace Beeant.Distributed.Outside.Version.Controllers
{
    /// <summary>
    /// 通用的客户端程序版本控制类
    /// </summary>
    /// <see cref="Index"><para>product</para>获取更新列表</see>
    /// <see cref="Detail"><para>product</para>获取更新明细</see>
    public class HomeController : ApiBaseController
    {
        [TokenFilter(Method = "Beeant.Distributed.Outside.Version.Home.Index")]
        [ValidateInput(false)]
        public ActionResult Index(string product)
        {
            if (string.IsNullOrEmpty(product))
            {
                return this.Jsonp(new Dictionary<string, object> {{ "Success", "Failure" }, {"Message", "未知的产品名称"}});
            }
            var data = GetUpdateList(product);

            return this.Jsonp(new Dictionary<string, object>
            {
                {"Success", data == null ? "Failure" : "Success"},
                {"Message", data == null ? $"没有获取产品【{product}】的更新列表" : "更新列表获取成功"},
                {"Data", data}
            });
        }
        [TokenFilter(Method = "Beeant.Distributed.Outside.Version.Home.Detail")]
        [ValidateInput(false)]
        public ActionResult Detail(string product,string folder)
        {
            
            if (string.IsNullOrEmpty(product)||string.IsNullOrEmpty(folder))
            {
                return this.Jsonp(new Dictionary<string, object> { { "Success", "Failure" }, { "Message", "未知的产品名称或文件夹" } });
            }
            var data = GetUpdate(product, folder);

            return this.Jsonp(new Dictionary<string, object>
            {
                {"Success", data == null ? "Failure" : "Success"},
                {"Message", data == null ? $"没有获取产品【{product}】的更新明细" : "更新明细获取成功"},
                {"Data", data}
            });
        }
        [TokenFilter(Method = "Beeant.Distributed.Outside.Version.Home.Download")]
        [ValidateInput(false)]
        public ActionResult Download(string product, string folder, string fileName)
        {
            if (string.IsNullOrEmpty(product) || string.IsNullOrEmpty(folder) || string.IsNullOrEmpty(fileName))
            {
                return null;
            }

            var data = GetFile(product, folder, fileName);
            if (data == null) return null;
            //压缩
            data = data.Compress();
            return data == null ? null : File(data, MimeMapping.GetMimeMapping(fileName));
        }
        #region 获取
        /// <summary>
        /// 获取更新列表
        /// </summary>
        /// <param name="product">产品名称</param>
        /// <returns>UpdateList</returns>
        /// <see cref="UpdateList"/>
        protected virtual dynamic GetUpdateList(string product)
        {
            //设置更新列表的路径
            var path = Server.MapPath($"~//Applications//{product}//UpdateList.xml");
            if (!System.IO.File.Exists(path)) return null;
            var xml = "";
            using (var sr = new StreamReader(path))
            {
                xml = sr.ReadToEnd();
            }
            return xml?.DeserializeXml<UpdateList>();
        }
        /// <summary>
        /// 获取更新明细
        /// </summary>
        /// <param name="product">产品名称</param>
        /// <param name="folder">文件夹</param>
        /// <returns>Update</returns>
        /// <see cref="Update"/>
        protected virtual dynamic GetUpdate(string product, string folder)
        {
            //设置更新明细的路径
            var path = Server.MapPath($"~//Applications//{product}//{folder}//Update.xml");
            if (!System.IO.File.Exists(path)) return null;
            var xml = "";
            using (var sr = new StreamReader(path))
            {
                xml = sr.ReadToEnd();
            }
            return xml?.DeserializeXml<Update>();
        }
        /// <summary>
        /// 获取文件二进制流
        /// </summary>
        /// <param name="product">产品名称</param>
        /// <param name="folder">文件夹</param>
        /// <param name="fileName">文件名</param>
        /// <returns>文件二进制流</returns>
        protected virtual byte[] GetFile(string product, string folder, string fileName)
        {
            //设置下载文件的路径
            var path = Server.MapPath($"~//Applications//{product}//{folder}//{fileName}");
            if (!System.IO.File.Exists(path)) return null;
            try
            {
                using (var fs = System.IO.File.OpenRead(path))
                {
                    // Read the source file into a byte array.
                    var bytes = new byte[fs.Length];
                    var numBytesToRead = fs.Length.Convert<int>();
                    var numBytesRead = 0;
                    while (numBytesToRead > 0)
                    {
                        // Read may return anything from 0 to numBytesToRead.
                        int n = fs.Read(bytes, numBytesRead, numBytesToRead);

                        // Break when the end of the file is reached.
                        if (n == 0)
                            break;

                        numBytesRead += n;
                        numBytesToRead -= n;
                    }
                    return bytes;
                }
            }
            catch //(System.Exception)
            {
                return null;
            }
        }
        #endregion

    }
}
