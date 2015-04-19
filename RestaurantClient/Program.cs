using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using RestaurantServer.Common;
using RestaurantServer.Data;

namespace RestaurantClient
{
    class Program
    {
        static void Main(string[] args)
        {
            // Run client
            ChannelFactory<ILoginService> channel = new ChannelFactory<ILoginService>(new NetTcpBinding(), "net.tcp://localhost:8000");

            ILoginService service = channel.CreateChannel();
            Console.WriteLine("CLIENT - Running...");

            Console.WriteLine("Press any key to terminate");
            while (true)
            {
                User user = service.GetUser(0);
                Console.WriteLine("CLIENT - Response from service: {0}", user);

                Thread.Sleep(200);
            }

            Console.WriteLine("\nCLIENT - Shut down");
            (service as ICommunicationObject).Close();

            Thread.Sleep(250);
        }
    }
}
