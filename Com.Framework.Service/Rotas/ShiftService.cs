using System.Collections.Generic;
using System.ServiceModel;
using Com.Framework.Data.Rotas;

namespace Com.Framework.Service.Rotas
{
    [ServiceContract]
    public interface IShiftService : IService
    {
        [OperationContract]
        Shift GetShift(int shiftID);

        [OperationContract]
        IEnumerable<Shift> GetShiftsByEmployee(int employeeID);

        [OperationContract]
        bool Update(params Shift[] items);
    }

    public class ShiftService : BaseService, IShiftService
    {
        public Shift GetShift(int shiftID)
        {
            return Service.Get<Shift>(s => s.ShiftID == shiftID);
        }

        public IEnumerable<Shift> GetShiftsByEmployee(int employeeID)
        {
            return Service.All<Shift>(s => s.EmployeeID == employeeID, s => s.EmployeeID);
        }

        public bool Update(params Shift[] items)
        {
            return Service.Update(items);
        }

    }

}
