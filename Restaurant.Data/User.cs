﻿using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Restaurant.Data.Accounting;

namespace Restaurant.Data
{
    [DataContract(Name = "User"), KnownType(typeof(User))]
    public class User : Entity
    {
        public int UserID { get; set; }

        [DataMember, Required(ErrorMessage = "First name is required")]
        public string FirstName { get; set; }

        [DataMember, Required(ErrorMessage = "Last name is required")]
        public string LastName { get; set; }

        [DataMember, Required(ErrorMessage = "Username is required")]
        public string Username { get; set; }

        [DataMember, Required(ErrorMessage = "Date hired is required")]
        public DateTime DateHired { get; set; }

        [DataMember, Required(ErrorMessage = "Phone number is required")]
        public string PhoneNumber { get; set; }

        [DataMember, Required(ErrorMessage = "Email address is required")]
        public string Email { get; set; }

        [DataMember]
        public byte[] Image { get; set; }

        [DataMember]
        public virtual UserCredential Credential { get; set; }

        [DataMember]
        public virtual Venue Venue { get; set; }

        [DataMember]
        public virtual Account Account { get; set; }

        public User()
        {

        }
    }
}
