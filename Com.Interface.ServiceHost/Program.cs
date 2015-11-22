using System;
using System.Configuration;
using System.ComponentModel;
using System.Configuration.Install;
using System.Diagnostics;
using System.ServiceProcess;
using Com.Framework.Common.Logging;
using Com.Framework.Hubs;
using Com.Framework.Services;
//using Com.Framework.Service;
//using Com.Framework.Service.Rotas;

using Microsoft.Owin.Hosting;

namespace Com.Interface.ServiceHost
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
            public static string Name = "Business Management Suite Service Host Server";

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
                        Console.Title = "Business Management Suite Service Host Server " + typeof(Program).Assembly.GetName().Version;

                        // running as console application
                        // SignalR Init
                        using (WebApp.Start<Startup>(ConfigurationManager.AppSettings["SignalRServices"]))
                        {
                            Logger.Info("SignalR hosted at " + ConfigurationManager.AppSettings["SignalRServices"]);

                            // WCF
                            Start(args);

                            Logger.Info("Press any key to stop...");
                            Console.ReadKey(true);
                        }
                    }
#if !DEBUG
                    else
                    {
                        Logger.Info("Server already running \r\n \t Shutting down...");
                    }
#endif
                }
                catch (Exception e)
                {
                    Logger.Fatal("General Failure", e);
                    Logger.Info("Press any key to close...");
                    Console.ReadKey(true);
                }

                Stop();
            }
        }


        // When you run the application in debug mode, Visual Studio automatically starts an instance of the 
        // WCF Service host for each service. To avoid this, start the application by pressing Ctrl+F5.
        private static void Start(string[] args)
        {
            // Initiate and host the web services
            services = new ServiceManager();

            services.OpenHost<MembershipService, IMembershipService>();
            //services.OpenHost<OrganisationService, IOrganisationService>();
            //services.OpenHost<PremiseService, IPremiseService>();
            //services.OpenHost<MenuService, IMenuService>();
            //services.OpenHost<RotaService, IRotaService>();
            //services.OpenHost<ShiftService, IShiftService>();



            // The service can be be accessed
            Logger.Info(String.Format("{0} Services Hosted", services.HostedCount));

            //var result = new EmployeeService().GetEmployee(1);//.Get<Restaurant>(u => u.Name == "TestRestaurant", u => u.OpenHours);

            //Console.WriteLine(result.ToString());

            //            User result = new LoginService().GetUser("username", "password");
            //
            //            if (result != null)
            //            {
            //                Console.WriteLine("success");
            //            }


        }

        private static void Stop()
        {
            //server?.Stop();
            services?.Close();

            Environment.Exit(1);
        }
    }
}
