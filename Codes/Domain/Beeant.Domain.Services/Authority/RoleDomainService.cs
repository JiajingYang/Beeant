using System.Collections.Generic;
using Beeant.Domain.Entities.Account;
using Beeant.Domain.Entities.Authority;
using Beeant.Domain.Entities.Workflow;
using Beeant.Domain.Services.Workflow;
using Winner.Persistence;

namespace Beeant.Domain.Services.Authority
{
    public class RoleDomainService : RealizeDomainService<RoleEntity>
    {
        /// <summary>
        /// 角色功能
        /// </summary>
        public IDomainService RoleAblitityDomainService { get; set; }
        /// <summary>
        /// 角色账户
        /// </summary>
        public IDomainService RoleAccountDomainService { get; set; }
        private IDictionary<string, IUnitofworkHandle> _itemHandles;
        /// <summary>
        /// 处理
        /// </summary>
        protected override IDictionary<string, IUnitofworkHandle> ItemHandles
        {
            get
            {
                return _itemHandles ?? (_itemHandles = new Dictionary<string, IUnitofworkHandle>
                    {
                        {"RoleAbilities", new UnitofworkHandle<RoleAbilityEntity>{DomainService= RoleAblitityDomainService}}
                    ,   {"RoleAccounts", new UnitofworkHandle<RoleAccountEntity>{DomainService=RoleAccountDomainService}}
                    });
            }
            set
            {
                base.ItemHandles = value;
            }
        }
        protected override bool ValidateAdd(RoleEntity info)
        {
            return ValidateAccount(info);
        }
        /// <summary>
        /// 验证角色
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        protected virtual bool ValidateAccount(RoleEntity info)
        {
            if (!info.HasSaveProperty(it => it.Account.Id))
                return true;
            if (info.Account != null && (info.Account.SaveType == SaveType.Add || info.Account.Id==0))
                return true;
            if (info.Account != null && info.Account.Id != 0)
            {
                if (Repository.Get<AccountEntity>(info.Account.Id) != null)
                    return true;
            }
            info.AddErrorByName(typeof(AccountEntity).FullName, "NoExist");
            return false;
        }
    }
}
