using System;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.DataModels
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
        public byte MemberCount { get; set; }

        [Required]
        public virtual Table Table { get; set; }

        [Required]
        public virtual Member Member { get; set; }
        
        
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
