using Autofac;
using ServerDES.Topology.Core.Managers;
using ServerDES.Topology.Data.Managers;

namespace ServerDES.Topology.Installer.Modules
{
    public class TopologyDataModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<TopologyFileManager>().As<ITopologyFileManager>();
        }
    }
}
