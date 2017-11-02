using AnnoyingEmailsDES.Client.Domain.Entities;
using AnnoyingEmailsDES.Client.Domain.Models;

namespace AnnoyingEmailsDES.Client.Domain.Mappings
{
    /*
     * SimulationsMapping's interface.
     */
    public interface ISimulationsMapping
    {
        Simulation EntityToModel(SimulationEntity simulationDAO);
    }
}
