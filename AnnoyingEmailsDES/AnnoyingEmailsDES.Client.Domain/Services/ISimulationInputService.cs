using AnnoyingEmailsDES.Client.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnnoyingEmailsDES.Client.Domain.Services
{
    /*
     * SimulationInputService's interface.
     */
    public interface ISimulationInputService
    {
        Task<IList<Friend>> GetAllGroupMembers();
        Task<Mail> GetStartingScenario();
    }
}
