using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace RestaurantServer.Data
{
    [DataContract]
    public class User
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

        public override string ToString()
        {
            return String.Format("User: {0} {1}", FirstName, LastName);
        }
    }

    public class UserType
    {

        public int UserTypeID { get; set; }

        public string Name { get; set; }

        public virtual ICollection<User> Users { get; set; }

        public UserType()
        {
            Name = String.Empty;
        }
    }
}