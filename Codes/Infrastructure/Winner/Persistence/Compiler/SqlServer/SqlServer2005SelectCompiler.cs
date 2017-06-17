﻿using System.Text;
using Winner.Persistence.Compiler.Common;
using Winner.Persistence.Relation;

namespace Winner.Persistence.Compiler.SqlServer
{
    public class SqlServer2005SelectCompiler : SelectCompiler
    {

        protected override string GetManyFieldName(OrmPropertyInfo property, string propertName, QueryCompilerInfo selectComplier, QueryCompilerInfo subSelectComplier)
        {
            var name = propertName.Replace(string.Format(".{0}", property.PropertyName), "");
            var feildName = selectComplier.GetFieldName(property.Map.ObjectProperty, name);
            if (subSelectComplier.SubQuery != null)
            {
                subSelectComplier.Chainon = string.Format("{0}.{1}={2}", "{0}",
                    property.Map.MapObjectProperty.FieldName, feildName);
            }
            var builder = new StringBuilder();
            builder.AppendFormat("(select {0} from {1} where {2}.{3}={4}", 
                             subSelectComplier.Builder, subSelectComplier.GetJoinTable()
               ,subSelectComplier.Table.AsName,
               property.Map.MapObjectProperty.FieldName, feildName);
            builder.AppendFormat(" for xml path('{0}'),TYPE)", propertName);
            return builder.ToString();
        }
    }
}
