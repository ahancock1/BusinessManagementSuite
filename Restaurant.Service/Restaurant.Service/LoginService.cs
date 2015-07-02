using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Restaurant.Data;
using Restaurant.DataAccess.Services;

namespace Restaurant.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "LoginService" in both code and config file together.
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

            return service.Get<UserCredential>(u => u.User.Username == username && u.Password == password) != null;
        }

        public User GetUser(string username, string password)
        {
            return service.Get<UserCredential>(u => u.User.Username == username && u.Password == password).User;
        }
    }
}
