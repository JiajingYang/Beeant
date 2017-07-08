using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace Beeant.Tool.Generator
{
    public class EntityConfigGenerator : GeneratorBase
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
                AppendCsproj(csproj, $"Config\\Entity\\{Module}.config");
            }
            AppendEntity();
        }
        /// <summary>
        /// 添加
        /// </summary>
        protected virtual void AppendEntity()
        {
            var fileName = $"{GetRootPath()}Infrastructure\\Configuration\\Config\\Entity\\{Module}.config";
            var doc = new XmlDocument();
            doc.Load(fileName);
            XmlNode xmlNode = doc.SelectSingleNode("/configuration/Persistence/XmlOrm/Map");
            if (xmlNode == null)
                return;
            var builder=new StringBuilder(xmlNode.InnerXml);
            builder.AppendLine($"");
            builder.AppendLine($"        <!--{EntityNickname}-->");
            builder.AppendLine($"        <Object ObjectName=\"Beeant.Domain.Entities.{Module}.{EntityName}Entity,Beeant.Domain.Entities\" GetDataBase=\"Beeant{Module}Read\" SetDataBase=\"Beeant{Module}Write\" NickObjectName=\"{Module}.{EntityName}Entity\" SetTableName=\"t_{Module}_{EntityName}\" GetTableName=\"t_{Module}_{EntityName}\"   SetDefaultWhere=\"Mark>0\" GetDefaultWhere=\"Mark>0\" RemoveMark=\"Mark=0\">");
            builder.AppendLine($"          <Property PropertyName=\"Id\"  FieldName=\"Id\" IsPrimaryKey=\"true\" IsIdentityKey=\"true\" ></Property>");
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
            builder.AppendLine($"          <Property PropertyName=\"InsertTime\" FieldName=\"InsertTime\" OperatorMode=\"Add|Read\"></Property>");
            builder.AppendLine($"          <Property PropertyName=\"UpdateTime\" FieldName=\"UpdateTime\"></Property>");
            builder.AppendLine($"          <Property PropertyName=\"DeleteTime\" FieldName=\"DeleteTime\" OperatorMode=\"Add|Remove|Read\"></Property>");
            builder.AppendLine($"          <Property PropertyName=\"Mark\" FieldName=\"Mark\"></Property>");
            builder.AppendLine($"          <Property PropertyName=\"Version\" FieldName=\"Version\" IsVersion=\"true\"></Property>");
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
            domainNode.SetAttribute("Path", $"config\\Entity\\{Module}.config");
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
