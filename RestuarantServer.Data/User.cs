using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestuarantServer.Data
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

        public User()
        {
            
        }
    }
}
