using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Restaurant.DataModels.Management
{
    public class Rota
    {
        public int RotaID { get; set; }

        public List<Shift> Shifts { get; set; }

        [Required]
        public DateTime Start { get; set; }

        [Required]
        public DateTime End { get; set; }
        

        public Rota()
        {
            Shifts = new List<Shift>();
        }

        public double TotalHours
        {
            get { return Shifts.Sum(s => s.TotalHours); }
        }
    }
}