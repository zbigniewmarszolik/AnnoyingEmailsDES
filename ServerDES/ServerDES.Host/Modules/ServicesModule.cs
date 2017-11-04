using Autofac;
using AutoMapper;
using ServerDES.Core.Services;
using ServerDES.Host.Factories;
using ServerDES.Services.Services;

namespace ServerDES.Host.Modules
{
    /*
     * Autofac module for Services layer.
     */
    public class ServicesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<MailSimulationService>().As<IMailSimulationService>();

            builder.RegisterInstance(CreateMapperInstance()).As<IMapper>();
        }

        private IMapper CreateMapperInstance()
        {
            var factory = new AutoMapperFactory();
            var mapper = factory.ProduceMapper();

            return mapper;
        }
    }
}
