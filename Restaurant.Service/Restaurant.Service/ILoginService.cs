using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Restaurant.Data;

namespace Restaurant.Service
{
    [ServiceContract]
    public interface ILoginService
    {
        [OperationContract]
        bool Register(User member);

        [OperationContract]
        bool Login(string username, string password);

        [OperationContract]
        User GetUser(string username, string password);
    }
}
