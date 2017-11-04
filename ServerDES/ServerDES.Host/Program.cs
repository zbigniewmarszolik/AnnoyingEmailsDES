using ServerDES.Host.Hosts;

namespace ServerDES.Host
{
    class Program
    {
        static void Main(string[] args)
        {
            var mailSimulationHost = new MailSimulationHost();
            mailSimulationHost.OpenHost();
        }
    }
}
