using System.Collections.Generic;
using System.ServiceModel;
using Com.Framework.Data;

// Done
namespace Com.Framework.Services
{
    [ServiceContract]
    public interface IPremiseService : IService
    {
        [OperationContract]
        Premise GetPremise(int id);

        [OperationContract]
        IEnumerable<Premise> GetPremisesByOrganisation(int id);

        [OperationContract]
        bool Update(params Premise[] items);
    }

    public class PremiseService : BaseService, IPremiseService
    {
        public Premise GetPremise(int id)
        {
            return Service.Get<Premise>(p => p.Id == id,
                p => p.Addresses, p => p.PhoneNumbers, p => p.OpenHours, p => p.PaymentMethods,
                p => p.MenuCategories, p => p.EmployeeGroups, p => p.EmailAddresses, p => p.Departments);
        }

        public IEnumerable<Premise> GetPremisesByOrganisation(int id)
        {
            return Service.All<Premise>(p => p.Id == id,
                p => p.Addresses, p => p.PhoneNumbers, p => p.OpenHours, p => p.PaymentMethods,
                p => p.MenuCategories, p => p.EmployeeGroups, p => p.EmailAddresses, p => p.Departments);
        }

        public bool Update(params Premise[] items)
        {
            return Service.Update(items);
        }
    }
}
