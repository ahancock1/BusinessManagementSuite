using System;
using System.CodeDom;
using System.Collections.Generic;
using Restaurant.Service;

using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace Restaurant.Server
{
    public class ServiceManager
    {
        private List<ServiceHost> serviceHosts = new List<ServiceHost>();


        public void Close()
        {
            foreach (ServiceHost serviceHost in serviceHosts.ToArray())
            {
                try
                {
                    serviceHost.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error closing service: {0}", e.Message);
                }
                finally
                {
                    if (serviceHost.State == CommunicationState.Faulted)
                    {
                        serviceHost.Abort();
                    }
                    serviceHosts.Remove(serviceHost);
                }
            }
        }

        public void OpenHost<T1, T2>(string name, int httpPort = 8001, int tcpPort = 9010)
            where T1 : class
            where T2 : IService
        {
            Type type = typeof(T1);

            Uri httpUrl = new Uri(String.Format("http://localhost:{0}/Restaurant/{1}", httpPort, name));
            Uri tcpUrl = new Uri(String.Format("net.tcp://localhost:{0}/Restaurant/{1}", tcpPort, name));

            ServiceHost serviceHost = new ServiceHost(type, httpUrl);
            try
            {
                // Check to see if the service host already has a ServiceMetadataBehavior
                ServiceMetadataBehavior meta = serviceHost.Description.Behaviors.Find<ServiceMetadataBehavior>();
                if (meta == null)
                {
                    serviceHost.Description.Behaviors.Add(new ServiceMetadataBehavior
                    {
                        HttpGetEnabled = true,
                        MetadataExporter = { PolicyVersion = PolicyVersion.Policy15 }
                    });
                }

                // Add MEX endpoint
                serviceHost.AddServiceEndpoint(
                    ServiceMetadataBehavior.MexContractName,
                    MetadataExchangeBindings.CreateMexHttpBinding(),
                    "mex"
                    );

                // Add application endpoint                    
                serviceHost.AddServiceEndpoint(typeof(T2), new WSHttpBinding(), httpUrl);
                //serviceHost.AddServiceEndpoint(typeof(T2), new NetTcpBinding(), tcpUrl);

                // Add monitoring
                foreach (ServiceEndpoint endpoint in serviceHost.Description.Endpoints)
                {
                    endpoint.Behaviors.Add(new MonitorBehavior());
                }

                serviceHost.Open();

                serviceHosts.Add(serviceHost);

                Console.WriteLine("{0} hosted: {1}", name, httpUrl);
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

        public void OpenHost<T1, T2>(int httpPort = 8001, int tcpPort = 9010)
            where T1 : class
            where T2 : IService
        {
            OpenHost<T1, T2>(typeof(T1).Name, httpPort, tcpPort);
        }
    }

    class MonitorBehavior : IEndpointBehavior
    {
        public void ApplyDispatchBehavior(
        ServiceEndpoint endpoint,
        EndpointDispatcher endpointDispatcher)
        {
            endpointDispatcher.DispatchRuntime.MessageInspectors
               .Add(new MonitorDispatcher());
        }

        class MonitorDispatcher : IDispatchMessageInspector
        {
            public object AfterReceiveRequest(
                ref Message request,
                IClientChannel channel,
                InstanceContext instanceContext)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(
                    "{0:HH:mm:ss.ffff}\t{1}\n\t\t{2} ({3} bytes)\n\t\t{4}",
                    DateTime.Now, request.Headers.MessageId,
                    request.Headers.Action, request.ToString().Length,
                    request.Headers.To);
                return null;
            }

            public void BeforeSendReply(
                ref Message reply,
                object correlationState)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(
                    "{0:HH:mm:ss.ffff}\t{1}\n\t\t{2} ({3} bytes)",
                    DateTime.Now, reply.Headers.RelatesTo,
                    reply.Headers.Action, reply.ToString().Length);
            }
        }
    }
}
