using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Com.Framework.Services.Views
{
    [DataContract]
    public class ClaimIdentityView
    {
        [DataMember]
        public Guid UserId { get; set; }

        //[DataMember]
        //public AuthenticationTypeEnum AuthenticationType { get; set; }

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