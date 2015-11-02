using System;
using System.Runtime.Serialization;

namespace Com.Framework.Data.Marketing
{
    [DataContract]
    public class MailCampaign : BaseEntity
    {
        #region Keys

        [DataMember]
        public int MailCampaignID { get; set; }

        [DataMember]
        public int PremiseID { get; set; }

        #endregion

        #region Properties

        [DataMember]
        public DateTime Start { get; set; }

        [DataMember]
        public DateTime End { get; set; }

        [DataMember]
        public int Occurance { get; set; }

        [DataMember]
        public string Subject { get; set; }

        [DataMember]
        public string Body { get; set; }

        #endregion

        #region Navigation Properties

        public virtual Premise Premise { get; set; }


        #endregion

        public MailCampaign()
        {

        }
    }
}
