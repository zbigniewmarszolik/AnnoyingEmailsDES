using AnnoyingEmailsDES.Client.Domain.Simulators;
using AnnoyingEmailsDES.Client.Simulator.Simulators;
using StructureMap;

namespace AnnoyingEmailsDES.Client.Installer.Registries
{
    /*
     * Class responsible for registering the Simulator classes in StructureMap container.
     */
    public class SimulatorRegistry : Registry
    {
        public SimulatorRegistry()
        {
            For<IMailSimulator>().Use<MailSimulator>();
        }
    }
}
