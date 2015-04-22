using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Serialization;
using RestaurantServer.Data.DataAccess;

namespace RestaurantServer.Data.DataModel
{
    public interface IUserService
    {
        User GetById(int id);

        IEnumerable<User> GetAll();

        IEnumerable<User> Search(string username, string firstName, string lastName);

        bool Create(User user);

        bool Update(User user);

        bool Delete(int id);
    }

    [DataContract]
    public class User : IUserService
    {
        public int UserID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public string EmailAddress { get; set; }

        public UserType UserType { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public User()
        {
            FirstName = String.Empty;
            LastName = String.Empty;
            PhoneNumber = String.Empty;
            EmailAddress = String.Empty;
            Username = String.Empty;
            Password = String.Empty;
        }

        public User GetById(int id)
        {
            using (var context = new RestaurantDbContext())
            {
                return context.Users.SingleOrDefault(u => u.UserID == id);
            }
        }

        public IEnumerable<User> GetAll()
        {
            using (var context = new RestaurantDbContext())
            {
                return context.Users;
            }
        }

        public IEnumerable<User> Search(string username, string firstName, string lastName)
        {
            throw new NotImplementedException();
        }

        public bool Create(User user)
        {
            using (var context = new RestaurantDbContext())
            {
                context.Users.Add(user);
                return context.SaveChanges() > 0;
            }
        }

        public bool Update(User user)
        {
            using (var context = new RestaurantDbContext())
            {
                context.Users.Attach(user);
                context.Entry(user).State = EntityState.Modified;
                return context.SaveChanges() > 0;
            }
        }

        public bool Delete(int id)
        {
            using (var context = new RestaurantDbContext())
            {
                User user = context.Users.Find(id);
                context.Users.Remove(user);
                return context.SaveChanges() > 0;
            }
        }

        public override string ToString()
        {
            return String.Format("User: {0} {1}", FirstName, LastName);
        }
    }

    public interface IUserTypeService
    {
        UserType GetById(int id);

        IEnumerable<UserType> GetAll();
        
        bool Create(UserType user);

        bool Update(UserType user);

        bool Delete(int id);
    }

    public class UserType : IUserTypeService
    {

        public int UserTypeID { get; set; }

        public string Name { get; set; }

        public virtual ICollection<User> Users { get; set; }

        public UserType()
        {
            Name = String.Empty;
        }

        public UserType GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserType> GetAll()
        {
            throw new NotImplementedException();
        }
        public bool Create(UserType user)
        {
            throw new NotImplementedException();
        }

        public bool Update(UserType user)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}