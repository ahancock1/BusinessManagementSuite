using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Restaurant.Data
{
    [Serializable]
    [Table("Members")]
    public class Member : IEntity
    {
        public int MemberID { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }
        
        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string Email { get; set; }

        // Useful relationship
        public virtual ICollection<Reservation> Reservations { get; set; }

        public EntityState EntityState { get; set; }


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
