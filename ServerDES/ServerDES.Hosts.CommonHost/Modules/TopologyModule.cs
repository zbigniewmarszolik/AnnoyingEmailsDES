using Autofac;
using ServerDES.Topology.Core.Services;
using ServerDES.Topology.Installer.Modules;
using ServerDES.Topology.Microservice.Services;

namespace ServerDES.Hosts.CommonHost.Modules
{
    /*
     * Autofac module for topology microservice.
     */
    public class TopologyModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<MailTopologyService>().As<IMailTopologyService>();

            builder.RegisterModule<TopologyBusinessModule>();
            builder.RegisterModule<TopologyDataModule>();
        }
    }
}
