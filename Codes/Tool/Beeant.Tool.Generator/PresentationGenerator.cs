using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace Beeant.Tool.Generator
{
    public class PresentationGenerator : GeneratorBase
    {
        /// <summary>
        /// 模板路径
        /// </summary>
        public string Template { get; set; }
        /// <summary>
        /// 引用的项目文件
        /// </summary>
        public string Project { get; set; }
        public override void Generate()
        {
            CreateFile();
        }
        /// <summary>
        /// 创建
        /// </summary>
        protected virtual void CreateFile()
        {
            var rootPath = $"{GetRootPath()}Infrastructure\\Configuration\\Config\\Report\\";
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
                AppendCsproj(csproj, $"Config\\Report\\{Module}.config");
            }
            AppendEntity();
        }
        /// <summary>
        /// 添加
        /// </summary>
        protected virtual void AppendEntity()
        {
            var fileName = $"{GetRootPath()}Infrastructure\\Configuration\\Config\\Report\\{Module}.config";
            var doc = new XmlDocument();
            doc.Load(fileName);
            XmlNode xmlNode = doc.SelectSingleNode("/configuration/Persistence/XmlOrm/Map");
            if (xmlNode == null)
                return;
            var builder=new StringBuilder(xmlNode.InnerXml);
            builder.AppendLine($"");
            builder.AppendLine($"        <!--{EntityNickname}-->");
            builder.AppendLine($"        <Object ObjectName=\"Beeant.Domain.Entities.{Module}.{EntityName}Entity,Beeant.Domain.Entities\" GetDataBase=\"Beeant{Module}Report\" SetDataBase=\"Beeant{Module}Report\" NickObjectName=\"{Module}.{EntityName}Report\" SetTableName=\"r_{Module}_{EntityName}\" GetTableName=\"r_{Module}_{EntityName}\" >");
            foreach (DataGridViewRow row in DataGridView.Rows)
            {
                if (row.Cells["Name"].Value == null)
                    continue;
                if (!string.IsNullOrWhiteSpace(row.Cells["Redundancy"].Value.ToString()))
                    continue;
                if (!string.IsNullOrWhiteSpace(row.Cells["ManyName"].Value.ToString()))
                    continue;
                var name = row.Cells["Name"].Value.ToString();
                var pName = row.Cells["Name"].Value.ToString();
                if (name.EndsWith("Id"))
                {
                    pName = $"{name.Replace("Id", "")}.Id";
                }
                var isModify = row.Cells["IsAllowModify"].Value == null || (bool) row.Cells["IsAllowModify"].Value;
                builder.AppendLine($"          <Property PropertyName=\"{pName}\" FieldName=\"{name}\"{(!isModify? " OperatorMode=\"Add|Read\"":"")}></Property>");
            }
            foreach (DataGridViewRow row in DataGridView.Rows)
            {
                if (row.Cells["Name"].Value == null)
                    continue;
                if (!string.IsNullOrWhiteSpace(row.Cells["Redundancy"].Value.ToString()))
                    continue;
                var name = row.Cells["Name"].Value.ToString();
                var type = "";
                var isMany = false;
                if (name.EndsWith("Id"))
                {
                    type = $"{name.Replace("Id", "")}Entity";
                    name = name.Substring(0, name.Length - 2);
                }
                else if (!string.IsNullOrWhiteSpace(row.Cells["ManyName"].Value.ToString()))
                {
                    type = $"{row.Cells["ManyName"].Value}Entity";
                    isMany = true;
                }
                if(string.IsNullOrWhiteSpace(type))
                    continue;
                var module = !string.IsNullOrWhiteSpace(row.Cells["Module"].Value.ToString()) ? row.Cells["Module"].Value.ToString() : Module;
                var objectProperty = isMany ? "Id" : $"{name}.Id";
                var mapProperty = isMany ? $"{EntityName}.Id" : $"Id";
                builder.AppendLine($"          <Property PropertyName=\"{name}\">");
                builder.AppendLine($"            <MapObject Name=\"Beeant.Domain.Entities.{module}.{type}, Beeant.Domain.Entities\" ObjectProperty=\"{objectProperty}\" MapObjectProperty=\"{mapProperty}\"  IsAdd=\"false\"  IsModify=\"false\" IsRemove=\"{(Module==module && isMany?"true":"false")}\" IsRemote=\"{(Module != module? "true" : "false")}\" IsRestore=\"{(Module == module && isMany ? "true" : "false")}\"  MapType=\"{(isMany ? "OneToMany" : "OneToOne")}\" >");
                builder.AppendLine($"            </MapObject>");
                builder.AppendLine($"          </Property>");
            }
            builder.AppendLine($"        </Object>");
            builder.Append("      ");
            xmlNode.InnerXml = builder.ToString();
            doc.Save(fileName);
        }
      
        /// <summary>
        /// 添加路径
        /// </summary>
        protected virtual void AppendFilePath()
        {
            var fileName = $"{GetRootPath()}Infrastructure\\Configuration\\Config\\Orm.config";
            var doc = new XmlDocument();
            doc.Load(fileName);
            XmlNode xmlNode = doc.SelectSingleNode("/configuration/Persistence/XmlOrm/Model");
            if (xmlNode == null)
                return;
            var domainNode = doc.CreateElement("Path");
            domainNode.SetAttribute("Path", $"config\\Report\\{Module}.config");
            xmlNode.AppendChild(domainNode);
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
            builder.AppendLine("  <Persistence>");
            builder.AppendLine("    </XmlOrm>");
            builder.AppendLine("      <Map>");
            builder.AppendLine("      </Map>");
            builder.AppendLine("    </XmlOrm>");
            builder.AppendLine("  </Persistence>");
            builder.AppendLine("</configuration>");
            return builder.ToString();
        }
        
    }
}
