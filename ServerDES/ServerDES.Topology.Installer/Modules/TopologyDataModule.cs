using Autofac;
using ServerDES.Topology.Core.Managers;
using ServerDES.Topology.Data.Managers;

namespace ServerDES.Topology.Installer.Modules
{
    /*
     * Autofac module for data layer of topology.
     */
    public class TopologyDataModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<TopologyFileManager>().As<ITopologyFileManager>();
        }
    }
}
