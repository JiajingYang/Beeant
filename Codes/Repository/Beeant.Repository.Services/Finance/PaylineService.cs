using System.Linq;
using Component.Extension;
using Beeant.Domain.Entities.Account;
using Beeant.Domain.Entities.Finance;
using Beeant.Domain.Services.Finance;
using Winner.Persistence;
using Winner.Persistence.Linq;

namespace Beeant.Repository.Services.Finance
{
    public class PaylineService : Repository, IPaylineContract
    {
        private static readonly object Locker = new object();
        public virtual string Save(string info)
        {
            lock (Locker)
            {
                var payline = info.DeserializeJson<PaylineEntity>();
                if (ValidateExist(payline))
                {
                    var unitofworks = base.Save(payline);
                    Winner.Creator.Get<IContext>().Commit(unitofworks);
                }
                return payline.SerializeJson();

            }
           
        }
        /// <summary>
        /// 验证手机号码
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        protected virtual bool ValidateExist(PaylineEntity info)
        {
            if (info == null || info.Status== PaylineStatusType.Success || info.Status== PaylineStatusType.Failure)
            {
                return false;
            }
            var query = new QueryInfo();
            query.Query<AccountIdentityEntity>().Where(it => it.Id != info.Id
                                               && it.Number == info.Number);
            var dataInfo = GetEntities<PaylineEntity>(query)?.FirstOrDefault();
            if (dataInfo == null || dataInfo.Status == PaylineStatusType.Success || dataInfo.Status == PaylineStatusType.Failure)
            {
                info.AddError("StatusAlreadyTrue");
                return false;
            }
            return true;
        }
 
    }
}
