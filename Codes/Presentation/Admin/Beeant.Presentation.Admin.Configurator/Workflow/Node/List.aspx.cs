using System.Text;
using System.Web.UI.WebControls;
using Beeant.Domain.Entities;
using Beeant.Domain.Entities.Workflow;
using Beeant.Basic.Services.WebForm.Pages;
using Component.Extension;

namespace Beeant.Presentation.Admin.Configurator.Workflow.Node
{
    public partial class List : MaintenPageBase<NodeEntity>
    {

        protected override void Page_Load(object sender, System.EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlFlow.LoadData();
                ddlSearchFlow.LoadData();
                ddlAssignType.LoadData();
                ddlConditionType.LoadData();
                ddlNodeType.LoadData();
            } 
            base.Page_Load(sender, e);
        }
   

     
    }
}