using System;
using System.Runtime.Serialization;

namespace Com.Framework.Data
{
    [DataContract]
    public class ExternalLink : Entity
    {
        [DataMember]
        public int ExternalLinkID { get; set; }

        [DataMember]
        public string Url { get; set; }

        [DataMember]
        public ExternalLinkType LinkType { get; set; }

        [DataMember]
        public string Description { get; set; }

        public ExternalLink()
        {
            Description = String.Empty;
        }
    }
}
