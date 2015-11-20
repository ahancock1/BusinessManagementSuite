using System.Collections.Generic;
using System.ServiceModel;
using Com.Framework.Data.Rotas;

namespace Com.Framework.Service.Rotas
{
    [ServiceContract]
    public interface IShiftService : IService
    {
        [OperationContract]
        Shift GetShift(int id);

        [OperationContract]
        IEnumerable<Shift> GetShiftsByEmployee(int employeeId);

        [OperationContract]
        bool Update(params Shift[] items);
    }

    public class ShiftService : BaseService, IShiftService
    {
        public Shift GetShift(int id)
        {
            return Service.Get<Shift>(s => s.Id == id);
        }

        public IEnumerable<Shift> GetShiftsByEmployee(int employeeId)
        {
            return Service.All<Shift>(s => s.EmployeeID == employeeId, s => s.EmployeeID);
        }

        public bool Update(params Shift[] items)
        {
            return Service.Update(items);
        }

    }

}
