using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Restaurant.DataModels.Management
{
    [Serializable]
    [Table("Members")]
    public class Member : Entity
    {
        public int MemberID { get; set; }

        [Required(ErrorMessage = "First name is required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Phone number is required")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Email address is required")]
        public string Email { get; set; }

        // Useful relationship
        public virtual ICollection<Reservation> Reservations { get; set; }
        

        public Member()
        {
            FirstName = String.Empty;
            LastName = String.Empty;
            PhoneNumber = String.Empty;
            Email = String.Empty;
        }

        public string FullName
        {
            get { return LastName + ", " + FirstName; }
        }
    }
}
