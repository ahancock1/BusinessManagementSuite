using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

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

    }
}