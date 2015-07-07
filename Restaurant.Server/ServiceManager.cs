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

        public void OpenHost<T1, T2>(string host = "localhost", int httpPort = 8001, int tcpPort = 9010)
            where T1 : class
            where T2 : IService
        {
            Type type = typeof(T1);

            Uri httpUrl = new Uri(String.Format("http://{0}:{1}/Restaurant/{2}", host, httpPort, type.Name));
            Uri tcpUrl = new Uri(String.Format("net.tcp://{0}:{1}/Restaurant/{2}", host, tcpPort, type.Name));

            ServiceHost serviceHost = new ServiceHost(type, httpUrl);
            try
            {
                // Check to see if the service host already has a ServiceMetadataBehavior
                ServiceMetadataBehavior meta = serviceHost.Description.Behaviors.Find<ServiceMetadataBehavior>();
                if (meta == null)
                {
                    //meta = new ServiceMetadataBehavior
                    //{
                    //    HttpGetEnabled = true
                    //};
                    //meta.MetadataExporter.PolicyVersion = PolicyVersion.Policy15;
                    //serviceHost.Description.Behaviors.Add(meta);

                    serviceHost.Description.Behaviors.Add(new ServiceMetadataBehavior
                    {
                        HttpGetEnabled = true
                    });
                }

                // links
                //http://www.c-sharpcorner.com/UploadFile/225740/self-hosting-of-wcf-service-with-console-application/
                //https://msdn.microsoft.com/en-us/library/vstudio/ms731758(v=vs.100).aspx

                // Add MEX endpoint
                serviceHost.AddServiceEndpoint(
                  ServiceMetadataBehavior.MexContractName,
                  MetadataExchangeBindings.CreateMexHttpBinding(),
                  "mex"
                );

                // Add application endpoint                    
                serviceHost.AddServiceEndpoint(typeof(T2), new WSHttpBinding(), httpUrl);
                //serviceHost.AddServiceEndpoint(typeof(T2), new NetTcpBinding(), tcpUrl);

                serviceHost.Open();

                serviceHosts.Add(serviceHost);

                Console.WriteLine("{0} hosted: {1}", type.Name, httpUrl);

                foreach (var s in serviceHost.Description.Endpoints)
                {
                    Console.WriteLine("Endpoint: {0}", s.Address);
                }
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
                Console.WriteLine("Error hosting service: {0}", e.Message);
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
