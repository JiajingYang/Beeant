using System.IO;
using System.Text;

namespace Beeant.Tool.Generator
{
    public class ApplicationGenerator : GeneratorBase
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
            var rootPath = $"{GetRootPath()}Application\\Beeant.Application.Services\\{Module}\\";
            var di=new DirectoryInfo(rootPath);
            if(!di.Exists)
                di.Create();
            var file=new FileInfo($"{rootPath}{EntityName}ApplicationService.cs");
            if (!file.Exists)
                file.Create().Dispose();
            File.WriteAllText(file.FullName,GetContent());
            var csproj = $"{GetRootPath()}Application\\Beeant.Application.Services\\Beeant.Application.Services.csproj";
            AppendCsproj(csproj, $"{Module}\\{EntityName}ApplicationService.cs");
        }
        
        /// <summary>
        /// 得到文本内容
        /// </summary>
        /// <returns></returns>
        protected virtual string GetContent()
        {
            var builder = new StringBuilder();
            builder.AppendLine("using System;");
            builder.AppendLine("using System.Collections.Generic;");
            builder.AppendLine($"using Beeant.Domain.Entities.{Module};");
            builder.AppendLine("");
            builder.AppendLine($"namespace Beeant.Application.Services.{Module}");
            builder.AppendLine("{");
            builder.AppendLine("    /// <summary>");
            builder.AppendLine($"    /// {EntityNickname}");
            builder.AppendLine("    /// </summary>");
            builder.AppendLine("    [Serializable]");
            builder.AppendLine($"    public class {EntityName}ApplicationService : RealizeApplicationService<{EntityName}Entity>");
            builder.AppendLine("    {");
            builder.AppendLine($"        private EventHandleCollection<{EntityName}Entity> _eventHandles ;");
            builder.AppendLine("        /// <summary>");
            builder.AppendLine($"        /// 事件处理");
            builder.AppendLine("        /// </summary>");
            builder.AppendLine($"        protected override EventHandleCollection<{EntityName}Entity> EventHandles");
            builder.AppendLine("        {");
            builder.AppendLine("            get");
            builder.AppendLine("            {");
            builder.AppendLine($"                return _eventHandles ?? (_eventHandles = new EventHandleCollection<{EntityName}Entity>");
            builder.AppendLine("                       (new List<EventHandle<OrderTestEntity>>");
            builder.AppendLine("                           {");
            builder.AppendLine("                           }");
            builder.AppendLine("                       ));");
            builder.AppendLine("            }");
            builder.AppendLine("            set");
            builder.AppendLine("            {");
            builder.AppendLine("                base.EventHandles = value;");
            builder.AppendLine("            }");
            builder.AppendLine("        }");
            builder.AppendLine("    }");
            builder.AppendLine("}");
            return builder.ToString();
        }
        
    }
}
