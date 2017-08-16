using System.Linq;
using Component.Extension;
using Beeant.Domain.Entities.Workflow;
using Beeant.Basic.Services.WebForm.Pages;
using Winner.Persistence;
using Winner.Persistence.Linq;

namespace Beeant.Presentation.Admin.Configurator.Workflow.NodeMessage
{
    public partial class List : MaintenPageBase<NodeMessageEntity>
    {
        public string NodeName { get; set; }

        public long NodeId
        {
            get { return Request["NodeId"].Convert<long>(); }
        }

        protected override void SetQueryWhere(QueryInfo query)
        {
            query.Query<NodeMessageEntity>().Where(it => it.Node.Id == NodeId);
            base.SetQueryWhere(query);
        }

   
 
   
        /// <summary>
        /// 添加
        /// </summary>
        /// <returns></returns>
        protected override NodeMessageEntity FillEntity()
        {
            var info = base.FillEntity();
            if (info.SaveType == SaveType.Add)
                info.Node = new NodeEntity { Id = NodeId };
            return info;
        }
    }
}