using System;
using System.Collections.Generic;

namespace Configuration
{
    public class EventHandleArgs
    {
        /// <summary>
        /// 事件名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 触发源
        /// </summary>
        public object Sender { get; set; }
   
    }
    public class EventHandle
    {
        /// <summary>
        /// 是否异步执行
        /// </summary>
        public bool IsAsync { get; set; }
        /// <summary>
        /// 参数
        /// </summary>
        public Action<EventHandleArgs> Action { get; set; }
    }
    static public class EventManager
    {
     
        private static IDictionary<string,IList<EventHandle>> Handles=new Dictionary<string, IList<EventHandle>>();

        /// <summary>
        /// 注册事件
        /// </summary>
        /// <param name="eventName"></param>
        /// <param name="handle"></param>
        public static void Register(string eventName, EventHandle handle)
        {
           if(!Handles.ContainsKey(eventName))
               Handles.Add(eventName,new List<EventHandle>());
            Handles[eventName].Add(handle);
        }
        /// <summary>
        /// 执行
        /// </summary>
        /// <param name="args"></param>
        public static void Execute(EventHandleArgs args)
        {
            if(args==null || string.IsNullOrWhiteSpace(args.Name))
                return;
            if (Handles.ContainsKey(args.Name) && Handles[args.Name] !=null)
            {
                foreach (var eventHandle in Handles[args.Name])
                {
                 if(eventHandle.Action==null)
                        continue;
                    if (eventHandle.IsAsync)
                        eventHandle.Action.BeginInvoke(args, null, null);
                    else
                        eventHandle.Action(args);
                }
            }
        }
    }
}
