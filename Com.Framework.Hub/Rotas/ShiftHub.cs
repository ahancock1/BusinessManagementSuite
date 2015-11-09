using System.Collections.Generic;
using Com.Framework.Data.Rotas;

namespace Com.Framework.Hubs.Rotas
{
    /// <summary>
    /// TODO: requires work
    /// </summary>
    public interface IShiftHub
    {
        Shift GetShift(int id);

        IEnumerable<Shift> GetShiftsByEmployee(int employeeID);

        bool UpdateShifts(string name, params Shift[] shifts);
    }

    public interface IShiftContract
    {
        void UpdateShifts(params Shift[] shifts);
    }

    public class ShiftHub : ServiceHub<IShiftContract>, IShiftHub
    {
        public Shift GetShift(int id)
        {
            return Service.Get<Shift>(s => s.Id == id);
        }

        public IEnumerable<Shift> GetShiftsByEmployee(int employeeID)
        {
            return Service.All<Shift>(s => s.EmployeeID == employeeID);
        }

        public bool UpdateShifts(string name, params Shift[] shifts)
        {
            if (shifts.Length == 0) return false;

            Clients.Group(name).UpdateShifts(shifts);

            return Service.Update(shifts);
        }
    }
}
