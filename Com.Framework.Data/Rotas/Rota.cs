using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Com.Framework.Data.Rotas
{
    [DataContract]
    public class Rota : Entity<long>
    {
        #region Keys
        [DataMember]
        public int PremiseID { get; set; }

        #endregion

        #region Properties

        [DataMember]
        public ICollection<Shift> Shifts { get; set; }

        [DataMember]
        public int Week { get; set; }

        [DataMember]
        public DateTime Start { get; set; }

        [DataMember]
        public DateTime End { get; set; }

        #endregion

        #region Navigation Properties

        protected virtual Premise Premise { get; set; }

        #endregion



        public Rota()
        {
            Shifts = new List<Shift>();
        }

        public float TotalHours => Shifts.Sum(s => s.Duration);

        public decimal TotalExpenditure => Shifts.Sum(s => s.Expenditure);

        /// <summary>
        /// Calculates the total expenditure for the specified employee
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        public decimal Expenditure(Employee employee)
        {
            return Expenditure(s => s.Employee.Id == employee.Id);
        }

        public decimal Expenditure(DayOfWeek dayOfWeek)
        {
            return Expenditure(s => s.Hours.First().DayOfWeek == (int)dayOfWeek);
        }

        public decimal Expenditure(DateTime from, DateTime to)
        {
            return Expenditure(s => s.Hours.First().From >= from.TimeOfDay && s.Hours.Last().To <= to.TimeOfDay
            && s.Hours.First().DayOfWeek >= (int)from.DayOfWeek && s.Hours.Last().DayOfWeek <= (int)to.DayOfWeek);
        }

        private decimal Expenditure(Func<Shift, bool> where)
        {
            return Shifts.Where(where).Sum(s => s.Expenditure);
        }

    }
}
