using Autofac;
using ServerDES.Scenario.Core.Managers;
using ServerDES.Scenario.Data.Managers;

namespace ServerDES.Scenario.Installer.Modules
{
    /*
     * Autofac module for data layer of scenario.
     */
    public class ScenarioDataModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ScenarioFileManager>().As<IScenarioFileManager>();
        }
    }
}
