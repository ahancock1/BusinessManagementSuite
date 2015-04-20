using System;
using System.ServiceModel;
using RestaurantServer.Data;


namespace RestaurantServer.Service
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
            Console.WriteLine("SERVER - Processing Ping('{0}')", name);
            return "Hello, " + name;
        }

        #endregion
    }

    [ServiceContract]
    public interface ILoginService
    {
        [OperationContract]
        User GetUser(int id);
    }

    public class LoginService : ILoginService
    {
        public User GetUser(int id)
        {
            Console.WriteLine("SERVER - Fetching user: {0}", id);
            return new User
            {
                UserID = id,
                FirstName = "Adam",
                LastName = "Hancock",
                EmailAddress = "a.hancock@hotmail.co.uk",
                Password = "password",
                PhoneNumber = "07891599243",
                Username = "ahancock1",
                UserType = new UserType
                {
                    UserTypeID = 0,
                    Name = "Admin"
                }
            };
        }
    }
}
