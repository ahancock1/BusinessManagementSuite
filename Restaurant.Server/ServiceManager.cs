using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Description;
using Restaurant.Service;

namespace Restaurant.Server
{
    public class ServiceManager
    {
        private readonly List<ServiceHost> serviceHosts = new List<ServiceHost>();
        
        public void Close()
        {
            serviceHosts.ForEach(s => s.Close());
        }

        public void OpenHost<T1, T2>(string host = "localhost", int httpPort = 8733, int tcpPort = 8733)
            where T1 : class 
            where T2 : IService
        {
            Type type = typeof(T1);

            Uri httpUrl = new Uri(String.Format("http://{0}:{1}/Restaurant/{2}", host, httpPort, type.Name));
            Uri tcpUrl = new Uri(String.Format("net.tcp://{0}:{1}/Restaurant/{2}", host, tcpPort, type.Name));

            using (ServiceHost serviceHost = new ServiceHost(type, httpUrl))//, tcpUrl))
            {
                try
                {
//                    serviceHost.AddServiceEndpoint(typeof (T2), new NetTcpBinding(), tcpUrl);
                    serviceHost.Description.Behaviors.Add(new ServiceMetadataBehavior
                    {
                        HttpGetEnabled = true
                    });
                    serviceHost.Open();

                    serviceHosts.Add(serviceHost);

                    Console.WriteLine("{0} hosted on: {1}", type.Name, httpUrl);
                }
                catch (TimeoutException e)
                {
                    Console.WriteLine("Timeout exception: {0}, {1}", type.Name, e.Message);
                }
                catch (CommunicationException e)
                {
                    Console.WriteLine("Communication exception: {0}, {1}", type.Name, e.Message);
                }
                catch (Exception e)
                {
                    Console.Error.WriteLine("General exception: {0}, {1}", type.Name, e.Message);
                }
                finally
                {
                    if (serviceHost.State == CommunicationState.Faulted)
                    {
                        serviceHost.Abort();   
                    }
                }
            }
        }  
    }
}
