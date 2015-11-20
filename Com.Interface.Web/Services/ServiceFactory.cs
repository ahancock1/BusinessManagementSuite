using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Web.Configuration;
using Com.Framework.Services;

namespace Com.Interface.Web.Services
{
    public class ChannelFactoryException : Exception
    {
        public ChannelFactoryException() { }
        public ChannelFactoryException(string message) : base(message) { }
        public ChannelFactoryException(string message, Exception exception) : base(message, exception) { }
    }

    public static class ServiceFactory
    {
        private static readonly string BaseServiceAddress;
        private static readonly Int32 BindingType;

        private const string ServicePathString = "{0}.svc";

        static ServiceFactory()
        {
            BaseServiceAddress = WebConfigurationManager.AppSettings["BaseServiceAddress"];
            BindingType = Convert.ToInt32(WebConfigurationManager.AppSettings["BindingType"]);
        }

        /// <summary>
        /// Does a really straightforward 1 to 1 mapping of IServiceInterface to ServiceInterface, basically assumes that your service and interface names are identical
        /// </summary>
        /// <param name="type">Accepts any type</param>
        /// <returns>Type Name minus first character</returns>
        private static string GetInterfaceName(Type type)
        {
            return type.Name.Substring(1, type.Name.Length - 1);
        }

        private static string GetInterfaceName<T>()
        {
            return GetInterfaceName(typeof(T));
        }

        /// <summary>
        /// Create an instance of IService binding
        /// </summary>
        /// <typeparam name="T">Any IService</typeparam>
        /// <returns>Active binding instance</returns>
        public static T Create<T>() where T : IService
        {
            ServiceBindingManager manager = new ServiceBindingManager(new Uri(BaseServiceAddress), (ServiceBindingManager.BindingTypeEnum)BindingType);
            string servicePath = string.Format(ServicePathString, GetInterfaceName(typeof(T)));
            return manager.Create<T>(servicePath);
        }


    }

    public class ServiceBindingManager
    {
        private readonly Uri baseAddress;
        private readonly BindingTypeEnum bindingType;

        public enum BindingTypeEnum
        {
            BasicHttp = 0,
            NetTcp
        }

        public ServiceBindingManager() { }
        public ServiceBindingManager(Uri baseAddress, BindingTypeEnum bindingType)
        {
            baseAddress = baseAddress;
            bindingType = bindingType;
        }

        public T Create<T>(string servicePath) where T : IService
        {
            if (typeof(T).IsInterface)
            {
                Binding binding = BuildBinding(bindingType);
                ChannelFactory<T> channelFactory = new ChannelFactory<T>(binding, new EndpointAddress(BuildEndpointAddress(baseAddress, servicePath)));
                T instance = channelFactory.CreateChannel();
                return instance;
            }
            else
            {
                throw new ChannelFactoryException("Type provided must be an interface");
            }
        }

        private static Binding BuildBinding(BindingTypeEnum bindingType)
        {
            switch (bindingType)
            {
                case BindingTypeEnum.BasicHttp:
                    return new BasicHttpBinding();
                case BindingTypeEnum.NetTcp:
                    return new NetTcpBinding(SecurityMode.None)
                    {
                        MaxReceivedMessageSize = int.MaxValue
                    };
                default:
                    throw new NotImplementedException();
            }
        }

        private static string BuildEndpointAddress(Uri baseAddress, string servicePath)
        {
            return new Uri(baseAddress, servicePath).ToString();
        }
    }
}