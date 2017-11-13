using Microsoft.AspNet.SignalR;
using SignalRDES.Core.Services;

namespace SignalRDES.WebHost.Hubs
{
    /*
     * Hub (SignalR endpoint) for MailSimulator.
     */
    public class MailSimulatorHub : Hub
    {
        private readonly IMailSimulatorService _mailSimulatorService;

        public MailSimulatorHub(IMailSimulatorService mailSimulatorService)
        {
            _mailSimulatorService = mailSimulatorService;
        }

        public void SendTopologyInput()
        {
            var topology = _mailSimulatorService.ProvideTopologyInput();

            Clients.Caller.GetTopology(topology);
        }

        public void SendScenarioInput()
        {
            var scenario = _mailSimulatorService.ProvideScenarioInput();

            Clients.Caller.GetScenario(scenario);
        }
    }
}
