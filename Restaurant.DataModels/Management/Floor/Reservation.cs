using System;
using System.ComponentModel.DataAnnotations;
using Restaurant.DataModels.Management.Staff;

namespace Restaurant.DataModels.Management.Floor
{
    [Serializable]
    public class Reservation : Entity
    {
        public int ReservationID { get; set; }
        
        [Required]
        public DateTime Arrive { get; set; }

        [Required]
        public DateTime Depart { get; set; }

        [Required]
        public int GuestCount { get; set; }


        [Required]
        public virtual Table Table { get; set; }

        [Required]
        public virtual StaffMember Member { get; set; }
        
        
        public Reservation()
        {
            Arrive = new DateTime();
            Depart = new DateTime();
        }

        /// <summary>
        /// Returns how long the table is reserved for in minutes
        /// </summary>
        public int AllocatedTime
        {
            get { return (Depart - Arrive).Minutes; }
        }
    }
}
