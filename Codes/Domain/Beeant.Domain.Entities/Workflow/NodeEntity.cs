﻿using System;
using System.Collections.Generic;
using Component.Extension;

namespace Beeant.Domain.Entities.Workflow
{
    public delegate bool DelegateNodeMethod(WorkflowArgsEntity args);
    [Serializable]
    public class NodeEntity : BaseEntity<NodeEntity>
    {
        /// <summary>
        /// 工作流类型
        /// </summary>
        public FlowEntity Flow { get; set; }

   
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 状态名称
        /// </summary>
        public string StatusName { get; set; }
        /// <summary>
        /// 业务状态变化
        /// </summary>
        public string StatusValue { get; set; }
        /// <summary>
        /// 通过节点名称 
        /// </summary>
        public string PassName { get; set; }
        /// <summary>
        /// 拒绝节点名称 
        /// </summary>
        public string RejectName { get; set; }
        /// <summary>
        /// 节点类型
        /// </summary>
        public NodeType NodeType { get; set; }
        /// <summary>
        /// 节点名称
        /// </summary>
        public string NodeTypeName
        {
            get { return NodeType.GetName(); }
        }
        /// <summary>
        /// 昵称
        /// </summary>
        public string Nickname { get; set; }
        /// <summary>
        /// 分配规则
        /// </summary>
        public NodeAssignType AssignType { get; set; }
        /// <summary>
        /// 分配规则
        /// </summary>
        public string AssignTypeName
        {
            get { return AssignType.GetName(); }
        }
        /// <summary>
        /// 条件类型
        /// </summary>
        public ConditionType ConditionType { get; set; }
        /// <summary>
        /// 条件名称
        /// </summary>
        public string ConditionTypeName
        {
            get { return ConditionType.GetName(); }
        }
        /// <summary>
        /// 超时时间分钟
        /// </summary>
        public int Timeout { get; set; }
        /// <summary>
        /// 消息类型
        /// </summary>
        public int MessageType { get; set; }
        /// <summary>
        /// 图像
        /// </summary>
        public string Map { get; set; }

        private string _messageTypeName;
        /// <summary>
        /// 消息类型
        /// </summary>
        public string MessageTypeName
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(_messageTypeName))
                    return _messageTypeName;
                _messageTypeName = MessageType.GetEnums<MessageType>().BuildeName();
                return _messageTypeName;
            }
        }

        /// <summary>
        /// 排序
        /// </summary>
        public int Sequence { get; set; }

        /// <summary>
        /// 状态描述
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 自定义委托
        /// </summary>
        public string ConditionMethod { get; set; }
        /// <summary>
        /// 自定义委托
        /// </summary>
        public string BeforeMethod { get; set; }
        /// <summary>
        /// 自定义委托
        /// </summary>
        public string AfterMethod { get; set; }

    
        /// <summary>
        /// 自定义委托
        /// </summary>
        public DelegateNodeMethod ConditionDelegate { get; set; }
        /// <summary>
        /// 自定义委托
        /// </summary>
        public DelegateNodeMethod BeforeDelegate { get; set; }
        /// <summary>
        /// 自定义委托
        /// </summary>
        public DelegateNodeMethod AfterDelegate { get; set; }
        /// <summary>
        /// 审批
        /// </summary>
        public IList<NodeAccountEntity> NodeAccounts { get; set; }
        /// <summary>
        /// 节点消息
        /// </summary>
        public IList<NodeMessageEntity> NodeMessages { get; set; }
        /// <summary>
        /// 条件
        /// </summary>
        public IList<ConditionEntity> Conditions { get; set; }
        /// <summary>
        /// 得到任务编号
        /// </summary>
        /// <returns></returns>
        public virtual long GetTaskAccountId()
        {
            if (NodeAccounts == null || NodeAccounts.Count == 0)
                return 0;
            if (AssignType == NodeAssignType.Average)
            {
                int index = (int)(DateTime.Now.Ticks % NodeAccounts.Count);
                return NodeAccounts[index].Account == null ? 0 : NodeAccounts[index].Account.Id;
            }
            if (AssignType == NodeAssignType.Random)
            {
                Random rd = new Random(Guid.NewGuid().GetHashCode());
                var index = rd.Next(0, NodeAccounts.Count - 1);
                return NodeAccounts[index].Account == null ? 0 : NodeAccounts[index].Account.Id;
            }
            return 0;
        }
       
    }
}
