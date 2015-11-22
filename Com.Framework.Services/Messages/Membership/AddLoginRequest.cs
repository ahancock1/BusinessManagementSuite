using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Com.Framework.Services.Messages.Membership
{
    [DataContract]
    public class AddLoginRequest
    {
        [Required]
        [DataMember]
        public Guid UserId { get; set; }

        [Required]
        [DataMember]
        public string ProviderKey { get; set; }

        [Required]
        [DataMember]
        public string LoginProvider { get; set; }
    }
}