using Beeant.Domain.Entities.Basedata;
using Beeant.Basic.Services.WebForm.Pages;

namespace Beeant.Presentation.Admin.Erp.Basedata.Tag
{
    public partial class List : ListPageBase<TagEntity>
    {

        protected override void Page_Load(object sender, System.EventArgs e)
        {
      
            base.Page_Load(sender, e);
        }
    }
}