using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using Com.Framework.Services.Views;

namespace Com.Framework.Services.Messages.Membership
{
    [DataContract]
    public class FindByIdResponse : BaseResponse
    {
        [DataMember]
        public UserView UserView { get; set; }
    }
}