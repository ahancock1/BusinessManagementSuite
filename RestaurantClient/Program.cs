using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using RestaurantServer.Common;

namespace RestaurantClient
{
    class Program
    {
        static void Main(string[] args)
        {
            // Run client
            ChannelFactory<IService> channel = new ChannelFactory<IService>(new NetTcpBinding(), "net.tcp://localhost:8000");

            IService service = channel.CreateChannel();
            Console.WriteLine("CLIENT - Running...");

            Console.WriteLine("Press any key to terminate");
            while (Console.ReadKey() != new ConsoleKeyInfo())
            {
                string response = service.Ping("client");
                Console.WriteLine("CLIENT - Response from service: {0}", response);

                Thread.Sleep(200);
            }

            Console.WriteLine("\nCLIENT - Shut down");
            (service as ICommunicationObject).Close();

            Thread.Sleep(250);
        }
    }
}
