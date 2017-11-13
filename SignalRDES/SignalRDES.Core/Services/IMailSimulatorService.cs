using SignalRDES.Core.DataTransferObjects;
using System.Collections.Generic;

namespace SignalRDES.Core.Services
{
    /*
     * MailSimulatorService's interface.
     */
    public interface IMailSimulatorService
    {
        IList<FriendDTO> ProvideTopologyInput();
        MailDTO ProvideScenarioInput();
    }
}
