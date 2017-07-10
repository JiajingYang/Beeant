using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Beeant.Tool.Generator
{
    public class ReportGenerator : GeneratorBase
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
            var rootPath = $"{GetRootPath()}Domain\\Beeant.Domain.Reports\\{Module}\\";
            var di=new DirectoryInfo(rootPath);
            if(!di.Exists)
                di.Create();
            var file=new FileInfo($"{rootPath}{EntityName}Report.cs");
            if (!file.Exists)
                file.Create().Dispose();
            File.WriteAllText(file.FullName,GetContent());
            var csproj = $"{GetRootPath()}Domain\\Beeant.Domain.Reports\\Beeant.Domain.Reports.csproj";
            AppendCsproj(csproj, $"{Module}\\{EntityName}Report.cs");
        }
        
        /// <summary>
        /// 得到文本内容
        /// </summary>
        /// <returns></returns>
        protected virtual string GetContent()
        {
            var builder = new StringBuilder();
            builder.AppendLine("using System;");
            foreach (DataGridViewRow row in DataGridView.Rows)
            {
                if (row.Cells["Name"].Value==null)
                    continue;
                var value = row.Cells["Module"].Value.ToString();
                if (string.IsNullOrWhiteSpace(value))
                    continue;
                builder.AppendLine($"using Beeant.Domain.Entities.{value};");
            }
            builder.AppendLine("");
            builder.AppendLine($"namespace Beeant.Domain.Reports.{Module}");
            builder.AppendLine("{");
            builder.AppendLine("    /// <summary>");
            builder.AppendLine($"    /// {EntityNickname}");
            builder.AppendLine("    /// </summary>");
            builder.AppendLine("    [Serializable]");
            builder.AppendLine($"    public class {EntityName}BaseReport : BaseReport");
            builder.AppendLine("    {");
            foreach (DataGridViewRow row in DataGridView.Rows)
            {
                if (row.Cells["Name"].Value == null)
                    continue;
                if (!string.IsNullOrWhiteSpace(row.Cells["Redundancy"].Value.ToString()))
                    continue;
                var name = row.Cells["Name"].Value.ToString();
                var type = row.Cells["Type"].Value.ToString();
                if (name.EndsWith("Id"))
                {
                    type = $"{name.Replace("Id", "")}BaseReport";
                    name = name.Substring(0, name.Length - 2);
                }
                else if(!string.IsNullOrWhiteSpace(row.Cells["ManyName"].Value.ToString()) )
                    type = $"IList<{row.Cells["ManyName"].Value}BaseReport>";
                AppendPropertyName(builder, type, name, row.Cells["Nickname"].Value.ToString());
             
            }
            foreach (DataGridViewRow row in DataGridView.Rows)
            {
                if (row.Cells["Name"].Value == null)
                    continue;
                if (!string.IsNullOrWhiteSpace(row.Cells["Redundancy"].Value.ToString()))
                    continue;
                var name = row.Cells["Name"].Value.ToString();
                var nickname= row.Cells["Nickname"].Value.ToString();
                if ((bool) row.Cells["IsImage"].Value)
                {
                    builder.AppendLine("        /// <summary>");
                    builder.AppendLine($"        /// {nickname}全路径");
                    builder.AppendLine("        /// </summary>");
                    builder.AppendLine($"        public string Full{name} ");
                    builder.AppendLine("        {");
                    builder.AppendLine("            get { return this.GetFullFileName("+ name + "); }");
                    builder.AppendLine("        }");
                    AppendPropertyName(builder, "byte[]", $"{name.Substring(0, name.Length - 4)}Byte", $"{row.Cells["Nickname"].Value}文件流");
                    continue;
                }
                if ((bool)row.Cells["IsAttachment"].Value)
                {
                    builder.AppendLine("        /// <summary>");
                    builder.AppendLine($"        /// {nickname}下载地址");
                    builder.AppendLine("        /// </summary>");
                    builder.AppendLine($"        public string Down{name.Replace("Name","")}Url ");
                    builder.AppendLine("        {");
                    builder.AppendLine("            get { return this.GetDownLoadUrl(" + name + "); }");
                    builder.AppendLine("        }");
                    AppendPropertyName(builder, "byte[]", $"{name.Replace("Name","")}Byte", $"{row.Cells["Nickname"].Value}文件流");
                    continue;
                }
                if (!string.IsNullOrWhiteSpace(row.Cells["EnumType"].Value.ToString()))
                {
                    builder.AppendLine("        /// <summary>");
                    builder.AppendLine($"        /// {nickname}显示名称");
                    builder.AppendLine("        /// </summary>");
                    builder.AppendLine($"        public string {name}Name ");
                    builder.AppendLine("        {");
                    builder.AppendLine("            get { return name.GetName(); }");
                    builder.AppendLine("        }");
                    continue;
                }
                if (row.Cells["Type"].Value.ToString() == "bool")
                {
                    builder.AppendLine("        /// <summary>");
                    builder.AppendLine($"        /// {nickname}显示名称");
                    builder.AppendLine("        /// </summary>");
                    builder.AppendLine($"        public string {name}Name ");
                    builder.AppendLine("        {");
                    builder.AppendLine("            get { return this.GetStatusName("+ name + "); }");
                    builder.AppendLine("        }");
                    continue;
                }
            }
            builder.AppendLine("    }");
            builder.AppendLine("}");
            return builder.ToString();
        }
        /// <summary>
        ///添加属性
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="type"></param>
        /// <param name="name"></param>
        /// <param name="nickname"></param>
        protected virtual void AppendPropertyName(StringBuilder builder, string type, string name, string nickname)
        {
            builder.AppendLine("        /// <summary>");
            builder.AppendLine($"        /// {nickname}");
            builder.AppendLine("        /// </summary>");
            builder.Append($"        public {type} {name} ");
            builder.Append("{ get; set; }");
            builder.AppendLine("");
        }
    }
}
