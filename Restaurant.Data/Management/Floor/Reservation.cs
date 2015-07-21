using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Restaurant.Data.Management.Staff;

namespace Restaurant.Data.Management.Floor
{
    [DataContract]
    public class Reservation : Entity
    {
        [Key, DataMember]
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

        public virtual Ticket Ticket { get; set; }
        
        
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
