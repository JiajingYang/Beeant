
using System;
using System.Collections.Generic;
using Component.Extension;

namespace Beeant.Domain.Entities.Utility
{
    [Serializable]
    public class EmailEntity
    {
        private bool _isLog = true;
        /// <summary>
        /// 是否记录日志
        /// </summary>
        public bool IsLog
        {
            get { return _isLog; }
            set { _isLog = value; }
        }
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// 单据编号
        /// </summary>
        public string Number { get; set; }
        /// <summary>
        /// 邮箱地址
        /// </summary>
        public Winner.Mail.MailInfo Mail { get; set; }

        #region 配置属性

        private string _variables;

        /// <summary>
        /// 设置
        /// </summary>
        public string Variables
        {
            get
            {
                if (string.IsNullOrEmpty(_variables) && VariablesDictionary != null)
                    _variables = VariablesDictionary.SerializeJson();
                return _variables;
            }
            set
            {
                _variables = value;
                if (string.IsNullOrEmpty(value))
                    return;
                VariablesDictionary = value.DeserializeJson<Dictionary<string, object>>();
            }
        }
        public IDictionary<string, object> VariablesDictionary { get; set; }

        /// <summary>
        /// 得到设置
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public virtual T GetVariable<T>(string key)
        {
            if (VariablesDictionary == null || !VariablesDictionary.ContainsKey(key))
                return default(T);
            return VariablesDictionary[key].Convert<T>();
        }


        /// <summary>
        /// 设置
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public virtual void SetVariable(string key, object value)
        {
            VariablesDictionary = VariablesDictionary ?? new Dictionary<string, object>();
            if (VariablesDictionary.ContainsKey(key))
                VariablesDictionary[key] = value;
            else
                VariablesDictionary.Add(key, value);
        }


        #endregion
    }
}
