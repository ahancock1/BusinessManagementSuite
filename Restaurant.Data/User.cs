using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Restaurant.Data
{
    [DataContract]
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

        public virtual UserCredential Credential { get; set; }

        public virtual Restaurant Restaurant { get; set; }

        public virtual Account Account { get; set; }

        public User()
        {

        }
    }
}
