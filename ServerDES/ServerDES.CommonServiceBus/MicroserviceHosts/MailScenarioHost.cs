﻿using Autofac;
using Autofac.Integration.Wcf;
using ServerDES.Scenario.Core.Services;
using ServerDES.Scenario.Microservice.Services;
using System;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace ServerDES.CommonServiceBus.MicroserviceHosts
{
    public class MailScenarioHost : MicroserviceHostBase
    {
        private readonly IContainer _container;

        private Uri _baseAddress;
        private Uri _endpointAddress;
        private ServiceHost _serviceHost;

        public MailScenarioHost(IContainer container) : base()
        {
            _baseAddress = new Uri("http://localhost:8001/");
            _endpointAddress = new Uri(_baseAddress + "AnnoyingEmailsScenario/");

            _container = container;
        }

        public void OpenHost()
        {
            _serviceHost = new ServiceHost(typeof(MailScenarioService), _baseAddress);

            _serviceHost.AddServiceEndpoint(typeof(IMailScenarioService), BasicBinding, _endpointAddress);
            _serviceHost.AddDependencyInjectionBehavior<IMailScenarioService>(_container);

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