using System.Collections.Generic;
using Com.Framework.Data;

namespace Com.Framework.Hubs.Core
{
    public interface IPremiseHub
    {

        void UpdatePremises(params Premise[] premises);
    }

    public class PremiseHub : ServiceHub<IPremiseHub>
    {
        public Premise GetPremise(int premiseID)
        {
            return Service.Get<Premise>(p => p.PremiseID == premiseID);
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
