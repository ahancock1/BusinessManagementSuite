using Com.Framework.Data;
using System.Collections.Generic;

namespace Com.Framework.Hubs.Core
{
    public interface IEmployeeHub
    {
        Employee GetEmployee(int employeeID);

        IEnumerable<Employee> GetEmployeesByPremise(int premiseID);

        bool UpdateEmployees(string name, params Employee[] employees);
    }

    public interface IEmployeeContract
    {
        void UpdateEmployees(params Employee[] employees);
    }

    public class EmployeeHub : ServiceHub<IEmployeeContract>, IEmployeeHub
    {
        public Employee GetEmployee(int employeeID)
        {
            return Service.Get<Employee>(e => e.EmployeeID == employeeID,
                e => e.PhoneNumbers, e => e.WorkLocations, e => e.EmployeeGroup);
        }

        public IEnumerable<Employee> GetEmployeesByPremise(int premiseID)
        {
            return Service.All<Employee>(e => e.PremiseID == premiseID,
                e => e.PhoneNumbers, e => e.WorkLocations, e => e.EmployeeGroup);
        }

        public bool UpdateEmployees(string name, params Employee[] employees)
        {
            if (employees.Length == 0) return false;

            Clients.Group(name).UpdateEmployees(employees);

            return Service.Update(employees);
        }
    }
}
