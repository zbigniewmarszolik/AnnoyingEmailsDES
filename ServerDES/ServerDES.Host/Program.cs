using ServerDES.Core.Services;
using ServerDES.Lib.Services;
using System;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace ServerDES.Host
{
    class Program
    {
        static void Main(string[] args)
        {
            BasicHttpBinding binding = new BasicHttpBinding();
            binding.Name = "binding1";
            binding.HostNameComparisonMode = HostNameComparisonMode.StrongWildcard;
            binding.Security.Mode = BasicHttpSecurityMode.None;

            Uri baseAddress = new Uri("http://localhost:8000/");
            Uri address = new Uri("http://localhost:8000/AnnoyingEmailsDesService/");

            // Create a ServiceHost for the CalculatorService type and provide the base address.
            ServiceHost serviceHost = new ServiceHost(typeof(MailSimulationService), baseAddress);

            serviceHost.AddServiceEndpoint(typeof(IMailSimulationService), binding, address);

            // Open the ServiceHostBase to create listeners and start listening for messages.
            serviceHost.Open();

            // The service can now be accessed.
            Console.WriteLine("The service is ready.");
            Console.WriteLine("Press <ENTER> to terminate service.");
            Console.WriteLine();
            Console.ReadLine();

            // Close the ServiceHostBase to shutdown the service.
            serviceHost.Close();
        }
    }
}
