using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Component.Extension;
using Dependent;
using Beeant.Application.Services.Utility;
using Beeant.Domain.Entities.Workflow;

using Beeant.Basic.Services.WebForm.Pages;
using Winner.Persistence;
using Winner.Persistence.Linq;

namespace Beeant.Presentation.Admin.Home.Ajax.Workflow
{
    public partial class Message : AjaxPageBase<MessageEntity>
    {
    
        protected override void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Request.QueryString["Id"]))
            {
                base.Page_Load(sender, e);
            }
           
        }
       

        protected override IList<MessageEntity> GetEntities()
        {
            var infos = new List<MessageEntity>();
            for (int i = 0; i < 10; i++)
            {
                 var info = Ioc.Resolve<IQueueApplicationService>().Pop<MessageEntity>(MessageEntity.GetMessageTag(Identity.Id));
                if (info == null) break;
                infos.Add(info);
            }
            return infos;
        }
        protected override string GetListItem(MessageEntity info)
        {
            var buidler = new StringBuilder();
            buidler.Append(string.Format("\"Id\":\"{0}\"",info.Id));
            buidler.Append(string.Format(",\"Title\":\"{0}\"", info.Title));

            return buidler.ToString();
        }

        protected override string GetResult(IList<MessageEntity> infos)
        {
            var b = base.GetResult(infos);
            return string.Format("{0}({1});", Request.QueryString["jsoncallback"], b);
        }
        protected override void SetQueryWhere(QueryInfo query)
        {
            query.Query<MessageEntity>()
                 .Where(it => it.InsertTime >= DateTime.Now.AddMinutes(0 - Request.QueryString["times"].Convert<int>()));

        }

        protected override void SetQuerySelect(QueryInfo query)
        {
            query.SelectExp = null;
        }
   
    }
}