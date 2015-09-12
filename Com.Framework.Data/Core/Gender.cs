using System.Runtime.Serialization;

namespace Com.Framework.Data
{
    [DataContract]
    public enum Gender
    {
        [EnumMember(Value = "MALE")]
        Male,
        [EnumMember(Value = "FEMALE")]
        Female,
        [EnumMember(Value = "OTHER")]
        Other
    }
}