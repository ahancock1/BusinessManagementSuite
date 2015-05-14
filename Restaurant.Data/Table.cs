using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Restaurant.Data
{
    [Serializable]
    public class Table
    {
        public int TableID { get; set; }

        [Required]
        public byte Number { get; set; }

        [Required]
        public int Seats { get; set; }
        
        public Section Section { get; set; }

        public virtual ICollection<Reservation> Reservations { get; set; } 
        

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

    public class Privilege : IEnumerable<PrivilegeType>
    {
        public int PriveligeID { get; set; }

        public string Name { get; set; }

        public int Level { get; set; }

        public PrivilegeType[] Privileges { get; set; }


        public Privilege()
        {
            Name = String.Empty;
        }

        public string Message
        {
            get { return String.Format("Grants access to: {0}", Privileges); }
        }

        public IEnumerator<PrivilegeType> GetEnumerator()
        {
            return Privileges.ToList().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public enum PrivilegeType
    {
        Floor = 1,
        Bar,
        Kitchen,
        Management,
        Administration
    }
    
    public class Shift
    {
        public User User { get; set; }


        public Shift()
        {
            
        }
    }

    [Serializable]
    public class Guest
    {
        public int GuestID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        public Guest()
        {
            Name = String.Empty;
            PhoneNumber = String.Empty;
        }

        public override string ToString()
        {
            return String.Format("Guest: {0}, {1}", Name, PhoneNumber);
        }
    }

    [Serializable]
    public class Reservation
    {
        public int ReservationID { get; set; }

        [Required]
        public Table Table { get; set; }

        [Required]
        public DateTime Arrive { get; set; }

        [Required]
        public DateTime Depart { get; set; }
        
        [Required]
        public byte GuestCount { get; set; }

        [Required]
        public Guest Guest { get; set; }

        public Reservation()
        {
            Table = new Table();
            Arrive = new DateTime();
            Depart = new DateTime();
            Guest = new Guest();
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
