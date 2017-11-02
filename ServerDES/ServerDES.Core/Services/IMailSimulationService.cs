using ServerDES.Core.DTOs;
using System.Collections.Generic;
using System.ServiceModel;

namespace ServerDES.Core.Services
{
    /*
     * MailSimulationService's inteface-based contract.
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
