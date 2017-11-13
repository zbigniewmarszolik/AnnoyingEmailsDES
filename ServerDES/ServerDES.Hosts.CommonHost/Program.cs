using ServerDES.Hosts.CommonHost.ServiceHosts;
using System;

namespace ServerDES.Hosts.CommonHost
{
    /*
     * Program class with Main method which starts the application.
     */
    class Program
    {
        static void Main(string[] args)
        {
            var startup = new Startup();
            var container = startup.ConfigureContainer();

            var mailTopologyHost = new MailTopologyHost(container);
            var mailScenarioHost = new MailScenarioHost(container);

            var mailTopologyUrl = mailTopologyHost.EndpointAddress;
            var mailScenarioUrl = mailScenarioHost.EndpointAddress;

            mailTopologyHost.OpenHost();
            Console.WriteLine(" -- > Mail topology microservice is ready.");
            Console.WriteLine(" -- > URL: " + mailTopologyUrl);
            Console.WriteLine();

            mailScenarioHost.OpenHost();
            Console.WriteLine(" -- > Mail scenario microservice is ready.");
            Console.WriteLine(" -- > URL: " + mailScenarioUrl);
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
