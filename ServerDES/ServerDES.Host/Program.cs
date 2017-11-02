using ServerDES.Core.Services;
using ServerDES.Services.Services;
using System;
using System.ServiceModel;

namespace ServerDES.Host
{
    class Program
    {
        static void Main(string[] args)
        {
            BasicHttpBinding binding = new BasicHttpBinding();
            binding.Name = "desBinding";
            binding.HostNameComparisonMode = HostNameComparisonMode.StrongWildcard;
            binding.Security.Mode = BasicHttpSecurityMode.None;

            Uri baseAddress = new Uri("http://localhost:8000/");
            Uri address = new Uri("http://localhost:8000/AnnoyingEmailsDesService/");

            ServiceHost serviceHost = new ServiceHost(typeof(MailSimulationService), baseAddress);

            serviceHost.AddServiceEndpoint(typeof(IMailSimulationService), binding, address);

            serviceHost.Open();

            Console.WriteLine("The service is ready.");
            Console.WriteLine("Press <ENTER> to terminate service.");
            Console.WriteLine();
            Console.ReadLine();

            serviceHost.Close();
        }
    }
}
