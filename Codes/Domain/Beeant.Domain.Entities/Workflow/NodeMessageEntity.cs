using System;

namespace Beeant.Domain.Entities.Workflow
{
    
    [Serializable]
    public class NodeMessageEntity : BaseEntity<NodeMessageEntity>
    {
       
   
        /// <summary>
        /// 任务
        /// </summary>
        public NodeEntity Node { get; set; }
        /// <summary>
        /// 类型
        /// </summary>
        public MessageType Type { get; set; }
    
        /// <summary>
        /// 处理地址
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        public string Detail { get; set; }
    }
}
