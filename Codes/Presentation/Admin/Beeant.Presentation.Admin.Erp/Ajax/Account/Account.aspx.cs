using System.Linq;
using Beeant.Domain.Entities.Account;
using Beeant.Basic.Services.WebForm.Pages;
using Winner.Persistence;
using Winner.Persistence.Linq;

namespace Beeant.Presentation.Admin.Erp.Ajax.Account
{
    public partial class Account : AjaxPageBase<AccountIdentityEntity>
    {

        protected override string GetListItem(AccountIdentityEntity info)
        {
            if (info.Account == null)
                return null;
           return string.Format("Text:'{0}|{1}',Value:'{2}'",info.Number, info.Account.RealName,info.Account.Id);
        }
        protected override void SetQueryWhere(QueryInfo query)
        {
            var name = Server.UrlDecode(Request.QueryString["name"].Trim());
            query.Query<AccountIdentityEntity>()
                .Where(it => it.Number==name);
        }
        protected override void SetQuerySelect(QueryInfo query)
        {
            query.SelectExp = "Id,Number,Account.RealName,Account.Id";
        }
    }
}