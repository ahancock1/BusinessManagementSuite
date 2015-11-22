using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Com.Framework.Services.Messages.Membership
{
    [DataContract]
    public class RemoveLoginRequest : BaseRequest
    {
        [Required]
        [DataMember]
        public Guid UserId { get; set; }

        [Required]
        [DataMember]
        public string LoginProvider { get; set; }

        [Required]
        [DataMember]
        public string ProviderKey { get; set; }
    }
}