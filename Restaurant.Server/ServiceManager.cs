using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace Restaurant.Server
{
    public class ServiceManager
    {
        private readonly List<ServiceHost> serviceHosts = new List<ServiceHost>();
        
        public void Close()
        {
            serviceHosts.ForEach(s => s.Close());
        }

        public void OpenHost<T>()
        {
            Type type = typeof(T);
            ServiceHost serviceHost = new ServiceHost(type);
            {
                try
                {
                    serviceHost.Open();
                    
                    serviceHosts.Add(serviceHost);
                    Console.WriteLine("Service hosted: {0}", type.Name);
                }
                catch (TimeoutException e)
                {
                    Console.WriteLine("Timeout exception: {0}, {1}", type.Name, e.Message);
                }
                catch (CommunicationException e)
                {
                    Console.WriteLine("Communication exception: {0}, {1}", type.Name, e.Message);
                }
            }
        }  
    }
}
