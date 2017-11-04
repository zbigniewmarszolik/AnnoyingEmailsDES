using Autofac;
using Autofac.Integration.Wcf;
using ServerDes.Installer.Modules;
using ServerDES.Core.Services;
using ServerDES.Host.Modules;
using ServerDES.Services.Services;
using System;
using System.ServiceModel;

namespace ServerDES.Host.Hosts
{
    /*
     * Host for MailSimulationService.
     */
    public class MailSimulationHost : HostBase
    {
        private Uri _endpointAddress { get; set; }

        public MailSimulationHost() : base()
        {
            _endpointAddress = new Uri(BaseAddress + "AnnoyingEmailsDesService/");
        }

        public void OpenHost()
        {
            var containerBuilder = CreateContainerBuilder();

            using (var container = containerBuilder.Build())
            {
                ServiceHost serviceHost = new ServiceHost(typeof(MailSimulationService), BaseAddress);

                serviceHost.AddServiceEndpoint(typeof(IMailSimulationService), BasicBinding, _endpointAddress);
                serviceHost.AddDependencyInjectionBehavior<IMailSimulationService>(container);

                serviceHost.Open();

                Console.WriteLine("Mail simulation service is ready.");
                Console.WriteLine("Press <ENTER> to terminate service.");
                Console.WriteLine();
                Console.ReadLine();

                serviceHost.Close();
            }
        }

        private ContainerBuilder CreateContainerBuilder()
        {
            ContainerBuilder builder = new ContainerBuilder();

            builder.RegisterModule<DataModule>();
            builder.RegisterModule<ServicesModule>();

            return builder;
        }
    }
}
