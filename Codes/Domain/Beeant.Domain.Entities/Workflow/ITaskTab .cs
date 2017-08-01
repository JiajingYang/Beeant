using System.Collections.Generic;

namespace Beeant.Domain.Entities.Workflow
{
    public interface ITaskTab
    {
        /// <summary>
        /// 任务
        /// </summary>
       IList<TaskEntity> Tasks { get; set; }
    }
}
