using ServerDES.CommonServiceBus.MicroserviceHosts;
using System;

namespace ServerDES.CommonServiceBus
{
    class Program
    {
        static void Main(string[] args)
        {
            var startup = new Startup();
            var container = startup.ConfigureContainer();

            var mailTopologyHost = new MailTopologyHost(container);
            mailTopologyHost.OpenHost();
            Console.WriteLine(" -- > Mail topology microservice is ready.");
            Console.WriteLine();

            var mailScenarioHost = new MailScenarioHost(container);
            mailScenarioHost.OpenHost();
            Console.WriteLine(" -- > Mail scenario microservice is ready.");
            Console.WriteLine();

            Console.WriteLine();
            Console.WriteLine("Press <ENTER> to terminate all services.");
            Console.WriteLine();
            Console.ReadLine();

            mailScenarioHost.CloseHost();
            mailTopologyHost.CloseHost();
        }
    }
}
