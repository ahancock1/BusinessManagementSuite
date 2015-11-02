using System;
using System.Runtime.Serialization;

namespace Com.Framework.Data.PayRoll
{
    [DataContract]
    public class SalaryAndWage : BaseEntity
    {
        #region Keys
        [DataMember]
        public int SalaryAndWageID { get; set; }

        [DataMember]
        public int EmployeeID { get; set; }

        #endregion

        #region Properties

        [DataMember]
        public decimal HourlyRate { get; set; }

        [DataMember]
        public decimal AnnualSalary { get; set; }

        [DataMember]
        public float HoursPerWeek { get; set; }

        [DataMember]
        public DateTime? EffectiveDate { get; set; }

        #endregion

        #region Navigation Properties
        protected virtual Employee Employee { get; set; }

        #endregion

        public SalaryAndWage()
        {

        }

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
