using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Beeant.Tool.Generator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            LoadTableScheme();
        }
        /// <summary>
        /// 加载表结构
        /// </summary>
        protected virtual void LoadTableScheme()
        {
            dataGridView1.Rows.Clear();
            dataGridView1.ReadOnly = false;
            var dt= GetTableScheme();
            var entityName = GetEntityName();
            foreach (DataRow dr in dt.Rows)
            {
                txtEntityNickname.Text = dr["表说明"].ToString();
                var name = dr["列名"].ToString();
                if(name=="Id" || name=="InsertTime" || name=="UpdateTime" || name == "DeleteTime" || name == "Mark" ||  name == "Version")
                    continue;
                DataGridViewRow row =  new DataGridViewRow();
                var type = GetRowType(dr,name,entityName);
                var moduleName = "";
                if (name.EndsWith("Id") && name == "AccountId")
                    moduleName = "Account";
                row.Cells.Add(new DataGridViewTextBoxCell {Value = dr["列名"], ReadOnly = false});
                row.Cells.Add(new DataGridViewTextBoxCell { Value = dr["列说明"], ReadOnly = false });
                row.Cells.Add(new DataGridViewTextBoxCell { Value = type, ReadOnly = false });
                row.Cells.Add(new DataGridViewTextBoxCell { Value = dr["长度"], ReadOnly = false });
                row.Cells.Add(new DataGridViewCheckBoxCell { Value = name!="Remark" || name != "Detail", ReadOnly = false });
                row.Cells.Add(new DataGridViewTextBoxCell { Value =  name.EndsWith("FileName") ? name.Replace("Name", "Byte") : "", ReadOnly = false });
                row.Cells.Add(new DataGridViewTextBoxCell { Value = moduleName, ReadOnly = false });
                row.Cells.Add(new DataGridViewTextBoxCell { Value = "", ReadOnly = false });
                row.Cells.Add(new DataGridViewCheckBoxCell { Value = name.EndsWith("FileName"), ReadOnly = false });
                row.Cells.Add(new DataGridViewCheckBoxCell { Value = name.EndsWith("AttachmentName"), ReadOnly = false });
                row.Cells.Add(new DataGridViewTextBoxCell { Value = GetEnumType(dr,name,entityName), ReadOnly = false });
                row.Cells.Add(new DataGridViewTextBoxCell { Value = "", ReadOnly = false });
                dataGridView1.Rows.Add(row);
            }
        }

        /// <summary>
        /// 得到类型
        /// </summary>
        /// <param name="dr"></param>
        /// <param name="name"></param>
        /// <param name="entityName"></param>
        /// <returns></returns>
        protected virtual string GetRowType(DataRow dr,string name,string entityName)
        {
            var dbType = dr["数据库类型"].ToString().ToLower();
            if ((name.EndsWith("Type") || name.EndsWith("Status"))
                && dbType == "int" || dbType == "tinyint")
            {
                var typeName = name.EndsWith("Status") ? $"{name}Type" : "Type";
              return $"{entityName}{typeName}";
            }
            var type = "string";
            switch (dbType)
            {
                case "int":
                    type = "int"; break;
                case "bigint":
                    type = "long"; break;
                case "bit":
                    type = "bool"; break;
                case "decimal":
                    type = "decimal"; break;
                case "datetime":
                    type = "DateTime"; break;

            }
            return type;
        }
        /// <summary>
        /// 得到类型
        /// </summary>
        /// <param name="dr"></param>
        /// <param name="name"></param>
        /// <param name="entityName"></param>
        /// <returns></returns>
        protected virtual string GetEnumType(DataRow dr, string name, string entityName)
        {
            var dbType = dr["数据库类型"].ToString().ToLower();
            if ((name.EndsWith("Type") || name.EndsWith("Status"))
                && dbType == "int" || dbType == "tinyint")
            {
                var typeName = name.EndsWith("Status") ? $"{name}Type" : "Type";
                return $"{entityName}{typeName}";
            }
            return "";
        }
        /// <summary>
        /// 得到实体名称
        /// </summary>
        /// <returns></returns>
        protected virtual string GetEntityName()
        {
            var name = txtTable.Text;
            name = name.Substring(name.LastIndexOf("_") + 1);
            return name;
        }
        /// <summary>
        /// 得到实体名称
        /// </summary>
        /// <returns></returns>
        protected virtual string GetModuleName()
        {
            var name = txtTable.Text;
            name = name.Substring(0, name.LastIndexOf("_")).Replace("t_","");
            return name;
        }
        #region 得到表结构
        /// <summary>
        /// 得到表结构
        /// </summary>
        /// <returns></returns>
        protected virtual DataTable GetTableScheme()
        {
            var dt = new DataTable();
            try
            {
                var sql =
                    @"select  
     c.Name [表名], 
     isnull(f.[value],'') [表说明],  
     a.Column_id [列序号],  
     a.Name [列名],  
     isnull(e.[value],'') [列说明],  
     b.Name [数据库类型],    
     case when b.Name = 'image' then 'byte[]'
                  when b.Name in('image','uniqueidentifier','ntext','varchar','ntext','nchar','nvarchar','text','char') then 'string'
                  when b.Name in('tinyint','smallint','int','bigint') then 'int'
                  when b.Name in('datetime','smalldatetime') then 'DateTime'
                  when b.Name in('float','decimal','numeric','money','real','smallmoney') then 'decimal'
                  when b.Name ='bit' then 'bool' else b.name end [类型] ,
      case when is_identity=1 then '是' else '' end [标识],  
      case when exists(select 1 from sys.objects x join sys.indexes y on x.Type=N'PK' and x.Name=y.Name  
                         join sysindexkeys z on z.ID=a.Object_id and z.indid=y.index_id and z.Colid=a.Column_id)  
                     then '是' else '' end [主键],       
     case when a.[max_length]=-1 and b.Name!='xml' then 'max/2G'  
                   when b.Name='xml' then '2^31-1字节/2G' 
                   else rtrim(a.[max_length]) end [字节数],  
     case when ColumnProperty(a.object_id,a.Name,'Precision')=-1 then '2^31-1' 
                 else rtrim(ColumnProperty(a.object_id,a.Name,'Precision')) end [长度],  
     isnull(ColumnProperty(a.object_id,a.Name,'Scale'),0) [小数位],  
     case when a.is_nullable=1 then '是' else '' end [是否为空],      
     isnull(d.text,'') [默认值]      
 from  
     sys.columns a   
 left join 
     sys.types b on a.user_type_id=b.user_type_id  
 inner join 
     sys.objects c on a.object_id=c.object_id and c.Type='U' and c.name='" + txtTable.Text + @"'
 left join 
     syscomments d on a.default_object_id=d.ID  
 left join 
     sys.extended_properties e on e.major_id=c.object_id and e.minor_id=a.Column_id and e.class=1   
 left join 
     sys.extended_properties f on f.major_id=c.object_id and f.minor_id=0 and f.class=1 ";
                using (SqlConnection con = new SqlConnection(txtSqlCon.Text))
                {
                    SqlCommand cmd = new SqlCommand(sql, con);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {

            }
            return dt;
        }
        #endregion

        private void button2_Click(object sender, EventArgs e)
        {
            Generate();
        }

        protected virtual void Generate()
        {
            try
            {
                if (dataGridView1.Rows.Count == 0)
                {
                    MessageBox.Show("没有生成的属性");
                    return;
                }
                var entity = new EntityGenerator { DataGridView = dataGridView1, EntityName = GetEntityName(), Module = GetModuleName(), EntityNickname = txtEntityNickname.Text };
                var domain = new DomainGenerator { DataGridView = dataGridView1, EntityName = GetEntityName(), Module = GetModuleName(), EntityNickname = txtEntityNickname.Text };
                var application = new ApplicationGenerator { DataGridView = dataGridView1, EntityName = GetEntityName(), Module = GetModuleName(), EntityNickname = txtEntityNickname.Text };
                var iocConfig = new IocConfigGenerator { DataGridView = dataGridView1, EntityName = GetEntityName(), Module = GetModuleName(), EntityNickname = txtEntityNickname.Text };
                var entityConfig = new EntityConfigGenerator { DataGridView = dataGridView1, EntityName = GetEntityName(), Module = GetModuleName(), EntityNickname = txtEntityNickname.Text };
                var validationConfig = new ValidationConfigGenerator() { DataGridView = dataGridView1, EntityName = GetEntityName(), Module = GetModuleName(), EntityNickname = txtEntityNickname.Text };
                entity.Generate();
                domain.Generate();
                application.Generate();
                iocConfig.Generate();
                entityConfig.Generate();
                validationConfig.Generate();
                MessageBox.Show("生成成功");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           

        }
    }
}
