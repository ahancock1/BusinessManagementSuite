using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Com.Framework.Data.Rotas
{
    [DataContract]
    public class Rota : Entity
    {
        [DataMember]
        public int RotaID { get; set; }

        [DataMember]
        public ICollection<Shift> Shifts { get; set; }

        [DataMember]
        public int Week { get; set; }

        public DateTime Created { get; set; }

        public DateTime Modified { get; set; }

        public DateTime Start { get; set; }

        public DateTime End { get; set; }

        protected virtual Premise Premise { get; set; }

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
            return Expenditure(s => s.Employee.EmployeeID == employee.EmployeeID);
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
