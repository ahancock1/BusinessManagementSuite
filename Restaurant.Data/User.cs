﻿using System;

namespace Restaurant.Data
{
    [Serializable]
    public class User
    {
        public int UserID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public string EmailAddress { get; set; }
        
        public string Username { get; set; }

        public string Password { get; set; }

        public int ConnectionType { get; set; }

        public User()
        {
            FirstName = String.Empty;
            LastName = String.Empty;
            PhoneNumber = String.Empty;
            EmailAddress = String.Empty;
            Username = String.Empty;
            Password = String.Empty;
        }

        public string FullName
        {
            get { return String.Format("{0} {1}", FirstName, LastName); }
        }

        public override string ToString()
        {
            return String.Format("User: {0} {1}", FirstName, LastName);
        }
    }
}
