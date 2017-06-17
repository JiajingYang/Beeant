﻿using Beeant.Domain.Entities.Cms;
using Beeant.Basic.Services.WebForm.Pages;

namespace Beeant.Presentation.Admin.Cms.Cms.Postcard
{
    public partial class Update : UpdatePageBase<PostcardEntity>
    {
        public override bool IsUpdatePanel
        {
            get
            {
                return false;
            }
            set
            {
                base.IsUpdatePanel = value;
            }
        }
     
    }
}