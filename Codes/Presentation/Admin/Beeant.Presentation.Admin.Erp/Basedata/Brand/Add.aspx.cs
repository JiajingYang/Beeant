using Beeant.Domain.Entities.Basedata;
using Beeant.Basic.Services.WebForm.Pages;

namespace Beeant.Presentation.Admin.Erp.Basedata.Brand
{
    public partial class Add : AddPageBase<BrandEntity>
    {
        public override bool IsUpdatePanel
        {
            get { return false; }
            set
            {
                base.IsUpdatePanel = value;
            }
        }

        protected override BrandEntity FillEntity()
        {
            var info = base.FillEntity();
 
            return info;
        }
    }
}