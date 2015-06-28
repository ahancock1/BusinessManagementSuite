using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Policy;
using System.ServiceModel;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;


namespace Restaurant.Server
{
    /// <summary>
    /// ServiceHost handler for self-hosting web services
    /// http://blog.thijssen.ch/2009/08/hosting-multiple-wcf-services-under.html
    /// </summary>
    [System.ComponentModel.DesignerCategory("Code")]
    public class WindowsService : ServiceBase
    {
        public static string Name = "Restaurant Service Host";

        public static string Description = "Windows Service Host";

        public static string Username = @".\username";

        public static string Password = "password";

        private readonly ServiceManager serviceManager;

        private readonly IContainer components = new Container();

        public WindowsService() : this(new ServiceManager())
        {
        }

        public WindowsService(ServiceManager serviceManager)
        {
            this.serviceManager = serviceManager;
            ServiceName = Name;
            CanStop = true;
        }

        protected override void OnStart(string[] args)
        {
            base.OnStart(args);
            serviceManager.OpenAll();
        }

        protected override void OnStop()
        {
            serviceManager.CloseAll();
            base.OnStop();
        }

        protected override void Dispose(bool disposing)
        {
            if (serviceManager != null)
            {
                serviceManager.CloseAll();
            }
            if (disposing && components != null)
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
    }
    
    public class ServiceManager
    {
        readonly IList<ServiceHost> serviceHosts = new List<ServiceHost>();
        
        public void OpenAll()
        {
            // Add host services here
//        OpenHost<service1>();  
//        OpenHost<service2>();  
        }

        public void CloseAll()
        {
            foreach (ServiceHost serviceHost in serviceHosts)
                serviceHost.Close();
        }

        private void OpenHost<T>()
        {
            Type type = typeof(T);
            ServiceHost serviceHost = new ServiceHost(type);
            serviceHost.Open();
            serviceHosts.Add(serviceHost);
        }  
    }
}
