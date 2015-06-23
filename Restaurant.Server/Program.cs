using System;
using System.Threading;
using Restaurant.Data;
using Restaurant.Data.Management;
using Restaurant.Data.Management.Floor;
using Restaurant.Data.Management.Staff;
using Restaurant.Listeners;

namespace Restaurant.Server
{
    class Program
    {
        private static Network.Server server;

        static void Main(string[] args)
        {
            // Initiate and start the server
            server = new Network.Server(7777);
            
            // New listener
            server.AddListener(new GenericPacketHandler<StaffMember>());
            server.AddListener(new GenericPacketHandler<Member>());
            server.AddListener(new GenericPacketHandler<Reservation>());
            server.AddListener(new GenericPacketHandler<Shift>());

            
            new Thread(server.Start) { Name = "Server" }.Start();

            Console.ReadKey();
        }
    }
}
