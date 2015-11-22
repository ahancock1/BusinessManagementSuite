using System.Collections.Generic;
using System.Runtime.Serialization;
using Com.Framework.Services.Views;

namespace Com.Framework.Services.Messages.Membership
{
    [DataContract]
    public class GetLoginsResponse : BaseResponse
    {
        [DataMember]
        public IList<LoginView> LinkedAccounts { get; set; }
    }
}