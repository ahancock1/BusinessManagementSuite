using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Com.Framework.Services.Views
{
    [DataContract]
    public class LoginView
    {
        [Required]
        [DataMember]
        public string LoginProvider { get; set; }

        [Required]
        [DataMember]
        public string ProviderKey { get; set; }
    }
}