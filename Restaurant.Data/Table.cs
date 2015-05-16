using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.Data
{
    [Serializable]
    public class Table : IEntity
    {
        public int TableID { get; set; }

        [Required]
        public byte Number { get; set; }

        [Required]
        public byte Seats { get; set; }
        
        public Section Section { get; set; }

        public virtual ICollection<Reservation> Reservations { get; set; }

        public EntityState EntityState { get; set; }


        public Table()
        {
            Section = new Section();
        }
    }

    [Serializable]
    public class Section
    {
        public int SectionID { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<Table> Tables { get; set; }


        public Section()
        {
            Name = String.Empty;
        }
    }

    public class Privilege
    {
        public int PriveligeID { get; set; }

        public string Name { get; set; }

        public int ConnectionType { get; set; }

        public virtual ICollection<StaffMember> Members { get; set; } 


        public Privilege()
        {
            Name = String.Empty;
        }
    }
}
