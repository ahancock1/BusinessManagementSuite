using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace RestaurantServer.Data
{
    [DataContract]
    public class User
    {
        [DataMember]
        public int UserID { get; set; }
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string LastName { get; set; }
        [DataMember]
        public string PhoneNumber { get; set; }
        [DataMember]
        public string EmailAddress { get; set; }
        [DataMember]
        public UserType UserType { get; set; }
        [DataMember]
        public string Username { get; set; }
        [DataMember]
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
        [DataMember]
        public int UserTypeID { get; set; }
        [DataMember]
        public string Name { get; set; }

        public virtual ICollection<User> Users { get; set; }

        public UserType()
        {
            Name = String.Empty;
        }
    }
}