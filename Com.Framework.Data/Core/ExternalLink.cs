using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Com.Framework.Data
{
    [DataContract]
    public class ExternalLink : BaseEntity
    {
        [DataMember]
        public int ExternalLinkID { get; set; }

        [DataMember]
        public string Url { get; set; }

        [DataMember]
        public ExternalLinkType LinkType { get; set; }

        [DataMember]
        public string Description { get; set; }


        // Navigation Properties
        protected ICollection<Organisation> Organisations { get; set; }


        public ExternalLink()
        {
            Description = String.Empty;
        }
    }
}
