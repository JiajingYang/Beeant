using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Beeant.Presentation.Client.Launcher.Utility
{
    /// <summary>
    /// 更新工具
    /// </summary>
    public class UpdateTool
    {
        /// <summary>
        /// 配置文件名
        /// </summary>
        private const string ConfigFile = "Config.json";
        /// <summary>
        /// 配置类实例
        /// </summary>
        public static Config Config;
        /// <summary>
        /// Url
        /// </summary>
        private static readonly string VersionApi;
        static UpdateTool()
        {
            LoadConfig();
            VersionApi = string.Empty;
            foreach (var api in Config.Api)
            {
                if (api.Key != "Version") continue;
                var json = api.Value.DeserializeJson<dynamic>();
                VersionApi = json?.Url ?? string.Empty;
            }
        }
        #region 读取配置文件

        protected static void LoadConfig()
        {
            var path = Path.Combine(Application.StartupPath, ConfigFile);
            if (File.Exists(path))
            {
                using (var file = new FileStream(path, FileMode.Open, FileAccess.Read))
                {
                    using (var reader = new StreamReader(file, Encoding.UTF8))
                    {
                        var json = reader.ReadToEnd();
                        {
                            var data = json.DeserializeJson<Config>();
                            if (data != null)
                            {
                                Config = data;
                                return;
                            }
                        }
                    }
                }
            }
            Config = DefaultConfig;
        }

        private static Config DefaultConfig => new Config
        {
            Api = new List<Detail>
            {
                new Detail {Key = "Version", Value = "{Url:''}"}
            }
        };

        #endregion
        #region 版本检测初始化

        public static CheckResult CheckParam(params string[] args)
        {
            var result = new CheckResult();

#if (!DEBUG)
            {
                if (args.Length != 3)
                {
                    MessageBox.Show(@"不能直接打开更新程序！", @"信息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return result;
                }
            }
#endif
            if (args.Length >= 1)
            {
                result.ProductName = args[0];
            }

            if (args.Length >= 2)
            {
                result.ProductVersion = args[1];
            }
            if (args.Length >= 3)
            {
                result.ExecutablePath = args[2];
            }
#if (!DEBUG)
            {
                if (!File.Exists(result.ExecutablePath))
                {
                    MessageBox.Show(@"找不到主程序，请尝试重新打开！", @"信息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return result;
                }
                if (Path.GetDirectoryName(result.ExecutablePath) != Application.StartupPath)
                {
                    MessageBox.Show(@"请确认主程序与更新程序在同一目录！", @"信息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return result;
                }
            }
#else
            {

                //调试用begin==================================================================
                result.ProductName = "Eterm";
                result.ExecutablePath = Path.Combine(Application.StartupPath, "Eterm.exe");
                result.ProductVersion = "1.0.0";
                //end=========================================================================
            }
#endif
            
            //检查是否需要更新
            if (!CheckForUpdate(result))
            {
                //StartProcess(result.ExecutablePath);
                return result;
            }
            result.Success = true;
            return result;
        }

        #endregion
        #region 获取更新

        /// <summary>
        /// 检查产品更新
        /// </summary>
        /// <param name="checkResult"></param>
        /// <returns>true 表示需要更新</returns>
        public static bool CheckForUpdate(CheckResult checkResult)
        {
            checkResult.NeedForUpdate = new List<ProductVersion>();
            if (!File.Exists(checkResult.ExecutablePath)) return true;

            //调用api,获取服务器端需要更新的列表（比当前版本号productVersion大）
            checkResult.NeedForUpdate = GetProductVersion(checkResult.ProductName, checkResult.ProductVersion);
            return checkResult.NeedForUpdate.Count > 0;
        }
        /// <summary>
        /// 获取产品的版本更新明细
        /// </summary>
        /// <param name="productName"></param>
        /// <param name="folder"></param>
        /// <param name="versionDetail"></param>
        /// <returns></returns>
        public static bool GetProductVersionDetail(string productName, string folder,ref Update versionDetail)
        {
            versionDetail = null;
            if (string.IsNullOrEmpty(productName) || string.IsNullOrEmpty(folder))
            {
                return false;
            }
            var json = GetUpdate(productName, folder);
            if (json == null) return false;
            var response = json.DeserializeJson<dynamic>();
            if (response == null || response.Success != "Success" || response.Data == null)
            {
                return false;
            }
            string data = response.Data.ToString();
            versionDetail = data.DeserializeJson<Update>();
            return versionDetail != null;
        }
        /// <summary>
        /// 获取需要更新的版本
        /// </summary>
        /// <param name="productName"></param>
        /// <param name="localVersion"></param>
        /// <returns></returns>
        protected static List<ProductVersion> GetProductVersion(string productName, string localVersion)
        {
            var listVersion = new List<ProductVersion>();
            if (string.IsNullOrEmpty(productName) || string.IsNullOrEmpty(localVersion))
            {
                return listVersion;
            }
            var json = GetUpdateList(productName);
            if (json == null)
            {
                return listVersion;
            }

            var response = json.DeserializeJson<dynamic>();
            if (response == null || response.Success != "Success" || response.Data == null)
            {
                return listVersion;
            }

            string data = response.Data.ToString();
            foreach (var detail in data.DeserializeJson<UpdateList>().Version)
            {
                if (detail.Ignore) continue;
                if (string.CompareOrdinal(localVersion, detail.Value) >= 0) continue;

                listVersion.Add(detail);
            }
            return listVersion;
        }
        /// <summary>
        /// 获取更新列表
        /// </summary>
        /// <param name="productName"></param>
        /// <returns>json</returns>
        protected static string GetUpdateList(string productName)
        {
            if (string.IsNullOrEmpty(VersionApi) || string.IsNullOrEmpty(productName))
            {
                return null;
            }
            var url = $"{VersionApi}/Home/Index"; //读配置文件获取
            var posts = new Dictionary<string, string>
            {
                {"product", productName}
            };
            return WebRequestHelper.SendPostRequest(url, posts);
        }
        /// <summary>
        /// 获取更新明细
        /// </summary>
        /// <param name="productName"></param>
        /// <param name="folder"></param>
        /// <returns>json</returns>
        protected static string GetUpdate(string productName, string folder)
        {
            if (string.IsNullOrEmpty(productName) || string.IsNullOrEmpty(folder))
            {
                return null;
            }
            var url = $"{VersionApi}/Home/Detail"; //读配置文件获取
            var posts = new Dictionary<string, string>
            {
                {"product", productName},
                {"folder", folder}
            };
            return WebRequestHelper.SendPostRequest(url, posts);
        }

        #endregion
        #region 下载文件
        /// <summary>
        /// 下载
        /// </summary>
        /// <param name="productName">产品名称</param>
        /// <param name="sourceFolder">服务器端文件夹</param>
        /// <param name="targetFolder">本地文件夹</param>
        /// <param name="fileName">文件名</param>
        /// <returns></returns>
        public static bool Download(string productName, string sourceFolder, string targetFolder, string fileName, ref string message)
        {
            try
            {
                var data = DownloadFile(productName, sourceFolder, fileName);

                if (data == null)
                {
                    fileName = string.IsNullOrEmpty(fileName) ? "未知的文件名" : fileName;
                    throw new Exception($"下载文件【{fileName}】失败!");
                }
                var path = Path.Combine(Application.StartupPath, (string.IsNullOrEmpty(targetFolder) ? string.Empty : targetFolder), fileName);
                using (var fs = new FileStream(path, FileMode.Create))
                {
                    fs.Write(data, 0, data.Length);
                }
                return true;
            }
            catch (Exception e)
            {
                message = e.Message;
                return false;
            }
        }
        /// <summary>
        /// 下载文件
        /// </summary>
        /// <param name="productName">产品名称</param>
        /// <param name="folder">服务器端文件夹</param>
        /// <param name="fileName">文件名</param>
        /// <returns>文件二进制流</returns>
        protected static byte[] DownloadFile(string productName, string folder, string fileName)
        {
            if (string.IsNullOrEmpty(productName) || string.IsNullOrEmpty(folder) || string.IsNullOrEmpty(fileName))
            {
                return null;
            }
            var url = $"{VersionApi}/Home/Download";//读配置文件获取
            var posts = new Dictionary<string, string>
            {
                {"product", productName},
                {"folder", folder},
                {"fileName", fileName}
            };
            return WebRequestHelper.Download((HttpWebRequest)WebRequest.Create(url), Encoding.UTF8, posts);
        }
        #endregion
        #region 拷贝文件

        /// <summary>
        /// 拷贝文件
        /// </summary>
        /// <param name="source">源文件夹</param>
        /// <param name="target">目标文件夹</param>
        /// <param name="name">文件名</param>
        /// <param name="message"></param>
        /// <param name="overwrite">覆盖原文件</param>
        /// <returns></returns>
        public static bool Copy(string source, string target, string name, ref string message, bool overwrite = true)
        {
            try
            {
                if (string.IsNullOrEmpty(name))
                {
                    name = string.IsNullOrEmpty(name) ? "未知的文件名" : name;
                    throw new Exception($"拷贝文件【{name}】失败!");
                }

                var sourcePath = Path.Combine(Application.StartupPath,
                    string.IsNullOrEmpty(source) ? string.Empty : source, name);
                if (!File.Exists(sourcePath))
                {
                    throw new Exception($"找不到指定目录【{sourcePath}】。");
                }
                var targetPath = Path.Combine(Application.StartupPath,
                    string.IsNullOrEmpty(target) ? string.Empty : target, name);
                File.Copy(sourcePath, targetPath, overwrite);
                return true;
            }
            catch (Exception e)
            {
                message = e.Message;
                return false;
            }

        }

        #endregion
        #region 注册文件
        /// <summary>
        /// 注册文件
        /// </summary>
        /// <param name="target"></param>
        /// <param name="name"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public static bool Register(string target, string name, ref string message)
        {
            try
            {
                var path = Path.Combine(Application.StartupPath, target, name);
                if (File.Exists(path))
                {
                    Process.Start($"regsvr32.exe /s {path}");
                }
                return true;
            }
            catch (Exception e)
            {
                message = e.Message;
                return false;
            }
        }
        #endregion
        #region 反注册文件
        /// <summary>
        /// 反注册文件
        /// </summary>
        /// <param name="target"></param>
        /// <param name="name"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public static bool UnRegister(string target, string name, ref string message)
        {
            try
            {
                var path = Path.Combine(Application.StartupPath, target, name);
                if (File.Exists(path))
                {
                    Process.Start($"regsvr32.exe /u /s {path}");
                }
                return true;
            }
            catch (Exception e)
            {
                message = e.Message;
                return false;
            }
        }
        #endregion
        #region 新建文件

        /// <summary>
        /// 新建文件
        /// </summary>
        /// <param name="target">目标文件夹</param>
        /// <param name="name">文件名</param>
        /// <param name="message"></param>
        /// <returns></returns>
        public static bool NewFile(string target, string name, ref string message)
        {
            try
            {
                if (target == null)
                {
                    target = string.Empty;
                }
                if (string.IsNullOrEmpty(name))
                {
                    name = string.IsNullOrEmpty(name) ? "未知的文件名" : name;
                    throw new Exception($"新建文件【{name}】失败!");
                }
                var path = Path.Combine(Application.StartupPath, target, name);

                if (Path.GetDirectoryName(path) == null)
                {
                    if (!MakeDir(target, ref message))
                    {
                        throw new Exception(message);
                    }
                }
                using (var fi = File.Create(path))
                {

                }
                return true;
            }
            catch (Exception e)
            {
                message = e.Message;
                return false;
            }
        }

        #endregion
        #region 删除文件
        /// <summary>
        /// 删除文件
        /// </summary>
        /// <param name="target"></param>
        /// <param name="name"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public static bool DeleteFile(string target, string name, ref string message)
        {
            try
            {
                var path = Path.Combine(Application.StartupPath, target, name);
                if (File.Exists(path))
                {
                    File.Delete(path);
                }
                return true;
            }
            catch (Exception e)
            {
                message = e.Message;
                return false;
            }
        }

        #endregion
        #region 创建文件夹
        /// <summary>
        /// 创建文件夹
        /// </summary>
        /// <param name="folder"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public static bool MakeDir(string folder,ref string message)
        {
            try
            {
                if (string.IsNullOrEmpty(folder)) return true;
                var path = Path.Combine(Application.StartupPath, folder);
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                return true;
            }
            catch (Exception e)
            {
                message = e.Message;
            }
            
            return false;
        }
        #endregion
        #region 删除文件夹
        /// <summary>
        /// 删除文件夹
        /// </summary>
        /// <param name="target"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public static bool RemoveDir(string target, ref string message)
        {
            try
            {
                if (string.IsNullOrEmpty(target)) return true;
                var path = Path.Combine(Application.StartupPath, target);
                if (Directory.Exists(path))
                {
                    Directory.Delete(path, true);
                }
                return true;
            }
            catch (Exception e)
            {
                message = e.Message;
                return false;
            }
        }

        #endregion
        #region 执行文件
        /// <summary>
        /// 执行文件
        /// </summary>
        /// <param name="target"></param>
        /// <param name="name"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public static bool Execute(string target, string name, ref string message)
        {
            try
            {
                var path = Path.Combine(Application.StartupPath, target, name);
                if (File.Exists(path))
                {
                    Process.Start($"{path}");
                }
                return true;
            }
            catch (Exception e)
            {
                message = e.Message;
                return false;
            }
        }

        #endregion
        #region 加密解密
        /// <summary>
        /// MD5加密方法，返回大写的结果
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string Md5(string str)
        {
            if (string.IsNullOrEmpty(str)) return str;
            var md5 = System.Security.Cryptography.MD5.Create();
            var encoded = BitConverter.ToString(md5.ComputeHash(Encoding.UTF8.GetBytes(str))).Replace("-", "");
            return encoded.ToUpper();
        }
        #endregion
        /// <summary>
        /// 启动调用的程序
        /// </summary>
        /// <param name="executablePath"></param>
        public static void StartProcess(string executablePath)
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = executablePath,
                Arguments = $"{Application.ProductName} {Application.ProductVersion} {Application.ExecutablePath}",
                CreateNoWindow = false
            });
        }
        
    }
    #region CheckResult

    /// <summary>
    /// 参数检测返回
    /// </summary>
    public class CheckResult
    {
        /// <summary>
        /// 检测返回，false退出当前程序
        /// </summary>
        public bool Success { get; set; } = false;

        /// <summary>
        /// 需要更新的版本列表
        /// </summary>
        public List<ProductVersion> NeedForUpdate { get; set; } = null;

        /// <summary>
        /// 产品名
        /// </summary>
        public string ProductName { get; set; } = string.Empty;

        /// <summary>
        /// 产品版本
        /// </summary>
        public string ProductVersion { get; set; } = string.Empty;

        /// <summary>
        /// 主程序启动程序
        /// </summary>
        public string ExecutablePath { get; set; } = string.Empty;
    }
    #endregion
    #region UpdateList
    /// <summary>
    /// 更新版本列表类
    /// </summary>
    [Serializable()]
    public class UpdateList
    {
        /// <summary>
        /// 可用的版本列表
        /// </summary>
        [XmlElement("Version")]
        public List<ProductVersion> Version;
    }
    /// <summary>
    /// 版本信息
    /// </summary>
    [Serializable()]
    public class ProductVersion
    {
        /// <summary>
        /// 服务器文件夹
        /// </summary>
        [XmlAttribute()]
        public string Folder;
        /// <summary>
        /// 版本号
        /// </summary>
        [XmlText()]
        public string Value;
        /// <summary>
        /// 忽略
        /// </summary>
        [XmlAttribute()]
        public bool Ignore { get; set; }
    }
    #endregion
    #region Update
    /// <summary>
    /// 更新版本操作类
    /// </summary>
    [Serializable]
    public class Update
    {
        /// <summary>
        /// 更新前准备工作
        /// </summary>
        /// <see cref="Work.Copy">拷贝文件</see>
        /// <see cref="Work.Register">注册文件</see>
        /// <see cref="Work.UnRegister">反注册文件</see>
        /// <see cref="Work.NewFile">新建文件</see>
        /// <see cref="Work.Delete">删除文件</see>
        /// <see cref="Work.MakeDir">创建目录</see>
        /// <see cref="Work.RemoveDir">删除目录</see>
        /// <see cref="Work.Execute">执行文件</see>
        public Work Preparation;

        /// <summary>
        /// 处理工作
        /// </summary>
        /// <see cref="Work.Download">下载文件</see>
        /// <see cref="Work.Register">注册文件</see>
        /// <see cref="Work.UnRegister">反注册文件</see>
        /// <see cref="Work.NewFile">新建文件</see>
        /// <see cref="Work.Delete">删除文件</see>
        /// <see cref="Work.MakeDir">创建目录</see>
        /// <see cref="Work.RemoveDir">删除目录</see>
        /// <see cref="Work.Execute">执行文件</see>
        public Work Handle;

        /// <summary>
        /// 更新成功后工作
        /// </summary>
        /// <see cref="Work.Register">注册文件</see>
        /// <see cref="Work.UnRegister">反注册文件</see>
        /// <see cref="Work.NewFile">新建文件</see>
        /// <see cref="Work.Delete">删除文件</see>
        /// <see cref="Work.MakeDir">创建目录</see>
        /// <see cref="Work.RemoveDir">删除目录</see>
        /// <see cref="Work.Execute">执行文件</see>
        public Work Success;

        /// <summary>
        /// 更新失败后回滚工作
        /// </summary>
        /// <see cref="Work.Copy">拷贝文件</see>
        /// <see cref="Work.Register">注册文件</see>
        /// <see cref="Work.UnRegister">反注册文件</see>
        /// <see cref="Work.NewFile">新建文件</see>
        /// <see cref="Work.Delete">删除文件</see>
        /// <see cref="Work.MakeDir">创建目录</see>
        /// <see cref="Work.RemoveDir">删除目录</see>
        /// <see cref="Work.Execute">执行文件</see>
        public Work Rollback;
        /// <summary>
        /// 工作数
        /// </summary>
        [XmlIgnore()]
        public int WorkCount
            =>
                (Preparation?.DocumentCount ?? 0) + (Handle?.DocumentCount ?? 0) + (Success?.DocumentCount ?? 0) +
                (Rollback?.DocumentCount ?? 0);
    }
    /// <summary>
    /// 工作
    /// </summary>
    [Serializable]
    public class Work
    {
        /// <summary>
        /// 拷贝文件
        /// </summary>
        /// <see cref="Document.SourceFolder"></see>
        /// <see cref="Document.TargetFolder"></see>
        /// <see cref="Document.Name"></see>
        [XmlElement("Copy")]
        public List<Document> Copy;
        /// <summary>
        /// 下载文件
        /// </summary>
        /// <see cref="Document.SourceFolder"></see>
        /// <see cref="Document.TargetFolder"></see>
        /// <see cref="Document.Name"></see>
        [XmlElement("Download")]
        public List<Document> Download;
        /// <summary>
        /// 注册文件
        /// </summary>
        /// <see cref="Document.TargetFolder"></see>
        /// <see cref="Document.Name"></see>
        [XmlElement("Register")]
        public List<Document> Register;
        /// <summary>
        /// 反注册
        /// </summary>
        /// <see cref="Document.TargetFolder"></see>
        /// <see cref="Document.Name"></see>
        [XmlElement("UnRegister")]
        public List<Document> UnRegister;
        /// <summary>
        /// 新建文件
        /// </summary>
        /// <see cref="Document.TargetFolder"></see>
        /// <see cref="Document.Name"></see>
        [XmlElement("New")]
        public List<Document> NewFile;
        /// <summary>
        /// 删除文件
        /// </summary>
        /// <see cref="Document.TargetFolder"></see>
        /// <see cref="Document.Name"></see>
        [XmlElement("Del")]
        public List<Document> Delete;
        /// <summary>
        /// 创建文件夹
        /// </summary>
        /// <see cref="Document.TargetFolder"></see>
        [XmlElement("Md")]
        public List<Document> MakeDir;
        /// <summary>
        /// 删除文件夹
        /// </summary>
        /// <see cref="Document.TargetFolder"></see>
        [XmlElement("Rd")]
        public List<Document> RemoveDir;
        /// <summary>
        /// 执行文件
        /// </summary>
        /// <see cref="Document.TargetFolder"></see>
        /// <see cref="Document.Name"></see>
        [XmlElement("Exec")]
        public List<Document> Execute;
        /// <summary>
        /// 文档数
        /// </summary>
        [XmlIgnore()]
        public int DocumentCount
            => (Copy?.Count ?? 0) + (Download?.Count ?? 0) + (Register?.Count ?? 0) + (UnRegister?.Count ?? 0) +
               (NewFile?.Count ?? 0) + (Delete?.Count ?? 0) + (MakeDir?.Count ?? 0) + (RemoveDir?.Count ?? 0) +
               (Execute?.Count ?? 0);
    }
    /// <summary>
    /// 文档
    /// </summary>
    [Serializable]
    public class Document
    {
        /// <summary>
        /// 源文件夹
        /// </summary>
        [XmlAttribute()]
        public string SourceFolder;
        /// <summary>
        /// 目标文件夹
        /// </summary>
        [XmlAttribute()]
        public string TargetFolder;
        /// <summary>
        /// 文件名
        /// </summary>
        [XmlAttribute()]
        public string Name;
    }
    #endregion
    #region Config
    /// <summary>
    /// 配置文件类
    /// </summary>
    public class Config
    {
        /// <summary>
        /// 各种Api设定
        /// </summary>
        [XmlElement("Api")]
        public List<Detail> Api { get; set; }
        /// <summary>
        /// 本地配置节点
        /// </summary>
        public SetDetail Setting { get; set; }
    }
    /// <summary>
    /// 配置明细
    /// </summary>
    public class Detail
    {
        /// <summary>
        /// 描述信息
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// 关键字
        /// </summary>
        public string Key { get; set; }
        /// <summary>
        /// 内容（json表达式）
        /// </summary>
        public string Value { get; set; }
    }
    /// <summary>
    /// 本地配置明细
    /// </summary>
    public class SetDetail
    {
        /// <summary>
        /// 各种本地配置
        /// </summary>
        /// <see cref="Detail"/>
        [XmlElement("Detail")]
        public List<Detail> Details { get; set; }
    }
    #endregion
}
