using AnnoyingEmailsDES.Client.Domain.Services;
using AnnoyingEmailsDES.Client.Services.Services;
using StructureMap;

namespace AnnoyingEmailsDES.Client.Installer.Registries
{
    /*
     * Class responsible for registering the Services classes in StructureMap container.
     */
    public class ServicesRegistry : Registry
    {
        public ServicesRegistry()
        {
            For<ISimulationInputService>().Use<SimulationInputService>();
        }
    }
}
