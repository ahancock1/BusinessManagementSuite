using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using Com.Framework.Services.Messages;

namespace Com.Framework.Services.Views
{
    [DataContract]
    public class ClaimIdentityView
    {
        [DataMember]
        public Guid UserId { get; set; }

        [DataMember]
        public AuthenticationType AuthenticationType { get; set; }

        [DataMember]
        public IList<ClaimView> ClaimViews { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string NameClaimType { get; set; }

        [DataMember]
        public string RoleClaimType { get; set; }

        public ClaimIdentityView()
        {
            ClaimViews = new List<ClaimView>();
        }
    }
}
