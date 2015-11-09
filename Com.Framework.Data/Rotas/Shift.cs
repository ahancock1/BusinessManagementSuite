using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace Com.Framework.Data.Rotas
{
    [DataContract]
    public class Shift : Entity<long>
    {
        #region Keys

        [DataMember]
        public int EmployeeID { get; set; }

        #endregion

        #region Property

        [DataMember]
        public ICollection<Hours> Hours { get; set; }

        [DataMember]
        public Employee Employee { get; set; }

        #endregion

        #region Navigation Properties

        protected virtual Rota Rota { get; set; }

        #endregion


        public Shift()
        {
            Hours = new List<Hours>();
        }

        public float Duration => Hours.Sum(h => h.Duration);


        public ShiftType ShiftType => Hours.Count > 1 ? ShiftType.Split : ShiftType.Normal;

        public decimal Expenditure => (decimal)Hours.Sum(h => h.Duration) * Employee.SalaryAndWages.OrderByDescending(s => s.EffectiveDate).First().Value;
    }
}