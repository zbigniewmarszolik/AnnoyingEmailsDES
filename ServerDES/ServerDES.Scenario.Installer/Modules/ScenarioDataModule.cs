using Autofac;
using ServerDES.Scenario.Core.Managers;
using ServerDES.Scenario.Data.Managers;

namespace ServerDES.Scenario.Installer.Modules
{
    public class ScenarioDataModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ScenarioFileManager>().As<IScenarioFileManager>();
        }
    }
}
