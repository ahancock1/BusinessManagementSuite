using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Restaurant.DataModels.Management.Staff
{
    [Serializable]
    [Table("StaffMembers")]
    public class StaffMember : Member
    {
        [Required(ErrorMessage = "Username is required")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Date hired is required")]
        public DateTime DateHired { get; set; }

        [Required(ErrorMessage = "Connection type is required")]
        public int ConnectionType { get; set; }

        public virtual ICollection<Shift> Shifts { get; set; }

        public virtual ICollection<Reservation> Reservations { get; set; } 

        public StaffMember()
        {
            Username = String.Empty;
            Password = String.Empty;
        }
    }
}