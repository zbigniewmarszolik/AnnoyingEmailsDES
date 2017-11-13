using Autofac;
using Autofac.Integration.Wcf;
using ServerDES.Topology.Core.Services;
using ServerDES.Topology.Microservice.Services;
using System;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace ServerDES.Hosts.CommonHost.ServiceHosts
{
    /*
     * MailTopologyService endpoint.
     */
    public class MailTopologyHost : ServiceHostBase
    {
        private readonly IContainer _container;

        private Uri _baseAddress;
        private ServiceHost _serviceHost;

        public Uri EndpointAddress { get; private set; }

        public MailTopologyHost(IContainer container) : base()
        {
            _baseAddress = new Uri("http://localhost:8000/");
            EndpointAddress = new Uri(_baseAddress + "AnnoyingEmailsTopology/");

            _container = container;
        }

        public void OpenHost()
        {
            _serviceHost = new ServiceHost(typeof(MailTopologyService), _baseAddress);

            _serviceHost.AddServiceEndpoint(typeof(IMailTopologyService), BasicBinding, EndpointAddress);
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
