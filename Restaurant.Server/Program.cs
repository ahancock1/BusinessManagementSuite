using System;
using System.Diagnostics;
using System.ServiceModel;
using System.ServiceProcess;
using System.Threading;
using Restaurant.Data.Management;
using Restaurant.Data.Management.Floor;
using Restaurant.Data.Management.Staff;
using Restaurant.Listeners;
using Restaurant.Service;

namespace Restaurant.Server
{
    public static class Program
    {
        #region Nested classes to support running as service
        private const string ServiceName = "Restaurant Service";

        private static Network.Server server;

        private class Service : ServiceBase
        {
            public Service()
            {
                ServiceName = Program.ServiceName;
            }

            protected override void OnStart(string[] args)
            {
                Program.Start(args);
            }

            protected override void OnStop()
            {
                Program.Stop();
            }
        }
        #endregion

        static void Main(string[] args)
        {
            if (!Environment.UserInteractive)
                // running as windows service
                using (var service = new Service())
                    ServiceBase.Run(service);
            else
            {
                try
                {
                    string process = Process.GetCurrentProcess().ProcessName;
                    Process[] processes = Process.GetProcessesByName(process);
                    if (processes.Length <= 1)
                    {
                        // running as console application
                        Start(args);

                        Console.WriteLine("Press any key to stop...");
                        Console.ReadKey(true);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("General failure: {0} \r\n Press any key to stop...", e.Message);
                    Console.ReadKey(true);
                }

                Stop();
            }
        }

        private static void Start(string[] args)
        {
            // Initiate and run the server
            server = new Network.Server(7777);

            // New listeners
            server.AddListener(new GenericPacketHandler<StaffMember>());
            server.AddListener(new GenericPacketHandler<Member>());
            server.AddListener(new GenericPacketHandler<Reservation>());
            server.AddListener(new GenericPacketHandler<Shift>());

            new Thread(server.Start) { Name = "Server" }.Start();

            // Initiate and host the web services
            

            // The service can be be accessed
            Console.WriteLine("Services Hosted");

        }

        private static void Stop()
        {
            // onstop code here
            if (server != null)
            {
                server.Stop();
            }

            Environment.Exit(1);
        }
    }
}