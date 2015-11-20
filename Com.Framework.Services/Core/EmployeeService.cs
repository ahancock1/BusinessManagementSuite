using System.Collections.Generic;
using System.ServiceModel;
using Com.Framework.Data;
using Com.Framework.Data.PayRoll;


namespace Com.Framework.Services
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
        public Employee GetEmployee(int employeeid)
        {
            return Service.Get<Employee>(e => e.Id == employeeid,
                e => e.PhoneNumbers, e => e.WorkLocations, e => e.EmployeeGroup);
        }

        public IEnumerable<Employee> GetEmployeesByPremise(int premiseId)
        {
            return Service.All<Employee>(e => e.PremiseID == premiseId,
                e => e.PhoneNumbers, e => e.WorkLocations, e => e.EmployeeGroup);
        }

        public SalaryAndWage GetEmployeeSalaryAndWage(int employeeid)
        {
            return Service.Get<SalaryAndWage>(s => s.EmployeeID == employeeid);
        }

        public PaymentMethod GetEmployeePaymentMethod(int employeeid)
        {
            return Service.Get<PaymentMethod>(p => p.EmployeeID == employeeid);
        }

        public bool UpdateEmployees(params Employee[] employee)
        {
            return Service.Update(employee);
        }

    }
}
