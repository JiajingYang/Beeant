
using System;
using System.Linq;
using Beeant.Domain.Entities.Basedata;
using Winner.Persistence;
using Winner.Persistence.Linq;

namespace Beeant.Presentation.Admin.Erp.Basedata.Brand
{
    public partial class Edit : System.Web.UI.UserControl
    {
        public virtual SaveType UploaderSaveType
        {
            get { return Uploader1.SaveType; }
            set
            {
                Uploader1.SaveType = value;
            }
        }

       

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            if (!IsPostBack)
            {
                ddlTag.Query = new QueryInfo();
                ddlTag.Query.Query<TagEntity>().Where(it => it.Type == "Brand");
                ddlTag.LoadData();
            }
        }
    }
}