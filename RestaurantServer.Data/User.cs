using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantServer.Data
{
    public class User
    {
        public int UserID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

//        [StringLength(12)]
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
    }
}