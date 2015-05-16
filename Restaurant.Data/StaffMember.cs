using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Restaurant.Data
{
    [Serializable]
    [Table("StaffMembers")]
    public class StaffMember : Member
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public DateTime DateHired { get; set; }

        [Required]
        public int ConnectionType { get; set; }

        public virtual ICollection<Shift> Shifts { get; set; }
        

        public StaffMember()
        {
            Username = String.Empty;
            Password = String.Empty;
        }
    }
}