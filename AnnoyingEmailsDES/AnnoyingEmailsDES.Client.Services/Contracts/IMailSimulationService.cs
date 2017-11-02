using AnnoyingEmailsDES.Client.Domain.DTOs;
using System.Collections.Generic;
using System.ServiceModel;

namespace AnnoyingEmailsDES.Client.Services.Contracts
{
    /*
     * Remote WCF service contract.
     */
    [ServiceContract]
    public interface IMailSimulationService
    {
        [OperationContract]
        IList<FriendDTO> ProvideTopologyInput();

        [OperationContract]
        MailDTO ProvideScenarioInput();
    }
}
