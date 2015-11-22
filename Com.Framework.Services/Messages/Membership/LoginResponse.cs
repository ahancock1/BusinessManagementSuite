using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using Com.Framework.Services.Views;

namespace Com.Framework.Services.Messages
{
    [DataContract]
    public class LoginResponse : BaseResponse
    {
        [DataMember]
        public ClaimIdentityView ClaimIdentity { get; set; }
    }
}