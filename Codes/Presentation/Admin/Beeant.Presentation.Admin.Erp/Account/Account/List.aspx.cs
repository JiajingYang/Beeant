using System;
using Beeant.Domain.Entities.Account;
using Beeant.Basic.Services.WebForm.Pages;
using Winner.Persistence;

namespace Beeant.Presentation.Admin.Erp.Account.Account
{
    public partial class List : ListPageBase<AccountEntity>
    {
        protected override void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtBeginInsertTime.Text = DateTime.Now.ToString("yyyy-MM-dd");
                txtEndInsertTime.Text = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd");
            }
            base.Page_Load(sender, e);
        }

        protected void btnIsUesd_Click(object sender, System.EventArgs e)
        {
            SaveEntities(SaveType.Modify, "修改成功", "修改失败", ddlIsUsed);
        }
     
    }
}