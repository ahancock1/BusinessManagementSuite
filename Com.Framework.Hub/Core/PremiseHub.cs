using System.Collections.Generic;
using Com.Framework.Data;

namespace Com.Framework.Hubs.Core
{
    public interface IPremiseHub
    {
        Premise GetPremise(int premiseID);

        IEnumerable<Premise> GetPremisesByOrganisation(int organisationID);

        bool UpdatePremises(string name, params Premise[] premises);
    }

    public interface IPremiseContract
    {
        void UpdatePremises(params Premise[] premises);
    }

    public class PremiseHub : ServiceHub<IPremiseContract>, IPremiseHub
    {
        public Premise GetPremise(int id)
        {
            return Service.Get<Premise>(p => p.Id == id);
        }

        public IEnumerable<Premise> GetPremisesByOrganisation(int organisationID)
        {
            return Service.All<Premise>(p => p.OrganisationID == organisationID);
        }

        public bool UpdatePremises(string name, params Premise[] premises)
        {
            if (premises.Length == 0) return false;

            Clients.Group(name).UpdatePremises(premises);

            return Service.Update(premises);
        }
    }
}
