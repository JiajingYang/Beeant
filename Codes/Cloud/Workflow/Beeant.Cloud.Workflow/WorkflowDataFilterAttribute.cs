using Beeant.Basic.Services.Mvc.FilterAttribute;
using Beeant.Domain.Entities;

namespace Beeant.Cloud.Workflow
{
    public class WorkflowDataFilterAttribute : DataFilterAttribute
    {

        private string _identityName = "Workflow.Id";
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
                    _identityId = Identity == null ? 0 : Identity.GetNumber<long>("WorkflowId");
                return _identityId.Value;
            }
            set { base.IdentityId = value; }
        }
    }
}
