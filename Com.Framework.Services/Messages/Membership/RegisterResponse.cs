using System;
using System.Runtime.Serialization;
using Com.Framework.Services.Views;

namespace Com.Framework.Services.Messages
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