using System;
using System.Runtime.Serialization;

namespace Com.Framework.Data.PayRoll
{
    [DataContract]
    public class SalaryAndWage
    {
        [DataMember]
        public int SalaryAndWageID { get; set; }

        [DataMember]
        public decimal HourlyRate { get; set; }

        [DataMember]
        public decimal AnnualSalary { get; set; }

        [DataMember]
        public float HoursPerWeek { get; set; }

        [DataMember]
        public DateTime EffectiveDate { get; set; }

        public decimal Value
        {
            get
            {
                // TODO: Calculate this value?
                throw new NotImplementedException("Salary and wage value is not yet implemented");
            }
        }
    }
}
