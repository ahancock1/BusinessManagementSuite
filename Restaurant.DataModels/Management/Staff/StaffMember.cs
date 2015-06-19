using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Restaurant.DataModels.Management.Floor;
using System.Runtime.Serialization;

namespace Restaurant.DataModels.Management.Staff
{
    [DataContract]
    [Table("StaffMembers")]
    public class StaffMember : Member
    {
        [DataMember]
        [Required(ErrorMessage = "Username is required")]
        public string Username { get; set; }

        [DataMember]
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

        [DataMember]
        [Required(ErrorMessage = "Date hired is required")]
        public DateTime DateHired { get; set; }

        [DataMember]
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