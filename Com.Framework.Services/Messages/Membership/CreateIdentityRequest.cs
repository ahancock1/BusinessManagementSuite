using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Com.Framework.Services.Messages.Membership
{
    [DataContract]
    public class CreateIdentityRequest : BaseRequest
    {
        [Required]
        [DataMember]
        public string UserName { get; set; }

        [Required]
        [DataMember]
        public AuthenticationType AuthenticationType { get; set; }

    }
}