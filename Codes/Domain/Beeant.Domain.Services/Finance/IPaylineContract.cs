using System.ServiceModel;

namespace Beeant.Domain.Services.Finance
{
     [ServiceContract(Namespace = "http://Beeant.Domain.Services.Finance", ConfigurationName = "Beeant.Domain.Services.Finance.IPaylineContract")]
    public interface IPaylineContract
    {
         /// <summary>
         /// 设置
         /// </summary>
         /// <param name="info"></param>
         /// <returns></returns>
         [OperationContract(
             Action = "http://Beeant.Domain.Services.Finance.IPaylineContract/Set",
             ReplyAction = "http://Beeant.Domain.Services.Finance.IPaylineService/SetResponse")]
         string Save(string info);

    }
}
