using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.Data
{
    public class Table
    {
        public int TableID { get; set; }

        [Required]
        public int Number { get; set; }

        [Required]
        public int Seats { get; set; }
        
        public Section Section { get; set; }

        public virtual ICollection<Reservation> Reservations { get; set; } 
        

        public Table()
        {
            
        }
    }


    public class Section
    {
        public int SectionID { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Table> Tables { get; set; }

        public Section()
        {
            
        }
    }

    public class Privilege
    {
        public int PriveligeID { get; set; }


    }
    
    public class Shift
    {
        public User User { get; set; }


        public Shift()
        {
            
        }
    }

    public class Guest
    {
        
    }

    public class Reservation
    {
        public int ReservationID { get; set; }

        public Table Table { get; set; }
        
        public DateTime ArriveTime { get; set; }

        public DateTime DepartTime { get; set; }


        public Reservation()
        {
            Table = new Table();
            ArriveTime = new DateTime();
            DepartTime = new DateTime();
        }

        /// <summary>
        /// Returns how long the table is reserved for in minutes
        /// </summary>
        public int AllocatedTime
        {
            get { return (DepartTime - ArriveTime).Minutes; }
        }
    }
}
