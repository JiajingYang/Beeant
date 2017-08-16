﻿using System.Collections.Generic;
using System.Linq;
using Beeant.Domain.Entities;
using Beeant.Domain.Entities.Account;
using Beeant.Domain.Entities.Workflow;
using Winner.Persistence;
using Winner.Persistence.Linq;

namespace Beeant.Domain.Services.Workflow
{
    public class NodeAccountDomainService : RealizeDomainService<NodeAccountEntity>
    {
     
        #region 重写验证
  

        /// <summary>
        /// 是否有重复信息添加
        /// </summary>
        /// <param name="infos"></param>
        /// <returns></returns>
        protected override bool ValidateBatch(IList<NodeAccountEntity> infos)
        {
            bool rev = true;
            for (int i = 0; i < infos.Count; i++)
                for (int k = i + 1; k < infos.Count; k++)
                {
                    rev &= CompareEntities(infos[i], infos[k]);
                }
            return rev;
        }
        /// <summary>
        /// 比较
        /// </summary>
        /// <param name="info"></param>
        /// <param name="compare"></param>
        /// <returns></returns>
        protected virtual bool CompareEntities(NodeAccountEntity info, NodeAccountEntity compare)
        {
            string errorName = null;
            if (info.SaveType == SaveType.Add && info.Account.Id.Equals(compare.Account.Id) && info.Node.Id.Equals(compare.Node.Id))
                errorName = "RepeatInList";
            if (string.IsNullOrEmpty(errorName)) return true;
            info.AddErrorByName(typeof(BaseEntity).FullName, errorName);
            return false;
        }

        /// <summary>
        /// 验证添加
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        protected override bool ValidateAdd(NodeAccountEntity info)
        {
            return ValidateNodeExist(info) && ValidateAccountExist(info) && ValidateNodeAccountExist(info);
        }
 
        /// <summary>
        /// 验证NodeAccount是否已经存在
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        protected virtual bool ValidateNodeAccountExist(NodeAccountEntity info)
        {
            if (info.Node != null && info.Node.SaveType == SaveType.Add ||
             info.Account != null && info.Account.SaveType == SaveType.Add)
                return true;
            var query = new QueryInfo();
            query.Query<NodeAccountEntity>().Where(it => it.Account.Id ==  info.Account.Id
                                               && it.Node.Id == info.Node.Id);
            var infos = Repository.GetEntities<NodeAccountEntity>(query);
            if (infos == null || infos.Count == 0) return true;
            info.AddError("ExistNodeAccount");  
            return false;
        }
        /// <summary>
        /// 验证角色
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        protected virtual bool ValidateNodeExist(NodeAccountEntity info)
        {
            if (!info.HasSaveProperty(it => it.Node.Id))
                return true;
            if (info.Node != null && info.Node.SaveType == SaveType.Add)
                return true;
            if (info.Node != null && info.Node.Id!=0)
            {
                if (Repository.Get<NodeEntity>(info.Node.Id) != null)
                    return true;
            }
            info.AddErrorByName(typeof(NodeEntity).FullName, "NoExist");
            return false;
        }
        /// <summary>
        /// 验证用户
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        protected virtual bool ValidateAccountExist(NodeAccountEntity info)
        {
            if (!info.HasSaveProperty(it => it.Account.Id))
                return true;
            if (info.Account != null && info.Account.SaveType == SaveType.Add)
                return true;
            if (info.Account != null && info.Account.Id!=0)
            {
                if (Repository.Get<AccountEntity>(info.Account.Id) != null)
                    return true;
            }
            info.AddErrorByName(typeof(AccountEntity).FullName, "NoExist");
            return false;
        }
        #endregion
    }
}
