using System;
using System.ComponentModel;
using System.Configuration.Install;
using System.Diagnostics;
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
        /// <summary>
        /// ServiceHost handler for self-hosting web services
        /// http://blog.thijssen.ch/2009/08/hosting-multiple-wcf-services-under.html
        /// </summary>
        [System.ComponentModel.DesignerCategory("Code")]
        private class WindowsService : ServiceBase
        {
            public static string Name = "Restaurant Service";

            public static string Description = "Windows service for hosting TCP server and WCF services";

            public static string Username = @".\username";

            public static string Password = "password";


            public WindowsService()
            {
                ServiceName = Name;
                CanStop = true;
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

        [RunInstaller(true)]
        [System.ComponentModel.DesignerCategory("Code")]
        public class ServiceHostInstaller : Installer
        {
            /// <summary>
            /// Enables application to be installed as a windows service by running
            /// InstallUtil
            /// </summary>
            public ServiceHostInstaller()
            {
                Installers.Add(new ServiceInstaller
                {
                    StartType = ServiceStartMode.Automatic,
                    ServiceName = WindowsService.Name,
                    Description = WindowsService.Description
                });

                Installers.Add(new ServiceProcessInstaller
                {
                    Account = ServiceAccount.User,
                    Username = WindowsService.Username,
                    Password = WindowsService.Password
                });
            }
        }
        #endregion

        private static Network.Server server;

        private static ServiceManager services;

        static void Main(string[] args)
        {
            if (!Environment.UserInteractive)
            {
                // running as windows service
                using (var service = new WindowsService())
                {
                    ServiceBase.Run(service);
                }
            }
            else
            {
                try
                {
                    string process = Process.GetCurrentProcess().ProcessName;
                    Process[] processes = Process.GetProcessesByName(process);
#if !DEBUG
                    if (processes.Length <= 1)  
#endif
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


        // When you run the application in debug mode, Visual Studio automatically starts an instance of the 
        // WCF Service host for each service. To avoid this, start the application by pressing Ctrl+F5.
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
            services = new ServiceManager();
            services.OpenHost<LoginService, ILoginService>();


            // The service can be be accessed
            Console.WriteLine("Services Hosted");

            bool result = new LoginService().Login("username", "password");

            if (result)
            {
                Console.WriteLine("success");
            }
        }

        private static void Stop()
        {
            if (server != null)
            {
                server.Stop();
            }
            if (services != null)
            {
                services.Close();
            }

            Environment.Exit(1);
        }
    }
}