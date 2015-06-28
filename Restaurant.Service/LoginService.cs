using System.ServiceModel;
using Restaurant.Data;
using Restaurant.DataAccess.Services;

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

    public class LoginService : ILoginService
    {
        private readonly IGenericService service = new GenericService();


        public bool Register(User user)
        {
            return service.Update(user);
        }

        public bool Login(string username, string password)
        {
            // De-hash the password here

            return service.Get<UserCredentials>(u => u.User.Username == username && u.Password == password) != null;
        }

        public User GetUser(string username, string password)
        {
            return service.Get<UserCredentials>(u => u.User.Username == username && u.Password == password).User;
        }
    }
}