using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;


namespace RestaurantServer.Common
{
    [ServiceContract]
    public interface IService
    {
        [OperationContract]
        string Ping(string name);
    }

    public class ServiceImplementation : IService
    {
        #region IService Members

        public string Ping(string name)
        {
            Console.WriteLine("SERVER _ Processing Ping('{0}')", name);
            return "Hello, " + name;
        }

        #endregion
    }
}
