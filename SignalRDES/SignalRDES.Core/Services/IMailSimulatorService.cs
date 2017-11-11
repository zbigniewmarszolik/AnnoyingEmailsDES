using SignalRDES.Core.DataTransferObjects;
using System.Collections.Generic;

namespace SignalRDES.Core.Services
{
    public interface IMailSimulatorService
    {
        IList<FriendDTO> ProvideTopologyInput();
        MailDTO ProvideScenarioInput();
    }
}
