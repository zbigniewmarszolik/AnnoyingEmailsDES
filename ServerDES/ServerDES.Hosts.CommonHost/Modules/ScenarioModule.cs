using Autofac;
using ServerDES.Scenario.Core.Services;
using ServerDES.Scenario.Installer.Modules;
using ServerDES.Scenario.Microservice.Services;

namespace ServerDES.Hosts.CommonHost.Modules
{
    /*
     * Autofac module for topology microservice.
     */
    public class ScenarioModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<MailScenarioService>().As<IMailScenarioService>();

            builder.RegisterModule<ScenarioBusinessModule>();
            builder.RegisterModule<ScenarioDataModule>();
        }
    }
}
