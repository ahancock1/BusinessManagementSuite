using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using Com.Framework.Services.Views;

namespace Com.Framework.Services.Messages.Membership
{
    [DataContract]
    public class CreateResponse : BaseResponse
    {
        [DataMember]
        public Guid UserId { get; set; }

        [DataMember]
        public ClaimIdentityView ClaimIdentity { get; set; }
    }
}