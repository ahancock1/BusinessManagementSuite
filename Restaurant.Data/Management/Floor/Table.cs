using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.Data.Management.Floor
{
    [Serializable]
    public class Table : Entity
    {
        public int TableID { get; set; }

        [Required]
        public byte Number { get; set; }

        [Required]
        public byte Seats { get; set; }
        
        public Section Section { get; set; }

        public virtual ICollection<Reservation> Reservations { get; set; }
        

        public Table()
        {
            Section = new Section();
        }
    }
}
