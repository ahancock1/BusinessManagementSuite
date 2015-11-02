using Com.Framework.Data;

namespace Com.Framework.Hubs
{
    public interface IOrganisationHub
    {
        void UpdateOrganisation(Organisation organisation);
    }

    public class OrganisationHub : ServiceHub
    {
        public Organisation GetOrganisation(int organisationID)
        {
            return Service.Get<Organisation>(o => o.OrganisationID == organisationID,
                o => o.OpenHours, o => o.Addresses, o => o.PhoneNumbers, o => o.ExternalLinks,
                o => o.Image);
        }

        public bool UpdateOrganisation(Organisation organisation)
        {
            if (organisation == null) return false;

            string name = organisation.Name;

            //Clients.Group(name).UpdateOrganisation(organisation);

            return Service.Update(organisation);
        }
    }
}
