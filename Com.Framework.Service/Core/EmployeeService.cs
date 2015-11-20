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
        Employee GetEmployee(int id);

        [OperationContract]
        IEnumerable<Employee> GetEmployeesByPremise(int id);

        [OperationContract]
        SalaryAndWage GetEmployeeSalaryAndWage(int id);

        [OperationContract]
        PaymentMethod GetEmployeePaymentMethod(int id);

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

        public IEnumerable<Employee> GetEmployeesByPremise(int id)
        {
            return Service.All<Employee>(e => e.PremiseID == id,
                e => e.PhoneNumbers, e => e.WorkLocations, e => e.EmployeeGroup);
        }

        public SalaryAndWage GetEmployeeSalaryAndWage(int id)
        {
            return Service.Get<SalaryAndWage>(s => s.EmployeeID == id);
        }

        public PaymentMethod GetEmployeePaymentMethod(int id)
        {
            return Service.Get<PaymentMethod>(p => p.EmployeeID == id);
        }

        public bool UpdateEmployees(params Employee[] employee)
        {
            return Service.Update(employee);
        }

    }
}
