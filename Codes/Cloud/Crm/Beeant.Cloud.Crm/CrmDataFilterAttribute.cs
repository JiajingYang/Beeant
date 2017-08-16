using Beeant.Basic.Services.Mvc.Extension;
using Beeant.Basic.Services.Mvc.FilterAttribute;
using Beeant.Domain.Entities;
using Beeant.Domain.Entities.Crm;

namespace Beeant.Cloud.Crm
{
    public class CrmDataFilterAttribute : DataFilterAttribute
    {

        private string _identityName = "Crm.Id";
        /// <summary>
        /// 值名称
        /// </summary>
        public override string IdentityName
        {
            get { return _identityName; }
            set { _identityName = value; }
        }
        private long? _identityId;
        public override long IdentityId
        {
            get
            {
                if (!_identityId.HasValue)
                    _identityId = Identity == null ? 0 : Identity.GetNumber<long>("CrmId");
                return _identityId.Value;
            }
            set { base.IdentityId = value; }
        }
    }
}
