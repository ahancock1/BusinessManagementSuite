using Com.Framework.Data.Rotas;

namespace Com.Framework.Hubs.Rotas
{
    public interface IShiftHub
    {
        void UpdateShifts(params Shift[] shifts);
    }

    public class ShiftHub : ServiceHub<IShiftHub>
    {
        public Shift GetShift(int shiftID)
        {
            return Service.Get<Shift>(s => s.ShiftID == shiftID);
        }

        public Shift GetShiftByEmployee(int employeeID)
        {
            return Service.Get<Shift>(s => s.EmployeeID == employeeID);
        }

        public bool UpdateShifts(string name, params Shift[] shifts)
        {
            if (shifts.Length == 0) return false;

            Clients.Group(name).UpdateShifts(shifts);

            return Service.Update(shifts);
        }
    }
}
