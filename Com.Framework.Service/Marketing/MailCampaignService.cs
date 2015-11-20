using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Com.Framework.Data.Marketing;

namespace Com.Framework.Service.Marketing
{
    public interface IMailCampaignService
    {
        MailCampaign GetMailCampaign(int id);

        IEnumerable<MailCampaign> GetMailCampaignsByPremise(int premiseId);

        bool Update(params MailCampaign[] update);
    }


    public class MailCampaignService : BaseService
    {
        public MailCampaign GetMailCampaign(int id)
        {
            return Service.Get<MailCampaign>(m => m.Id == id);
        }

        public IEnumerable<MailCampaign> GetMailCampaignByPremise(int premiseId)
        {
            return Service.All<MailCampaign>(m => m.PremiseID == premiseId);
        }

        public bool Update(params MailCampaign[] items)
        {
            return Service.Update(items);
        }

    }
}
