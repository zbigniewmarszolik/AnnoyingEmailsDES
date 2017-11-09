using Autofac;
using ServerDES.Scenario.Business.Businesses;
using ServerDES.Scenario.Core.Businesses;

namespace ServerDES.Scenario.Installer.Modules
{
    public class ScenarioBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ScenarioBusiness>().As<IScenarioBusiness>();
        }
    }
}
