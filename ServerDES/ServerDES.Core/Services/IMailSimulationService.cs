using System.ServiceModel;

namespace ServerDES.Core.Services
{
    [ServiceContract]
    public interface IMailSimulationService
    {
        [OperationContract]
        int Hello();
    }
}
