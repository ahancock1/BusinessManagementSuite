using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Restaurant.Data
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
            get { return Shifts.Sum(s => s.Hours); }
        }
    }

    [Serializable]
    public class Shift : Entity
    {
        public int ShiftID { get; set; }

        [Required]
        public DateTime Start { get; set; }

        [Required]
        public DateTime End { get; set; }

        [Required]
        public virtual StaffMember Member { get; set; }
        

        public Shift()
        {
        }

        public bool Validate()
        {
            return Start != DateTime.MinValue && End != DateTime.MinValue;
        }

        public double Hours
        {
            get { return TimeSpan.TotalHours; }
        }

        public TimeSpan TimeSpan
        {
            get { return End - Start; }
        }
    }
}
