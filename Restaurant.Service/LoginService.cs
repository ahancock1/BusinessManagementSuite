using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Security;
using System.Text;
using Restaurant.Data;
using Restaurant.DataAccess.Services;

namespace Restaurant.Service
{
    public interface IService
    {
        // Empty interface
    }

    [ServiceContract]
    public interface ILoginService : IService
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
        private readonly GenericService service = new GenericService();


        public bool Register(User user)
        {
            return service.Update(user);
        }

        public bool Login(string username, string password)
        {
            // De-hash the password here

//            return service.Get<User>(u => u.Username == username && u.Credential.Password == password, u => u.Credential) != null;
            return false;
        }

        public User GetUser(string username, string password)
        {
//            User user = service.Get<User>(u => u.Username == username && u.Credential.Password == password, u => u.Credential);
//
//            if (user != null)
//            {
//                user.Credential = null;
//            }

            User user = null;
            return user;
        }

        public IList<T> All<T>() where T : class, IEntity
        {
            throw new NotImplementedException();
        }

        public IList<T> All<T>(string @where, params string[] include) where T : class, IEntity
        {
            throw new NotImplementedException();
        }

        public IList<T> All<T>(Func<T, bool> @where, params Expression<Func<T, object>>[] include) where T : class, IEntity
        {
            throw new NotImplementedException();
        }

        public T Get<T>(string @where, params string[] include) where T : class, IEntity
        {
            throw new NotImplementedException();
        }

        public T Get<T>(Func<T, bool> @where, params Expression<Func<T, object>>[] include) where T : class, IEntity
        {
            throw new NotImplementedException();
        }

        public bool Update<T>(params T[] items) where T : class, IEntity
        {
            throw new NotImplementedException();
        }
    }
}
