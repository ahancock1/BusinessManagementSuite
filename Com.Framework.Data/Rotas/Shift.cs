using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace Com.Framework.Data.Rotas
{
    [DataContract]
    public class Shift : Entity
    {
        [DataMember]
        public int ShiftID { get; set; }

        [DataMember]
        public ICollection<Hours> Hours { get; set; }

        [DataMember]
        public Employee Employee { get; set; }

        protected virtual Rota Rota { get; set; }


        public Shift()
        {
            Hours = new List<Hours>();
        }

        public float Duration => Hours.Sum(h => h.Duration);


        public ShiftType ShiftType => Hours.Count > 1 ? ShiftType.Split : ShiftType.Normal;

        public decimal Expenditure => (decimal)Hours.Sum(h => h.Duration) * Employee.SalaryAndWages.OrderByDescending(s => s.EffectiveDate).First().Value;
    }
}