using Com.Framework.Data;

namespace Com.Framework.Hubs
{
    //public interface IOrganisationHub
    //{
    //    Organisation GetOrganisation(int organisationID);

    //    bool UpdateOrganisation(Organisation organisation);
    //}

    //public interface IOrganisationContract
    //{
    //    void UpdateOrganisation(Organisation organisation);
    //}

    //public class OrganisationHub : ServiceHub<IOrganisationContract>, IOrganisationHub
    //{
    //    public Organisation GetOrganisation(int id)
    //    {
    //        return Service.Get<Organisation>(o => o.Id == id,
    //            o => o.OpenHours, o => o.Addresses, o => o.PhoneNumbers, o => o.ExternalLinks,
    //            o => o.Image);
    //    }

    //    public bool UpdateOrganisation(Organisation organisation)
    //    {
    //        if (organisation == null) return false;

    //        string name = organisation.Name;

    //        //Clients.Group(name).UpdateOrganisation(organisation);

    //        return Service.Update(organisation);
    //    }
    //}
}
