using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Com.Framework.Services.Messages
{
    public enum AuthenticationType
    {
        [EnumMember(Value = "ApplicationCookie")]
        ApplicationCookie = 0,
        [EnumMember(Value = "ExternalCookie")]
        ExternalCookie = 1,
        [EnumMember(Value = "ExternalBearer")]
        ExternalBearer
    }
}