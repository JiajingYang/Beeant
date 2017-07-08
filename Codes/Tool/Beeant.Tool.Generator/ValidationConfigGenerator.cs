using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace Beeant.Tool.Generator
{
    public class ValidationConfigGenerator : GeneratorBase
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
            var rootPath = $"{GetRootPath()}Infrastructure\\Configuration\\Config\\Validation\\";
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
                AppendCsproj(csproj, $"Config\\Validation\\{Module}.config");
            }
            AppendValidation();
        }
        /// <summary>
        /// 添加
        /// </summary>
        protected virtual void AppendValidation()
        {
            var fileName = $"{GetRootPath()}Infrastructure\\Configuration\\Config\\Validation\\{Module}.config";
            var doc = new XmlDocument();
            doc.Load(fileName);
            XmlNode xmlNode = doc.SelectSingleNode("/configuration/Filter/XmlValidation");
            if (xmlNode == null)
                return;
            var builder=new StringBuilder(xmlNode.InnerXml);
            builder.AppendLine($"");
            builder.AppendLine($"      <!--{EntityNickname}-->");
            builder.AppendLine($"      <Model Name=\"Beeant.Domain.Entities.{Module}.{EntityName}Entity\">");
            foreach (DataGridViewRow row in DataGridView.Rows)
            {
                if (row.Cells["Name"].Value == null)
                    continue;
                if (!string.IsNullOrWhiteSpace(row.Cells["Redundancy"].Value.ToString()))
                    continue;
                if (!string.IsNullOrWhiteSpace(row.Cells["ManyName"].Value.ToString()))
                    continue;
                var name = row.Cells["Name"].Value.ToString();
                if (name.EndsWith("Id"))
                {
                    AppendValidateById(builder, row);
                    continue;
                }
                if (row.Cells["IsImage"].Value!=null && (bool)row.Cells["IsImage"].Value)
                {
                    AppendValidateByImage(builder, row);
                    continue;
                }
                if (row.Cells["IsAttachment"].Value != null && (bool)row.Cells["IsAttachment"].Value)
                {
                    AppendValidateByAttchment(builder, row);
                    continue;
                }
                var type = row.Cells["Type"].Value.ToString();
                switch (type)
                {
                    case "int": case "bigint":
                        AppendValidateByInt(builder,row); break;
                    case "string":
                        AppendValidateByString(builder, row); break;
                    case "decimal":
                        AppendValidateByDecimal(builder, row); break;
                    case "DateTime":
                        AppendValidateByDateTime(builder, row); break;
                    default:
                        AppendValidateByEnum(builder, row);
                        break;
                }
            }
            builder.AppendLine($"      </Model>");
            builder.Append("    ");
            xmlNode.InnerXml = builder.ToString();
            doc.Save(fileName);
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="row"></param>
        protected virtual void AppendValidateById(StringBuilder builder, DataGridViewRow row)
        {
            var name = row.Cells["Name"].Value.ToString();
            name = $"{name.Replace("Id", "")}.Id";
            var isModify = row.Cells["IsAllowModify"].Value == null || (bool)row.Cells["IsAllowModify"].Value;
            builder.AppendLine($"        <Property PropertyName=\"{name}\" Message=\"{row.Cells["Nickname"].Value}编号不能为空\">");
            builder.AppendLine($"          <Validation RuleName=\"PrimaryKey\"  ValidationType=\"{(isModify?"Add|Modify":"Add")}\"></Validation>");
            builder.AppendLine($"        </Property>");
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="row"></param>
        protected virtual void AppendValidateByString(StringBuilder builder, DataGridViewRow row)
        {
            var name = row.Cells["Name"].Value.ToString();
            var message = row.Cells["Nickname"].Value;
            var isRequiry = row.Cells["IsRequiry"].Value != null && (bool) row.Cells["IsRequiry"].Value;
            if (isRequiry)
            {
                message += "必填";
            }
            if (row.Cells["Length"].Value != null && !string.IsNullOrWhiteSpace(row.Cells["Length"].Value.ToString()))
            {
                message += "而且长不能不能超过" + row.Cells["Length"].Value;
            }
            builder.AppendLine($"        <Property PropertyName=\"{name}\" Message=\"{message}\">");
            builder.AppendLine($"          <Validation RuleName=\"LengthRange\" P0=\"{(isRequiry?1:0)}\" P1=\"{row.Cells["Length"].Value}\" ValidationType=\"Add|Modify\"></Validation>");
            builder.AppendLine($"        </Property>");
        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="row"></param>
        protected virtual void AppendValidateByDecimal(StringBuilder builder, DataGridViewRow row)
        {
            var name = row.Cells["Name"].Value.ToString();
            name = $"{name.Replace("Id", "")}.Id";
            var message = row.Cells["Nickname"].Value;
            var isModify = row.Cells["IsAllowModify"].Value == null || (bool)row.Cells["IsAllowModify"].Value;
            var isRequiry = row.Cells["IsRequiry"].Value != null && (bool)row.Cells["IsRequiry"].Value;
            var modifyName = isModify ? "Add|Modify" : "Add";
            if (isRequiry)
            {
                message += "必填";
            }
            builder.AppendLine($"        <Property PropertyName=\"{name}\" Message=\"{message}\">");
            if(isRequiry)
                builder.AppendLine($"          <Validation RuleName=\"Requiry\"  ValidationType=\"{modifyName}\"></Validation>");
            builder.AppendLine($"          <Validation RuleName=\"Float\"  P0=\"9\" P1=\"0\" P2=\"2\"  ValidationType=\"{modifyName}\"></Validation>");
            builder.AppendLine($"        </Property>");
        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="row"></param>
        protected virtual void AppendValidateByDateTime(StringBuilder builder, DataGridViewRow row)
        {
            var name = row.Cells["Name"].Value.ToString();
            name = $"{name.Replace("Id", "")}.Id";
            var message = row.Cells["Nickname"].Value;
            var isModify = row.Cells["IsAllowModify"].Value == null || (bool)row.Cells["IsAllowModify"].Value;
            var isRequiry = row.Cells["IsRequiry"].Value != null && (bool)row.Cells["IsRequiry"].Value;
            var modifyName = isModify ? "Add|Modify" : "Add";
            if (isRequiry)
            {
                message += "必填而且必选符合日期格式";
            }
            else
                message += "必选符合日期格式";
            builder.AppendLine($"        <Property PropertyName=\"{name}\" Message=\"{message}\">");
            if (isRequiry)
                builder.AppendLine($"          <Validation RuleName=\"Requiry\"  ValidationType=\"{modifyName}\"></Validation>");
            builder.AppendLine($"          <Validation RuleName=\"DateTime\"  ValidationType=\"{modifyName}\"></Validation>");
            builder.AppendLine($"        </Property>");
        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="row"></param>
        protected virtual void AppendValidateByInt(StringBuilder builder, DataGridViewRow row)
        {
            var name = row.Cells["Name"].Value.ToString();
            name = $"{name.Replace("Id", "")}.Id";
            var message = row.Cells["Nickname"].Value;
            var isModify = row.Cells["IsAllowModify"].Value == null || (bool)row.Cells["IsAllowModify"].Value;
            var isRequiry = row.Cells["IsRequiry"].Value != null && (bool)row.Cells["IsRequiry"].Value;
            var modifyName = isModify ? "Add|Modify" : "Add";
            if (isRequiry)
            {
                message += "必填";
            }
            builder.AppendLine($"        <Property PropertyName=\"{name}\" Message=\"{message}\">");
            if (isRequiry)
                builder.AppendLine($"          <Validation RuleName=\"Requiry\"  ValidationType=\"{modifyName}\"></Validation>");
            builder.AppendLine($"          <Validation RuleName=\"NoNegativeInteger\"  P0=\"0\" P1=\"9\" ValidationType=\"{modifyName}\"></Validation>");
            builder.AppendLine($"        </Property>");
        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="row"></param>
        protected virtual void AppendValidateByImage(StringBuilder builder, DataGridViewRow row)
        {
            var name = row.Cells["Name"].Value.ToString();
            var byteName = row.Cells["FileByteName"].Value.ToString();
            var nickname = row.Cells["Nickname"].Value;
            var isModify = row.Cells["IsAllowModify"].Value == null || (bool)row.Cells["IsAllowModify"].Value;
            var isRequiry = row.Cells["IsRequiry"].Value != null && (bool)row.Cells["IsRequiry"].Value;
            var modifyName = isModify ? "Add|Modify" : "Add";
            builder.AppendLine($"        <Property PropertyName=\"{name}\" Message=\"{nickname}扩展名只能为jpeg|jpg|png|gif|bmp\">");
            if (isRequiry)
            {
                builder.AppendLine($"          <Validation RuleName=\"LengthRange\" P0=\"1\" P1=\"120\" ValidationType=\"Add\"></Validation>");
                builder.AppendLine($"          <Validation RuleName=\"LengthRange\" P0=\"0\" P1=\"120\" ValidationType=\"Modify\"></Validation>");
            }
            else
            {
                builder.AppendLine($"          <Validation RuleName=\"LengthRange\" P0=\"0\" P1=\"120\" ValidationType=\"Add|Modify\"></Validation>");
            }
            builder.AppendLine($"          <Validation RuleName=\"Extension\" P0=\"jpeg|jpg|png|gif|bmp\" ValidationType=\"Add|Modify\"></Validation>");
            builder.AppendLine($"        </Property>");
            builder.AppendLine($"        <Property PropertyName=\"{byteName}\" Message=\"{nickname}大小必须小于500KB\">");
            if (isRequiry)
            {
                builder.AppendLine($"          <Validation  RuleName=\"ValueRange\" P0=\"1\" P1=\"512000\"  ValidationType=\"Add\"></Validation>");
                builder.AppendLine($"          <Validation RuleName=\"ValueRange\" P0=\"0\" P1=\"512000\" ValidationType=\"Modify\"></Validation>");
            }
            else
            {
                builder.AppendLine($"          <Validation RuleName=\"ValueRange\" P0=\"0\" P1=\"512000\" ValidationType=\"Add|Modify\"></Validation>");
            }
            builder.AppendLine($"        </Property>");
        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="row"></param>
        protected virtual void AppendValidateByAttchment(StringBuilder builder, DataGridViewRow row)
        {
            var name = row.Cells["Name"].Value.ToString();
            var byteName = row.Cells["FileByteName"].Value.ToString();
            var nickname = row.Cells["Nickname"].Value;
            var isModify = row.Cells["IsAllowModify"].Value == null || (bool)row.Cells["IsAllowModify"].Value;
            var isRequiry = row.Cells["IsRequiry"].Value != null && (bool)row.Cells["IsRequiry"].Value;
            var modifyName = isModify ? "Add|Modify" : "Add";
            builder.AppendLine($"        <Property PropertyName=\"{name}\" Message=\"{nickname}文件扩展名只能为zip|rar|doc|docx|txt|jpg|png|gif|bmp\">");
            if (isRequiry)
            {
                builder.AppendLine($"          <Validation RuleName=\"LengthRange\" P0=\"1\" P1=\"120\" ValidationType=\"Add\"></Validation>");
                builder.AppendLine($"          <Validation RuleName=\"LengthRange\" P0=\"0\" P1=\"120\" ValidationType=\"Modify\"></Validation>");
            }
            else
            {
                builder.AppendLine($"          <Validation RuleName=\"LengthRange\" P0=\"0\" P1=\"120\" ValidationType=\"Add|Modify\"></Validation>");
            }
            builder.AppendLine($"          <Validation RuleName=\"Extension\" P0=\"zip|rar|doc|docx|txt|jpg|png|gif|bmp\" ValidationType=\"Add|Modify\"></Validation>");
            builder.AppendLine($"        </Property>");
            builder.AppendLine($"        <Property PropertyName=\"{byteName}\" Message=\"{nickname}文件大小必须小于1MB\">");
            if (isRequiry)
            {
                builder.AppendLine($"          <Validation  RuleName=\"ValueRange\" P0=\"1\" P1=\"1048576\"  ValidationType=\"Add\"></Validation>");
                builder.AppendLine($"          <Validation RuleName=\"ValueRange\" P0=\"0\" P1=\"1048576\" ValidationType=\"Modify\"></Validation>");
            }
            else
            {
                builder.AppendLine($"          <Validation RuleName=\"ValueRange\" P0=\"0\" P1=\"1048576\" ValidationType=\"Add|Modify\"></Validation>");
            }
            builder.AppendLine($"        </Property>");
        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="row"></param>
        protected virtual void AppendValidateByEnum(StringBuilder builder, DataGridViewRow row)
        {
            var name = row.Cells["Name"].Value.ToString();
            name = $"{name.Replace("Id", "")}.Id";
            var nickname = row.Cells["Nickname"].Value;
            var isModify = row.Cells["IsAllowModify"].Value == null || (bool)row.Cells["IsAllowModify"].Value;
            var isRequiry = row.Cells["IsRequiry"].Value != null && (bool)row.Cells["IsRequiry"].Value;
            var modifyName = isModify ? "Add|Modify" : "Add";
            if(!isRequiry)
                return;
            builder.AppendLine($"        <Property PropertyName=\"{name}\" Message=\"{nickname}必选\">");
            builder.AppendLine($"          <Validation RuleName=\"Requiry\" ValidationType=\"{modifyName}\"></Validation>");
            builder.AppendLine($"        </Property>");
            builder.AppendLine($"        <Property PropertyName=\"{name}Name\" Message=\"{nickname}必选\">");
            builder.AppendLine($"          <Validation RuleName=\"Requiry\" ValidationType=\"{modifyName}\"></Validation>");
            builder.AppendLine($"        </Property>");
        }
        /// <summary>
        /// 添加路径
        /// </summary>
        protected virtual void AppendFilePath()
        {
            var fileName = $"{GetRootPath()}Infrastructure\\Configuration\\Config\\Validation.config";
            var doc = new XmlDocument();
            doc.Load(fileName);
            XmlNode xmlNode = doc.SelectSingleNode("/configuration/Filter/XmlValidation");
            if (xmlNode == null)
                return;
            var domainNode = doc.CreateElement("RulePath");
            domainNode.SetAttribute("Path", $"config\\Validation\\{Module}.config");
            xmlNode.InsertBefore(domainNode, xmlNode.ChildNodes[xmlNode.ChildNodes.Count - 1]);
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
            builder.AppendLine("  <Filter>");
            builder.AppendLine("    </XmlValidation>");
            builder.AppendLine("    </XmlValidation>");
            builder.AppendLine("  </Filter>");
            builder.AppendLine("</configuration>");
            return builder.ToString();
        }
        
    }
}
