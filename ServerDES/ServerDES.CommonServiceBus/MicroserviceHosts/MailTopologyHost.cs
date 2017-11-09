using Autofac;
using Autofac.Integration.Wcf;
using ServerDES.Topology.Core.Services;
using ServerDES.Topology.Microservice.Services;
using System;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace ServerDES.CommonServiceBus.MicroserviceHosts
{
    public class MailTopologyHost : MicroserviceHostBase
    {
        private readonly IContainer _container;

        private Uri _baseAddress;
        private Uri _endpointAddress;
        private ServiceHost _serviceHost;

        public MailTopologyHost(IContainer container) : base()
        {
            _baseAddress = new Uri("http://localhost:8000/");
            _endpointAddress = new Uri(_baseAddress + "AnnoyingEmailsTopology/");

            _container = container;
        }

        public void OpenHost()
        {
            _serviceHost = new ServiceHost(typeof(MailTopologyService), _baseAddress);

            _serviceHost.AddServiceEndpoint(typeof(IMailTopologyService), BasicBinding, _endpointAddress);
            _serviceHost.AddDependencyInjectionBehavior<IMailTopologyService>(_container);

            _serviceHost.Description.Behaviors.Remove(typeof(ServiceDebugBehavior));
            _serviceHost.Description.Behaviors.Add(new ServiceDebugBehavior { IncludeExceptionDetailInFaults = true });

            _serviceHost.Open();
        }

        public void CloseHost()
        {
            _serviceHost.Close();
            _serviceHost = null;
        }
    }
}
