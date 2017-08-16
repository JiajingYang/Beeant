using System.IO;
using System.Windows.Forms;
using System.Xml;

namespace Beeant.Tool.Generator
{
    public class GeneratorBase
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual DataGridView DataGridView { get; set; }
        /// <summary>
        /// 实体名称
        /// </summary>
        public virtual string EntityName { get; set; }
        /// <summary>
        /// 实体名称
        /// </summary>
        public virtual string EntityNickname { get; set; }
        /// <summary>
        /// 实体名称
        /// </summary>
        public virtual string Module { get; set; }
        /// <summary>
        /// 生成代码
        /// </summary>
        public virtual void Generate()
        {
            
        }
        /// <summary>
        /// 得到根目录
        /// </summary>
        /// <returns></returns>
        protected virtual string GetRootPath()
        {
            var tag = @"\Codes\";
            var path = Directory.GetCurrentDirectory();
            var index = path.IndexOf(tag);
            if (index == -1)
                return null;
            return path.Substring(0, index + tag.Length);
        }
        /// <summary>
        /// 添加文件
        /// </summary>
        /// <param name="csproj"></param>
        /// <param name="fileName"></param>
        protected virtual void AppendCsproj(string csproj, string fileName)
        {
            var doc = new XmlDocument();
            doc.Load(csproj);
            foreach (XmlNode childNode in doc.ChildNodes[1].ChildNodes[4].ChildNodes)
            {
                if(childNode.Attributes["Include"].Value== fileName)
                    return;
            }
            XmlNode xmlNode = doc.ChildNodes[1].ChildNodes[4].ChildNodes[0];
            if(xmlNode==null)
                return;
            var newNode = xmlNode.Clone();
            newNode.Attributes["Include"].Value = fileName;
            xmlNode.ParentNode.AppendChild(newNode);
            doc.Save(csproj);
            
        }

    }
}
