﻿using Winner.Persistence;

namespace Beeant.Presentation.Admin.Erp.Basedata.Tag
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
        protected override void OnInit(System.EventArgs e)
        {
           
            base.OnInit(e);
        }
   
    }
}