using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Com.Framework.Services.Messages.Membership
{
    [DataContract]
    public class LoginExternalRequest : BaseRequest
    {

        [Required]
        [DataMember]
        public string ProviderKey { get; set; }

        [Required]
        [DataMember]
        public string LoginProvider { get; set; }

        [Required]
        [DataMember]
        public AuthenticationType AuthenticationType { get; set; }
    }
}