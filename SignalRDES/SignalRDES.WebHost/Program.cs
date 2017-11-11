using Microsoft.Owin.Hosting;
using System;

namespace SignalRDES.WebHost
{
    class Program
    {
        static void Main(string[] args)
        {
            var url = "http://localhost:8080";
            using (WebApp.Start(url))
            {
                Console.WriteLine("Server is running on {0}", url);
                Console.WriteLine();
                Console.WriteLine("Press <ENTER> to stop server.");
                Console.WriteLine();
                Console.ReadLine();
            }
        }
    }
}
