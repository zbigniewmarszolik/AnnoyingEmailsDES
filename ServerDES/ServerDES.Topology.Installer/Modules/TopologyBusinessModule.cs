using Autofac;
using ServerDES.Topology.Business.Businesses;
using ServerDES.Topology.Core.Businesses;

namespace ServerDES.Topology.Installer.Modules
{
    /*
     * Autofac module for business layer of topology.
     */
    public class TopologyBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<TopologyBusiness>().As<ITopologyBusiness>();
        }
    }
}
