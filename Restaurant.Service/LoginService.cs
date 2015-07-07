﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
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
        private readonly IGenericService service = new GenericService();


        public bool Register(User user)
        {
            return service.Update(user);
        }

        public bool Login(string username, string password)
        {
            // De-hash the password here

            return service.Get<User>(u => u.Username == username && u.Credential.Password == password, u => u.Credential) != null;
        }

        public User GetUser(string username, string password)
        {
            User user = service.Get<User>(u => u.Username == username && u.Credential.Password == password, u => u.Credential);

            if (user != null)
            {
                user.Credential = null;
            }

            return user;
        }
    }
}
