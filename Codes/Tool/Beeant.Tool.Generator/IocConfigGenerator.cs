using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace Beeant.Tool.Generator
{
    public class IocConfigGenerator : GeneratorBase
    {
        public override void Generate()
        {
            CreateFile();
        }
        /// <summary>
        /// 创建
        /// </summary>
        protected virtual void CreateFile()
        {
            var rootPath = $"{GetRootPath()}Infrastructure\\Configuration\\Config\\Entity\\";
            var di=new DirectoryInfo(rootPath);
            if(!di.Exists)
                di.Create();
            var file=new FileInfo($"{rootPath}{Module}.config");
            if (!file.Exists)
            {
                file.Create().Dispose();
                File.WriteAllText(file.FullName, GetContent());
                AppendFilePath();
                var csproj = $"{GetRootPath()}Infrastructure\\Configuration\\Configuration.csproj";
                AppendCsproj(csproj, $"Config\\Ioc\\{Module}.config");
            }
            AppendIoc();
        }
        /// <summary>
        /// 添加
        /// </summary>
        protected virtual void AppendIoc()
        {
            var fileName = $"{GetRootPath()}Infrastructure\\Configuration\\Config\\Ioc\\{Module}.config";
            var doc = new XmlDocument();
            doc.Load(fileName);
            XmlNode xmlNode = doc.SelectSingleNode("/configuration/Creation/XmlFactory/Ioc");
            if (xmlNode == null)
                return;
            var builder=new StringBuilder(xmlNode.InnerXml);
            builder.AppendLine($"");
            builder.AppendLine($"        <!--{EntityNickname}-->");
            builder.AppendLine($"        <Instance Name=\"Beeant.Domain.Services.IDomainService, Beeant.Domain.Entities.{Module}.{EntityName}Entity\" ClassName=\"Beeant.Domain.Services.{Module}.{EntityName}DomainService, Beeant.Domain.Services\" >");
            builder.AppendLine($"          <Property Name=\"Repository\" Value=\"Beeant.Domain.Services.IRepository\"></Property>");
            foreach (DataGridViewRow row in DataGridView.Rows)
            {
                if (row.Cells["Name"].Value == null)
                    continue;
                if (!string.IsNullOrWhiteSpace(row.Cells["Redundancy"].Value.ToString()))
                    continue;
                var name = row.Cells["Name"].Value.ToString();
                var type = "";
                if (name.EndsWith("Id"))
                {
                    type = $"{name.Replace("Id", "")}";
                }
                else if (!string.IsNullOrWhiteSpace(row.Cells["ManyName"].Value.ToString()))
                    type = $"{row.Cells["ManyName"].Value}";
                if (string.IsNullOrWhiteSpace(type))
                    continue;
                var module= !string.IsNullOrWhiteSpace(row.Cells["Module"].Value.ToString())? row.Cells["Module"].Value.ToString():Module;
                builder.AppendLine($"          <Property Name=\"{type}DomainService\" Value=\"Beeant.Domain.Services.IDomainService, Beeant.Domain.Entities.{module}.{type}Entity\"></Property>");
            }
            builder.AppendLine($"        </Instance>");
            builder.AppendLine($"        <Instance Name=\"Beeant.Application.Services.IApplicationService, Beeant.Domain.Entities.{Module}.{EntityName}Entity\" ClassName=\"Beeant.Application.Services.{Module}.{EntityName}ApplicationService, Beeant.Application.Services\" >");
            builder.AppendLine($"          <Property Name=\"Repository\" Value=\"Beeant.Domain.Services.IRepository\"></Property>");
            builder.AppendLine($"          <Property Name=\"DomainService\" Value=\"Beeant.Domain.Services.IDomainService, Beeant.Domain.Entities.{Module}.{EntityName}Entity\"></Property>");
            builder.AppendLine($"        </Instance>");
            builder.Append("      ");
            xmlNode.InnerXml = builder.ToString();
            doc.Save(fileName);
        }
      
        /// <summary>
        /// 添加路径
        /// </summary>
        protected virtual void AppendFilePath()
        {
            var fileName = $"{GetRootPath()}Infrastructure\\Configuration\\Config\\Ioc.config";
            var doc = new XmlDocument();
            doc.Load(fileName);
            XmlNode xmlNode = doc.SelectSingleNode("/configuration/Creation/Ioc");
            if (xmlNode == null)
                return;
            var domainNode = doc.CreateElement("Instance");
            domainNode.SetAttribute("Name", $"config\\ioc\\{Module}.config");
            doc.Save(fileName);
        }
        /// <summary>
        /// 得到文本内容
        /// </summary>
        /// <returns></returns>
        protected virtual string GetContent()
        {
            var builder = new StringBuilder();
            builder.AppendLine("<?xml version=\"1.0\" encoding=\"utf-8\" ?>");
            builder.AppendLine("<configuration>");
            builder.AppendLine("  <Creation>");
            builder.AppendLine("    <XmlFactory>");
            builder.AppendLine("      <Ioc>");
            builder.AppendLine("      </Ioc>");
            builder.AppendLine("    </XmlFactory>");
            builder.AppendLine("  </Creation>");
            builder.AppendLine("</configuration>");
            return builder.ToString();
        }
        
    }
}
