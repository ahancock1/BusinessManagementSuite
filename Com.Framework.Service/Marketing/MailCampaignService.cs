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
        MailCampaign GetMailCampaign(int mailCampaignID);

        IEnumerable<MailCampaign> GetMailCampaignsByPremise(int premiseID);

        bool Update(params MailCampaign[] update);
    }


    public class MailCampaignService : BaseService
    {
        public MailCampaign GetMailCampaign(int mailCampaignID)
        {
            return Service.Get<MailCampaign>(m => m.MailCampaignID == mailCampaignID);
        }

        public IEnumerable<MailCampaign> GetMailCampaignByPremise(int premiseID)
        {
            return Service.All<MailCampaign>(m => m.PremiseID == premiseID);
        }

        public bool Update(params MailCampaign[] items)
        {
            return Service.Update(items);
        }

    }
}
