using System.Runtime.Serialization;
using Com.Framework.Services.Views;

namespace Com.Framework.Services.Messages.Membership
{
    [DataContract]
    public class CreateIdentityResponse : BaseResponse
    {
        [DataMember]
        public ClaimIdentityView ClaimIdentityView { get; set; }
    }
}