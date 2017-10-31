using AnnoyingEmailsDES.Client.Domain.Factories;
using AnnoyingEmailsDES.Client.Domain.Repositories;
using AnnoyingEmailsDES.Client.Infrastructure.Factories;
using AnnoyingEmailsDES.Client.Infrastructure.Repositories;
using SQLite.Net;
using StructureMap;

namespace AnnoyingEmailsDES.Client.Installer.Registries
{
    /*
     * Class responsible for registering the Infrastructure classes in StructureMap container.
     */
    public class InfrastructureRegistry : Registry
    {
        public InfrastructureRegistry()
        {
            For<ISimulationsRepository>().Use<SimulationsRepository>();

            For<IFactory<SQLiteConnection>>().Use<SQLiteConnectionFactory>();
        }
    }
}
