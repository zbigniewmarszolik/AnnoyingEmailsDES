using AnnoyingEmailsDES.Client.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnnoyingEmailsDES.Client.Domain.Services
{
    /*
     * SimulationInputService's interface.
     */
    public interface ISimulationInputService
    {
        Action ServerErrorAction { get; set; }

        Task<IList<Friend>> GetAllGroupMembers();
        Task<Mail> GetStartingScenario();
    }
}
