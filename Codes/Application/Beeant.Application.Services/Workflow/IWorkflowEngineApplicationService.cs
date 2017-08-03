using Beeant.Domain.Entities.Workflow;

namespace Beeant.Application.Services.Workflow
{
    public interface IWorkflowEngineApplicationService
    {
        /// <summary>
        /// 执行
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        bool Handle(WorkflowArgsEntity args);
     
        /// <summary>
        /// 得到工作流
        /// </summary>
        /// <returns></returns>
        WorkflowArgsEntity GetWorkflowArgs();
    }
}
