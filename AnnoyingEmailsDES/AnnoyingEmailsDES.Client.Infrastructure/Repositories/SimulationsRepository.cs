using AnnoyingEmailsDES.Client.Domain.Entities;
using AnnoyingEmailsDES.Client.Domain.Factories;
using AnnoyingEmailsDES.Client.Domain.Repositories;
using SQLite.Net;
using SQLiteNetExtensions.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AnnoyingEmailsDES.Client.Infrastructure.Repositories
{
    /*
    * Implementation of SimulationsRepository.
    */
    public class SimulationsRepository : ISimulationsRepository
    {
        public Action DatabaseErrorAction { get; set; }

        private SQLiteConnection _connection { get; set; }

        public SimulationsRepository(IFactory<SQLiteConnection> sQLiteConnectionFactory)
        {
            _connection = sQLiteConnectionFactory.Create();
        }

        public void CreateSimulation(SimulationEntity simulation)
        {
            try
            {
                _connection.Insert(simulation);
            }
            catch (Exception ex)
            {
                DatabaseErrorAction();
            }
        }

        public IList<SimulationEntity> ReadSimulations()
        {
            IList<SimulationEntity> sims = null;

            try
            {
                sims = _connection.GetAllWithChildren<SimulationEntity>().ToList();
            }
            catch (Exception ex)
            {
                DatabaseErrorAction();
            }

            return sims;
        }
    }
}
