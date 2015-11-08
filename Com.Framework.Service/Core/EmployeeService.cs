using System.Collections.Generic;
using System.ServiceModel;
using Com.Framework.Data;
using Com.Framework.Data.PayRoll;

namespace Com.Framework.Service
{
    [ServiceContract]
    public interface IEmployeeService : IService
    {
        [OperationContract]
        Employee GetEmployee(int employeeID);

        [OperationContract]
        IEnumerable<Employee> GetEmployeesByPremise(int premiseID);

        [OperationContract]
        SalaryAndWage GetEmployeeSalaryAndWage(int employeeID);

        [OperationContract]
        PaymentMethod GetEmployeePaymentMethod(int employeeID);

        [OperationContract]
        bool UpdateEmployees(params Employee[] employee);
    }

    public class EmployeeService : BaseService, IEmployeeService
    {
        public Employee GetEmployee(int id)
        {
            return Service.Get<Employee>(e => e.Id == id,
                e => e.PhoneNumbers, e => e.WorkLocations, e => e.EmployeeGroup);
        }

        public IEnumerable<Employee> GetEmployeesByPremise(int premiseID)
        {
            return Service.All<Employee>(e => e.PremiseID == premiseID,
                e => e.PhoneNumbers, e => e.WorkLocations, e => e.EmployeeGroup);
        }

        public SalaryAndWage GetEmployeeSalaryAndWage(int employeeID)
        {
            return Service.Get<SalaryAndWage>(s => s.EmployeeID == employeeID);
        }

        public PaymentMethod GetEmployeePaymentMethod(int employeeID)
        {
            return Service.Get<PaymentMethod>(p => p.EmployeeID == employeeID);
        }

        public bool UpdateEmployees(params Employee[] employee)
        {
            return Service.Update(employee);
        }

    }
}
