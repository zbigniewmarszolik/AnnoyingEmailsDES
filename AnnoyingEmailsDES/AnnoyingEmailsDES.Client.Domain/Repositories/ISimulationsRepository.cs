using AnnoyingEmailsDES.Client.Domain.Entities;
using System;
using System.Collections.Generic;

namespace AnnoyingEmailsDES.Client.Domain.Repositories
{
    /*
     * SimulationsRepository's interface.
     */
    public interface ISimulationsRepository
    {
        Action DatabaseErrorAction { get; set; }

        void CreateSimulation(SimulationEntity simulation);
        IList<SimulationEntity> ReadSimulations();
    }
}
