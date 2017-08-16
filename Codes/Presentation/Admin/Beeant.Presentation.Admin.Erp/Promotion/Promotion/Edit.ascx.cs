using System;

namespace Beeant.Presentation.Admin.Erp.Promotion.Promotion
{
    public partial class Edit : System.Web.UI.UserControl
    {

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            if (!IsPostBack)
            {
                ddlTag.LoadData();
                ckMonths.LoadData();
                ckWeeks.LoadData();
            }
        }
    }
}