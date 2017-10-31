using System.ServiceModel;

namespace AnnoyingEmailsDES.Server.Core.Services
{
    [ServiceContract]
    public interface IMailSimulationService
    {
        [OperationContract]
        int Hello();
    }
}
