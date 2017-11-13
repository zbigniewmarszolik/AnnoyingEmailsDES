using Autofac;
using AutoMapper;
using ServerDES.Hosts.CommonHost.Factories;
using ServerDES.Hosts.CommonHost.Modules;

namespace ServerDES.Hosts.CommonHost
{
    /*
     * Startup class - configuration of Autofac IoC container and AutoMapper.
     */
    public class Startup
    {
        public IContainer ConfigureContainer()
        {
            var containerBuilder = CreateContainerBuilder();

            return containerBuilder.Build();
        }

        private ContainerBuilder CreateContainerBuilder()
        {
            ContainerBuilder builder = new ContainerBuilder();

            builder.RegisterModule<TopologyModule>();
            builder.RegisterModule<ScenarioModule>();

            builder.RegisterInstance(CreateMapperInstance()).As<IMapper>();

            return builder;
        }

        private IMapper CreateMapperInstance()
        {
            var factory = new AutoMapperFactory();
            var mapper = factory.ProduceMapper();

            return mapper;
        }
    }
}
