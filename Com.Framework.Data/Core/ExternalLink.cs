using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Com.Framework.Data
{
    [DataContract]
    public class ExternalLink : Entity<long>
    {
        [DataMember]
        public string Url { get; set; }

        [DataMember]
        public ExternalLinkType LinkType { get; set; }

        [DataMember]
        public string Description { get; set; }


        // Navigation Properties
        protected ICollection<Premise> Premises { get; set; }


        public ExternalLink()
        {
            Description = String.Empty;
        }
    }
}
