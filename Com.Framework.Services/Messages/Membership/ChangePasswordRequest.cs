using System;
using System.Runtime.Serialization;

namespace Com.Framework.Services.Messages.Membership
{
    [DataContract]
    public class ChangePasswordRequest : BaseRequest
    {
        [DataMember]
        public Guid UserId { get; set; }

        [DataMember]
        public string OldPassword { get; set; }

        [DataMember]
        public string NewPassword { get; set; }
    }
}