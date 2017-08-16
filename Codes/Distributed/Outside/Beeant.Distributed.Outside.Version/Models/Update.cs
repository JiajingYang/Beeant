using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Beeant.Distributed.Outside.Version.Models
{
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
        [XmlIgnore()]
        public int WorkCount
        {
            get
            {
                return (Preparation == null ? 0 : Preparation.DocumentCount) + (Handle == null ? 0 : Handle.DocumentCount) + (Success == null ? 0 : Success.DocumentCount) + (Rollback == null ? 0 : Rollback.DocumentCount);
            }
        }
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
        [XmlIgnore()]
        public int DocumentCount
        {
            get
            {
                return (Copy == null ? 0 : Copy.Count) + (Download == null ? 0 : Download.Count) + (Register == null ? 0 : Register.Count) + (UnRegister == null ? 0 : UnRegister.Count) + (NewFile == null ? 0 : NewFile.Count) + (Delete == null ? 0 : Delete.Count) + (MakeDir == null ? 0 : MakeDir.Count) + (RemoveDir == null ? 0 : RemoveDir.Count) + (Execute == null ? 0 : Execute.Count);
            }
        }
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
}
