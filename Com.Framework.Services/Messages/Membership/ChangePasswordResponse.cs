using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Com.Framework.Services.Messages.Membership
{
    [DataContract]
    public class ChangePasswordResponse : BaseResponse
    {
        [DataMember]
        public bool PasswordChanged { get; set; }
    }
}