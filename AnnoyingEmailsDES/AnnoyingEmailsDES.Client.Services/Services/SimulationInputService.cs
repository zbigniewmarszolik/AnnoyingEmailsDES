using AnnoyingEmailsDES.Client.Domain.Models;
using AnnoyingEmailsDES.Client.Domain.Services;
using System.Collections.Generic;
using System.ServiceModel;
using System.Threading.Tasks;

namespace AnnoyingEmailsDES.Client.Services.Services
{
    /*
     * Implementation of SimulationInputService (communication with WCF server).
     */
    public class SimulationInputService : ISimulationInputService
    {
        public async Task<IList<Friend>> GetAllGroupMembers()
        {
            var binding = new BasicHttpBinding();
            EndpointAddress address = new EndpointAddress("http://localhost:8000/AnnoyingEmailsDesService/");

            var client = new ServerProxy.MailSimulationServiceClient(binding, address);

            var x = await client.HelloAsync();

            return null;
        }

        public async Task<Mail> GetStartingScenario()
        {
            return null;
        }
    }
}
