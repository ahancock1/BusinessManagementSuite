using System.Collections.Generic;
using System.ServiceModel;
using Com.Framework.Data;

// Done
namespace Com.Framework.Service
{
    [ServiceContract]
    public interface IPremiseService : IService
    {
        [OperationContract]
        Premise GetPremise(int premiseID);

        [OperationContract]
        IEnumerable<Premise> GetPremisesByOrganisation(int organisationID);

        [OperationContract]
        bool Update(params Premise[] items);
    }

    public class PremiseService : BaseService, IPremiseService
    {
        public Premise GetPremise(int premiseID)
        {
            return Service.Get<Premise>(p => p.PremiseID == premiseID,
                p => p.Addresses, p => p.PhoneNumbers, p => p.OpenHours, p => p.PaymentMethods,
                p => p.MenuCategories, p => p.EmployeeGroups, p => p.EmailAddresses, p => p.Departments);
        }

        public IEnumerable<Premise> GetPremisesByOrganisation(int organisationID)
        {
            return Service.All<Premise>(p => p.OrganisationID == organisationID,
                p => p.Addresses, p => p.PhoneNumbers, p => p.OpenHours, p => p.PaymentMethods,
                p => p.MenuCategories, p => p.EmployeeGroups, p => p.EmailAddresses, p => p.Departments);
        }

        public bool Update(params Premise[] items)
        {
            return Service.Update(items);
        }
    }
}
