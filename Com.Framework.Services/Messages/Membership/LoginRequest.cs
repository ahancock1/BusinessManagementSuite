using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Com.Framework.Services.Messages
{
    [DataContract]
    public class LoginRequest : BaseRequest
    {
        [Required]
        [DataMember]
        public string UserName { get; set; }

        [Required]
        [DataMember]
        public string Password { get; set; }

        [DataMember]
        public bool RememberMe { get; set; }

        [DataMember]
        public bool ShouldLockout { get; set; }
    }
}