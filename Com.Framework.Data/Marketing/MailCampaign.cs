using System;
using System.Runtime.Serialization;

namespace Com.Framework.Data.Marketing
{
    [DataContract]
    public class MailCampaign
    {
        public DateTime Start { get; set; }

        public DateTime End { get; set; }

        public int Occurance { get; set; }

        public string Subject { get; set; }

        public string Body { get; set; }

        public virtual Premise Premise { get; set; }
    }
}
