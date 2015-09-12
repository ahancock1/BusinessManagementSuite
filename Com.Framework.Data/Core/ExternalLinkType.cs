using System.Runtime.Serialization;

namespace Com.Framework.Data
{
    [DataContract]
    public enum ExternalLinkType
    {
        [EnumMember(Value = "WEBSITE")]
        Website,
        [EnumMember(Value = "FACEBOOK")]
        Facebook,
        [EnumMember(Value = "GOOGLEPLUS")]
        GooglePlus,
        [EnumMember(Value = "LINKEDIN")]
        LinkedIn,
        [EnumMember(Value = "TWITTER")]
        Twitter
    }
}