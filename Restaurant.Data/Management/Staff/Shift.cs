using System;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.Data.Management.Staff
{
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

        public double TotalHours
        {
            get { return TimeSpan.TotalHours; }
        }

        public TimeSpan TimeSpan
        {
            get { return End - Start; }
        }
    }
}
