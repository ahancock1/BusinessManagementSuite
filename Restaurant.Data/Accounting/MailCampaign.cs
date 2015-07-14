using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Data.Accounting
{
    [DataContract]
    public class MailCampaign
    {
        public DateTime Start { get; set; }

        public DateTime End { get; set; }

        public int Occurance { get; set; }

        public string Subject { get; set; }

        public string Body { get; set; }

        public virtual Venue Venue { get; set; }
    }
}
