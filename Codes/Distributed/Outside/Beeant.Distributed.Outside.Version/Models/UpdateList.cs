using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Beeant.Distributed.Outside.Version.Models
{
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
        [XmlAttribute()]
        public string Value;
        /// <summary>
        /// 忽略
        /// </summary>
        [XmlAttribute()]
        public bool Ignore { get; set; }
    }
}
