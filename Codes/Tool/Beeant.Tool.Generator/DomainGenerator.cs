using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Beeant.Tool.Generator
{
    public class DomainGenerator: GeneratorBase
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
            var rootPath = $"{GetRootPath()}Domain\\Beeant.Domain.Services\\{Module}\\";
            var di = new DirectoryInfo(rootPath);
            if (!di.Exists)
                di.Create();
            var file = new FileInfo($"{rootPath}{EntityName}DomainService.cs");
            if (!file.Exists)
                file.Create().Dispose();
            File.WriteAllText(file.FullName, GetContent());
            var csproj = $"{GetRootPath()}Domain\\Beeant.Domain.Services\\Beeant.Domain.Services.csproj";
            AppendCsproj(csproj, $"{Module}\\{EntityName}DomainService.cs");
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
            builder.AppendLine("using System.Linq;");
            builder.AppendLine("using Component.Extension;");
            builder.AppendLine("using Winner.Persistence;");
            builder.AppendLine("using Winner.Persistence.Linq;");
            builder.AppendLine("using Beeant.Domain.Entities;");
            builder.AppendLine("using Beeant.Domain.Entities.Utility;");
            builder.AppendLine($"using Beeant.Domain.Entities.{Module};");
            foreach (DataGridViewRow row in DataGridView.Rows)
            {
                var value = row.Cells["Module"].Value.ToString();
                if (string.IsNullOrWhiteSpace(value))
                    continue;
                builder.AppendLine($"using Beeant.Domain.Entities.{value};");
            }
            builder.AppendLine("");
            builder.AppendLine($"namespace Beeant.Domain.Services.{Module}");
            builder.AppendLine("{");
            builder.AppendLine("    /// <summary>");
            builder.AppendLine($"    /// {EntityNickname}");
            builder.AppendLine("    /// </summary>");
            builder.AppendLine("    [Serializable]");
            builder.AppendLine($"    public class {EntityName}DomainService : RealizeDomainService<{EntityName}Entity>");
            builder.AppendLine("    {");
            AppendFileProperty(builder);
            AppendItemHandlesProperty(builder);
            AppendItemLoaderProperty(builder);
            AppendValidateAddMothed(builder);
            AppendValidateModifyMothed(builder);
            AppendValidateRemoveMothed(builder);
            builder.AppendLine("    }");
            builder.AppendLine("}");
            return builder.ToString();
        }
        /// <summary>
        ///添加属性
        /// </summary>
        /// <param name="builder"></param>
        protected virtual void AppendItemLoaderProperty(StringBuilder builder)
        {
            builder.AppendLine("");
            builder.AppendLine($"        #region 加载相关属性");
            builder.AppendLine($"        private IDictionary<string, ItemLoader<{EntityName}Entity>> _itemLoaders;");
            builder.AppendLine("        /// <summary>");
            builder.AppendLine("        /// 加载相关属性");
            builder.AppendLine("        /// </summary>");
            builder.AppendLine($"        protected override IDictionary<string, ItemLoader<{EntityName}Entity>> ItemLoaders");
            builder.AppendLine("         {");
            builder.AppendLine("             get");
            builder.AppendLine("             {");
            builder.AppendLine($"                return _itemLoaders ?? (_itemLoaders = new Dictionary<string, ItemLoader<{EntityName}Entity>>");
            builder.AppendLine("                {");
            builder.AppendLine("                        {\"DataEntity\", LoadDataEntity},");
            var i = 0;
            foreach (DataGridViewRow row in DataGridView.Rows)
            {
                if (!string.IsNullOrWhiteSpace(row.Cells["Redundancy"].Value.ToString()))
                    continue;
                var name = row.Cells["Name"].Value.ToString();
                var type = "";
                if (name.EndsWith("Id"))
                {
                    type = $"{name.Replace("Id", "")}";
                    name = name.Substring(0, name.Length - 2);
                }
                else if (!string.IsNullOrWhiteSpace(row.Cells["ManyName"].Value.ToString()))
                    type = $"{row.Cells["ManyName"].Value}";
                if (string.IsNullOrWhiteSpace(type))
                    continue;
                builder.AppendLine("                        {\""+ name + "\", Load"+ name + "},");
                i++;
            }
            if (i > 0)
                builder.Remove(builder.Length - 3, 3).AppendLine("");
            builder.AppendLine("                });");
            builder.AppendLine("             }");
            builder.AppendLine("         }");
            builder.AppendLine("        /// <summary>");
            builder.AppendLine($"        ///加载实体副本");
            builder.AppendLine("        /// </summary>");
            builder.AppendLine($"       protected virtual void LoadDataEntity({EntityName}Entity entity)");
            builder.AppendLine("        {");
            builder.AppendLine("            if(entity.SaveType==SaveType.Add)return;");
            builder.AppendLine($"            entity.DataEntity = Repository.Get<{EntityName}Entity>(entity.Id); ");
            builder.AppendLine("        }");
            foreach (DataGridViewRow row in DataGridView.Rows)
            {
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
                builder.AppendLine("        /// <summary>");
                builder.AppendLine($"        ///加载 {row.Cells["Nickname"].Value}");
                builder.AppendLine("        /// </summary>");
                builder.AppendLine($"       protected virtual void Load{name.Substring(0, name.Length - 2)}({EntityName}Entity entity)");
                builder.AppendLine("        {");
                if (name == "DataEntity")
                {
                    builder.AppendLine("            if(entity.SaveType==SaveType.Add)return;");
                    builder.AppendLine($"            entity.DataEntity = Repository.Get<{EntityName}Entity>(entity.Id);");
                }
                else if (name.EndsWith("Id"))
                {
                    name = name.Substring(0, name.Length - 2);
                    builder.AppendLine($"            if (entity.SaveType == SaveType.Add && entity.{name} != null && entity.{name}.Id != 0)");
                    builder.AppendLine("            {");
                    builder.AppendLine($"                entity.{name} = entity.{name}.SaveType == SaveType.Add ? entity.{name} : Repository.Get<{type}Entity>(entity.{name}.Id);");
                    builder.AppendLine("            }");
                    builder.AppendLine("            else");
                    builder.AppendLine("            {");
                    builder.AppendLine("                LoadDataEntity(entity);");
                    builder.AppendLine("                if (entity.DataEntity != null)");
                    builder.AppendLine($"                    entity.{name} = Repository.Get<{type}Entity>(entity.DataEntity.{name}.Id);");
                    builder.AppendLine("            }");
                }
                else
                {
                    builder.AppendLine("            if(entity.SaveType==SaveType.Add)return;");
                    builder.AppendLine($"            var items = entity.{name} == null? null: entity.{name}.Where(it => it.SaveType == SaveType.Add).ToList(); ");
                    builder.AppendLine($"            var query = new QueryInfo();");
                    builder.AppendLine($"            query.Query<{type}Entity>().Where(it => it.{name}.Id == entity.Id);");
                    builder.AppendLine($"            entity.{name} = Repository.GetEntities<{type}Entity>(query);");
                    builder.AppendLine($"            if (entity.{name} != null)");
                    builder.AppendLine("            {");
                    builder.AppendLine($"                entity.{name} = entity.{name}.ToList();");
                    builder.AppendLine($"                entity.{name}.AddList(items);");
                    builder.AppendLine("            }");
                }
                builder.AppendLine("        }");
            }
            builder.AppendLine("        #endregion");

        }
        /// <summary>
        ///添加文件属性
        /// </summary>
        /// <param name="builder"></param>
        protected virtual void AppendFileProperty(StringBuilder builder)
        {
            builder.AppendLine("");
            var i = 0;
            builder.AppendLine($"        #region 文件属性");
            builder.AppendLine("        private IList<FileEntity> _fileProperties = new List<FileEntity>");
            builder.AppendLine("        {");
            foreach (DataGridViewRow row in DataGridView.Rows)
            {
                if (!string.IsNullOrWhiteSpace(row.Cells["Redundancy"].Value.ToString()))
                    continue;
                var byteName = row.Cells["FileByteName"].Value.ToString();
                if (string.IsNullOrWhiteSpace(byteName))
                    continue;
                var name = row.Cells["Name"].Value.ToString();
                builder.AppendLine("               new FileEntity {FilePropertyName = \""+name+"\",BytePropertyName = \""+ byteName + "\"},");
                i++;
            }
            if (i > 0)
                builder.Remove(builder.Length - 3, 3).AppendLine(""); ;
            builder.AppendLine("        };");
            builder.AppendLine("        /// <summary>");
            builder.AppendLine($"        /// 文件属性");
            builder.AppendLine("        /// </summary>");
            builder.AppendLine("        public override IList<FileEntity> FileProperties");
            builder.AppendLine("        {");
            builder.AppendLine("            get { return _fileProperties; }");
            builder.AppendLine("            set { _fileProperties = value; }");
            builder.AppendLine("        }");
            builder.AppendLine("        #endregion");
        }

        /// <summary>
        ///处理属性
        /// </summary>
        /// <param name="builder"></param>
        protected virtual void AppendItemHandlesProperty(StringBuilder builder)
        {
            builder.AppendLine("");
            builder.AppendLine($"        #region 聚合处理");
            foreach (DataGridViewRow row in DataGridView.Rows)
            {
                if (!string.IsNullOrWhiteSpace(row.Cells["Redundancy"].Value.ToString()))
                    continue;
                var name = row.Cells["Name"].Value.ToString();
                var type = "";
                if (name.EndsWith("Id"))
                {
                    type = $"{name.Replace("Id", "")}DomainService";
                }
                else if (!string.IsNullOrWhiteSpace(row.Cells["ManyName"].Value.ToString()))
                    type = $"{row.Cells["ManyName"].Value}DomainService";
                if (string.IsNullOrWhiteSpace(type))
                    continue;
                builder.AppendLine("        /// <summary>");
                builder.AppendLine($"        /// {row.Cells["Nickname"].Value}");
                builder.AppendLine("        /// </summary>");
                builder.Append($"        public IDomainService {type} ");
                builder.Append("{ get; set; }");
                builder.AppendLine("");
            }
            builder.AppendLine("        private IDictionary<string, IUnitofworkHandle> _itemHandles;");
            builder.AppendLine("        /// <summary>");
            builder.AppendLine("        /// 聚合处理");
            builder.AppendLine("        /// </summary>");
            builder.AppendLine("        protected override IDictionary<string, IUnitofworkHandle> ItemHandles");
            builder.AppendLine("        {");
            builder.AppendLine("            get");
            builder.AppendLine("            {");
            builder.AppendLine(
                "               return _itemHandles ?? (_itemHandles = new Dictionary<string, IUnitofworkHandle>");
            builder.AppendLine("               {");
            var i = 0;
            foreach (DataGridViewRow row in DataGridView.Rows)
            {
                if (!string.IsNullOrWhiteSpace(row.Cells["Redundancy"].Value.ToString()))
                    continue;
                var name = row.Cells["Name"].Value.ToString();
                var type = "";
                if (name.EndsWith("Id"))
                {
                    type = $"{name.Replace("Id", "")}";
                    name = name.Substring(0, name.Length - 2);
                }
                else if (!string.IsNullOrWhiteSpace(row.Cells["ManyName"].Value.ToString()))
                    type = $"{row.Cells["ManyName"].Value}";
                if (string.IsNullOrWhiteSpace(type))
                    continue;
                var appendValue = row.Cells["Module"].Value.ToString() == "Account" ? ",IsAppend=false" : "";
                if (row.Cells["Module"].Value.ToString() != Module)
                {
                    builder.AppendLine("                        {\"" + name + "\", new UnitofworkHandle<" + type + "Entity>{DomainService= " + type + "DomainService"+ appendValue + "}},");
                }
                else
                {
                    builder.AppendLine("                        {\"" + name + "\", new UnitofworkHandle<" + type + "Entity>{Repository= Repository" + appendValue + "}},");
                }
                i++;
           }
            if (i > 0)
                builder.Remove(builder.Length - 3, 3).AppendLine(""); 
            builder.AppendLine("               });");
            builder.AppendLine("            }");
            builder.AppendLine("        }");
            builder.AppendLine("        #endregion");
        }

        #region 添加验证
        /// <summary>
        ///添加验证方法
        /// </summary>
        /// <param name="builder"></param>
        protected virtual void AppendValidateAddMothed(StringBuilder builder)
        {
            builder.AppendLine("");
            builder.AppendLine($"        #region 验证新增方法");
            builder.AppendLine("        /// <summary>");
            builder.AppendLine($"        /// 重写添加验证");
            builder.AppendLine("        /// </summary>");
            builder.AppendLine($"        protected override bool ValidateAdd({EntityName}Entity entity)");
            builder.AppendLine("        {");
            builder.Append("            return ");
            var i = 0;
            foreach (DataGridViewRow row in DataGridView.Rows)
            {
                if (!string.IsNullOrWhiteSpace(row.Cells["Redundancy"].Value.ToString()))
                    continue;
                var name = row.Cells["Name"].Value.ToString();
                var type = "";
                if (name.EndsWith("Id"))
                {
                    type = $"{name.Replace("Id", "")}";
                    name = name.Substring(0, name.Length - 2);
                }
                if (!string.IsNullOrWhiteSpace(type))
                {
                    builder.Append($"Validate{name}(entity) &&");
                    i++;
                }
                else if (row.Cells["IsUnique"].Value!=null && (bool) row.Cells["IsUnique"].Value)
                {
                    builder.Append($"Validate{name}Exist(entity) &&");
                    i++;
                }
            
            }
            if (i > 0)
            {
                builder.Remove(builder.Length - 3, 3).AppendLine(";");
            }
            else
            {
                builder.AppendLine("true;");
            }
            builder.AppendLine("        }");
            foreach (DataGridViewRow row in DataGridView.Rows)
            {
                AppendValidateAddMothedById(builder, row);
            }
            foreach (DataGridViewRow row in DataGridView.Rows)
            {
                AppendValidateAddMothedByUnqiue(builder, row);
            }
          
           
            builder.AppendLine("        #endregion");
        }

        ///  <summary>
        /// 添加验证方法
        ///  </summary>
        ///  <param name="builder"></param>
        /// <param name="row"></param>
        protected virtual void AppendValidateAddMothedById(StringBuilder builder,DataGridViewRow row)
        {
            if (!string.IsNullOrWhiteSpace(row.Cells["Redundancy"].Value.ToString()))
                return;
            var name = row.Cells["Name"].Value.ToString();
            var type = "";
            if (name.EndsWith("Id"))
            {
                type = $"{name.Replace("Id", "")}";
                name = name.Substring(0, name.Length - 2);
            }
            if (string.IsNullOrWhiteSpace(type))
                return;
            var cloudProperty = GetCloudProperty();
            builder.AppendLine("        /// <summary>");
            builder.AppendLine($"        /// 验证{row.Cells["Nickname"].Value}");
            builder.AppendLine("        /// </summary>");
            builder.AppendLine($"        protected virtual bool Validate{name}({EntityName}Entity entity)");
            builder.AppendLine("        {");
            builder.AppendLine($"            if (!entity.HasSaveProperty(it => it.{name}.Id) || entity.{name} != null && entity.{name}.SaveType == SaveType.Add)");
            builder.AppendLine("                return true;");
            if (row.Cells["IsNull"].Value!=null && (bool)row.Cells["IsNull"].Value)
                builder.AppendLine($"            if (entity.{name} != null)");
            else
                builder.AppendLine($"            if (entity.{name} != null && entity.{name}.Id != 0)");
            builder.AppendLine("            {");
            builder.AppendLine($"                var {name.ToLower()} = Repository.Get<{name}Entity>(entity.{name}.Id);");
            if (!string.IsNullOrWhiteSpace(cloudProperty) && row.Cells["Module"].Value.ToString() == Module)
            {
                builder.AppendLine($"                if ({name.ToLower()} == null || {name.ToLower()}.{cloudProperty}==null || entity.{cloudProperty}==null || entity.{cloudProperty}.Id!={name.ToLower()}.{cloudProperty}.Id)");
            }
            else
            {
                builder.AppendLine($"                if ({name.ToLower()} == null)");
            }
            builder.AppendLine("                {");
            builder.AppendLine($"                    entity.AddErrorByName(typeof({name}Entity).FullName, \"NoExist\");");
            builder.AppendLine($"                    return false;");
            builder.AppendLine("                }");
            if (name == "Account" || cloudProperty== $"{name}.Id")
            {
                builder.AppendLine($"                if (!{name.ToLower()}.IsUsed)");
                builder.AppendLine("                {");
                builder.AppendLine($"                    entity.AddErrorByName(typeof({name}Entity).FullName, \"UnUsed\");");
                builder.AppendLine($"                    return false;");
                builder.AppendLine("                }");
            }
            builder.AppendLine("            return true;");
            builder.AppendLine("            }");
            builder.AppendLine($"            entity.AddErrorByName(typeof({name}Entity).FullName, \"NoExist\");");
            builder.AppendLine("            return false;");
            builder.AppendLine("        }");
        }

        ///  <summary>
        /// 添加验证方法
        ///  </summary>
        ///  <param name="builder"></param>
        /// <param name="row"></param>
        protected virtual void AppendValidateAddMothedByUnqiue(StringBuilder builder, DataGridViewRow row)
        {
            if (!string.IsNullOrWhiteSpace(row.Cells["Redundancy"].Value.ToString()))
                return;
            if(row.Cells["IsUnique"].Value==null || !(bool)row.Cells["IsUnique"].Value)
                return;
            var cloudProperty = GetCloudProperty();
            var name = row.Cells["Name"].Value.ToString();
            var pName = name;
            if (name.EndsWith("Id"))
            {
                name = name.Substring(0, name.Length - 2);
                pName = $"{name.Substring(0, name.Length - 2)}.Id";
            }
            builder.AppendLine("        /// <summary>");
            builder.AppendLine($"        /// 验证{row.Cells["Nickname"].Value}是否重复");
            builder.AppendLine("        /// </summary>");
            builder.AppendLine($"        protected virtual bool Validate{name}Exist({EntityName}Entity entity)");
            builder.AppendLine("        {");
            if (pName.EndsWith(".Id"))
            {
                builder.AppendLine($"            if (!entity.HasSaveProperty(it => it.{name}.Id) || entity.{name} != null && entity.{name}.SaveType == SaveType.Add)");
                builder.AppendLine("                return true;");
            }
            else
            {
                builder.AppendLine($"            if (!entity.HasSaveProperty(it => it.{pName}))");
                builder.AppendLine("                return true;");
            }
            builder.AppendLine("            var query = new QueryInfo{IsReturnCount=false,PageSize=1};");
            if (string.IsNullOrWhiteSpace(cloudProperty))
            {
                builder.AppendLine($"            query.Query<{EntityName}Entity>().Where(it => it.{pName} == entity.{pName})");
            }
            else
            {
                builder.AppendLine($"            query.Query<{EntityName}Entity>().Where(it => it.{pName} == entity.{pName} && it.{cloudProperty}.Id==entity.{cloudProperty}.Id)");
            }
            builder.AppendLine($"            .Select(it=>it.Id);;");
            builder.AppendLine($"            var entities = Repository.GetEntities<{EntityName}Entity>(query);");
            builder.AppendLine($"            if (entities != null && entities.Count > 0)");
            builder.AppendLine("            {");
            builder.AppendLine($"                entity.AddError(\"{name}Exist\");");
            builder.AppendLine($"                return false;");
            builder.AppendLine("            }");
            builder.AppendLine("            return true;");
            builder.AppendLine("        }");
        }

        #endregion

        #region 修改验证
        /// <summary>
        ///添加验证方法
        /// </summary>
        /// <param name="builder"></param>
        protected virtual void AppendValidateModifyMothed(StringBuilder builder)
        {
            builder.AppendLine("");
            builder.AppendLine($"        #region 验证编辑方法");
            builder.AppendLine("        /// <summary>");
            builder.AppendLine($"        /// 重写编辑验证");
            builder.AppendLine("        /// </summary>");
            builder.AppendLine($"        protected override bool ValidateModify({EntityName}Entity entity)");
            builder.AppendLine("        {");
            builder.AppendLine($"            var dataEntity = Repository.Get<{EntityName}Entity>(entity.Id);");
            builder.AppendLine("            if (dataEntity == null) return false;");
            builder.Append("            return ");
            var i = 0;
            foreach (DataGridViewRow row in DataGridView.Rows)
            {
                if (!string.IsNullOrWhiteSpace(row.Cells["Redundancy"].Value.ToString()))
                    continue;
                if (row.Cells["IsAllowModify"].Value == null || !(bool)row.Cells["IsAllowModify"].Value)
                    continue;
                var name = row.Cells["Name"].Value.ToString();
                var type = "";
                if (name.EndsWith("Id"))
                {
                    type = $"{name.Replace("Id", "")}";
                    name = name.Substring(0, name.Length - 2);
                }
                if (!string.IsNullOrWhiteSpace(type))
                {
                    builder.Append($"Validate{name}(entity,dataEntity) &&");
                    i++;
                }
                else if (row.Cells["IsUnique"].Value!=null &&(bool)row.Cells["IsUnique"].Value)
                {
                    builder.Append($"Validate{name}Exist(entity,dataEntity) &&");
                    i++;
                }
              
            }
            if (i > 0)
            {
                builder.Remove(builder.Length - 3, 3).AppendLine(";");
            }
            else
            {
                builder.AppendLine("true;");
            }
            builder.AppendLine("        }");
            foreach (DataGridViewRow row in DataGridView.Rows)
            {
                AppendValidateModifyMothedById(builder, row);
            }
            foreach (DataGridViewRow row in DataGridView.Rows)
            {
                AppendValidateModifyMothedByUnqiue(builder, row);
            }


            builder.AppendLine("        #endregion");
        }

        ///  <summary>
        /// 添加验证方法
        ///  </summary>
        ///  <param name="builder"></param>
        /// <param name="row"></param>
        protected virtual void AppendValidateModifyMothedById(StringBuilder builder, DataGridViewRow row)
        {
            if (!string.IsNullOrWhiteSpace(row.Cells["Redundancy"].Value.ToString()))
                return;
            if (row.Cells["IsAllowModify"].Value==null || !(bool)row.Cells["IsAllowModify"].Value)
                return;
            var name = row.Cells["Name"].Value.ToString();
            var type = "";
            if (name.EndsWith("Id"))
            {
                type = $"{name.Replace("Id", "")}";
                name = name.Substring(0, name.Length - 2);
            }
            if (string.IsNullOrWhiteSpace(type))
                return;
            var cloudProperty = GetCloudProperty();
            builder.AppendLine("        /// <summary>");
            builder.AppendLine($"        /// 验证{row.Cells["Nickname"].Value}");
            builder.AppendLine("        /// </summary>");
            builder.AppendLine($"        protected virtual bool Validate{name}({EntityName}Entity entity,{EntityName}Entity dataEntity)");
            builder.AppendLine("        {");
            builder.AppendLine($"            if (!entity.HasSaveProperty(it => it.{name}.Id) || entity.{name} != null && dataEntity.{name} != null && entity.{name}.Id == dataEntity.{name}.Id)");
            builder.AppendLine("                return true;");
            if (row.Cells["IsNull"].Value!=null && (bool)row.Cells["IsNull"].Value)
                builder.AppendLine($"            if (entity.{name} != null)");
            else
                builder.AppendLine($"            if (entity.{name} != null && entity.{name}.Id != 0)");
            builder.AppendLine("            {");
            builder.AppendLine($"                var {name.ToLower()} = Repository.Get<{name}Entity>(entity.{name}.Id);");
            if (!string.IsNullOrWhiteSpace(cloudProperty) && row.Cells["Module"].Value.ToString() == Module)
            {
                builder.AppendLine($"                if ({name.ToLower()} == null || {name.ToLower()}.{cloudProperty}==null || entity.{cloudProperty}==null || entity.{cloudProperty}.Id!={name.ToLower()}.{cloudProperty}.Id)");
            }
            else
            {
                builder.AppendLine($"                if ({name.ToLower()} == null)");
            }
            builder.AppendLine("                {");
            builder.AppendLine($"                    entity.AddErrorByName(typeof({name}Entity).FullName, \"NoExist\");");
            builder.AppendLine($"                    return false;");
            builder.AppendLine("                }");
            if (name == "Account" || cloudProperty == $"{name}.Id")
            {
                builder.AppendLine($"                if (!{name.ToLower()}.IsUsed)");
                builder.AppendLine("                {");
                builder.AppendLine($"                    entity.AddErrorByName(typeof({name}Entity).FullName, \"UnUsed\");");
                builder.AppendLine($"                    return false;");
                builder.AppendLine("                }");
            }
            builder.AppendLine("            return true;");
            builder.AppendLine("            }");
            builder.AppendLine($"            entity.AddErrorByName(typeof({name}Entity).FullName, \"NoExist\");");
            builder.AppendLine("            return false;");
            builder.AppendLine("        }");
        }

        ///  <summary>
        /// 添加验证方法
        ///  </summary>
        ///  <param name="builder"></param>
        /// <param name="row"></param>
        protected virtual void AppendValidateModifyMothedByUnqiue(StringBuilder builder, DataGridViewRow row)
        {
            if (!string.IsNullOrWhiteSpace(row.Cells["Redundancy"].Value.ToString()))
                return;
            if (row.Cells["IsUnique"].Value == null || !(bool)row.Cells["IsUnique"].Value)
                return;
            if (row.Cells["IsAllowModify"].Value == null || !(bool)row.Cells["IsAllowModify"].Value)
                return;
            var cloudProperty = GetCloudProperty();
            var name = row.Cells["Name"].Value.ToString();
            var pName = name;
            if (name.EndsWith("Id"))
            {
                name = name.Substring(0, name.Length - 2);
                pName = $"{name.Substring(0, name.Length - 2)}.Id";
            }
            builder.AppendLine("        /// <summary>");
            builder.AppendLine($"        /// 验证{row.Cells["Nickname"].Value}是否重复");
            builder.AppendLine("        /// </summary>");
            builder.AppendLine($"        protected virtual bool Validate{name}Exist({EntityName}Entity entity,{EntityName}Entity dataEntity)");
            builder.AppendLine("        {");
            if (pName.EndsWith(".Id"))
            {
                builder.AppendLine($"            if (!entity.HasSaveProperty(it => it.{name}.Id) || entity.{name} != null && dataEntity.{name} != null && entity.{name}.Id == dataEntity.{name}.Id)");
                builder.AppendLine("                return true;");
            }
            else
            {
                builder.AppendLine($"            if (!entity.HasSaveProperty(it => it.{pName}) || entity.{name}==dataEntity.{name})");
                builder.AppendLine("                return true;");
            }
            builder.AppendLine("            var query = new QueryInfo{IsReturnCount=false,PageSize=1};");
            if (string.IsNullOrWhiteSpace(cloudProperty))
            {
                builder.AppendLine($"            query.Query<{EntityName}Entity>().Where(it => it.{pName} == entity.{pName})");
            }
            else
            {
                builder.AppendLine($"            query.Query<{EntityName}Entity>().Where(it => it.{pName} == entity.{pName} && it.Id==entity.Id && it.{cloudProperty}.Id==entity.{cloudProperty}.Id)");
            }
            builder.AppendLine($"            .Select(it=>it.Id);;");
            builder.AppendLine($"            var entities = Repository.GetEntities<{EntityName}Entity>(query);");
            builder.AppendLine($"            if (entities != null && entities.Count > 0)");
            builder.AppendLine("            {");
            builder.AppendLine($"                entity.AddError(\"{name}Exist\");");
            builder.AppendLine($"                return false;");
            builder.AppendLine("            }");
            builder.AppendLine("            return true;");
            builder.AppendLine("        }");
        }

        #endregion

        #region 修改删除
        /// <summary>
        ///添加验证方法
        /// </summary>
        /// <param name="builder"></param>
        protected virtual void AppendValidateRemoveMothed(StringBuilder builder)
        {
            builder.AppendLine("");
            builder.AppendLine($"        #region 重写删除验证");
            builder.AppendLine("        /// <summary>");
            builder.AppendLine($"        /// 重写删除验证");
            builder.AppendLine("        /// </summary>");
            builder.AppendLine($"        protected override bool ValidateRemove({EntityName}Entity entity)");
            builder.AppendLine("        {");
            builder.Append("            return ");
            var i = 0;
            foreach (DataGridViewRow row in DataGridView.Rows)
            {
                if (!string.IsNullOrWhiteSpace(row.Cells["Redundancy"].Value.ToString()))
                    return;
                if (row.Cells["IsRemove"].Value == null || !(bool)row.Cells["IsRemove"].Value)
                    continue;
                var name = row.Cells["Name"].Value.ToString();
                if (name.EndsWith("Id"))
                {
                    name = name.Substring(0, name.Length - 2);
                }
                builder.Append($"Validate{name}Exist(entity) &&");
                i++;
            }
            if (i > 0)
            {
                builder.Remove(builder.Length - 3, 3).AppendLine(";");
            }
            else
            {
                builder.AppendLine("true;");
            }
            builder.AppendLine("        }");
            foreach (DataGridViewRow row in DataGridView.Rows)
            {
                AppendValidateRemoveMothed(builder, row);
            }
            builder.AppendLine("        #endregion");
        }

     
        ///  <summary>
        /// 添加验证方法
        ///  </summary>
        ///  <param name="builder"></param>
        /// <param name="row"></param>
        protected virtual void AppendValidateRemoveMothed(StringBuilder builder, DataGridViewRow row)
        {
            if (!string.IsNullOrWhiteSpace(row.Cells["Redundancy"].Value.ToString()))
                return;
            if (row.Cells["IsRemove"].Value == null || !(bool)row.Cells["IsRemove"].Value)
                return;
            var cloudProperty = GetCloudProperty();
            var name = row.Cells["Name"].Value.ToString();
            var type = "";
            if (name.EndsWith("Id"))
            {
                type = $"{name.Replace("Id", "")}";
                name = name.Substring(0, name.Length - 2);
            }
            if (string.IsNullOrWhiteSpace(type))
                return;
            builder.AppendLine("        /// <summary>");
            builder.AppendLine($"        /// 验证{row.Cells["Nickname"].Value}是否重复");
            builder.AppendLine("        /// </summary>");
            builder.AppendLine($"        protected virtual bool Validate{name}Exist({EntityName}Entity entity)");
            builder.AppendLine("        {");
            builder.AppendLine("            var query = new QueryInfo{IsReturnCount=false,PageSize=1};");
            if (string.IsNullOrWhiteSpace(cloudProperty))
            {
                builder.AppendLine($"            query.Query<{type}Entity>().Where(it => it.{EntityName}.Id == entity.Id)");
            }
            else
            {
                builder.AppendLine($"            query.Query<{type}Entity>().Where(it => it.{EntityName}.Id == entity.Id && it.{cloudProperty}.Id==entity.{cloudProperty}.Id)");
            }
            builder.AppendLine($"            .Select(it=>it.Id);;");
            builder.AppendLine($"            var entities = Repository.GetEntities<{type}Entity>(query);");
            builder.AppendLine($"            if (entities != null && entities.Count > 0)");
            builder.AppendLine("            {");
            builder.AppendLine($"                entity.AddError(\"Has{name}ExistNotAllowRemove\");");
            builder.AppendLine($"                return false;");
            builder.AppendLine("            }");
            builder.AppendLine("            return true;");
            builder.AppendLine("        }");
        }

        #endregion
        /// <summary>
        /// 得到
        /// </summary>
        /// <returns></returns>
        protected virtual string GetCloudProperty()
        {
            foreach (DataGridViewRow row in DataGridView.Rows)
            {
                if (row.Cells["IsCloud"].Value!=null &&　(bool)(row.Cells["IsCloud"].Value))
                    return row.Cells["Name"].Value.ToString().Replace("Id","");
            }
            return "";
        }
    }
}
