using Autofac;
using ServerDES.CommonServiceBus.Modules;
using AutoMapper;
using ServerDES.CommonServiceBus.Factories;

namespace ServerDES.CommonServiceBus
{
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
