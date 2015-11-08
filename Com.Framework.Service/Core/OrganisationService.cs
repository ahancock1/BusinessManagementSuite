using System.ServiceModel;
using Com.Framework.Data;

namespace Com.Framework.Service
{
    [ServiceContract]
    public interface IOrganisationService : IService
    {
        [OperationContract]
        Organisation GetOrganisation(int organisationID);

        [OperationContract]
        bool Update(params Organisation[] items);

    }

    public class OrganisationService : BaseService, IOrganisationService
    {
        public Organisation GetOrganisation(int id)
        {
            return Service.Get<Organisation>(o => o.Id == id,
                o => o.OpenHours, o => o.Addresses, o => o.PhoneNumbers, o => o.ExternalLinks,
                o => o.Image);
        }

        public bool Update(params Organisation[] items)
        {
            return Service.Update(items);
        }

    }
}
