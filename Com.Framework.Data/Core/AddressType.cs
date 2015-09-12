using System.Runtime.Serialization;

namespace Com.Framework.Data
{
    public enum AddressType
    {
        [EnumMember(Value = "DEFAULT")]
        Default,
        [EnumMember(Value = "PRIMARY")]
        Primary,
        [EnumMember(Value = "SECONDARY")]
        Secondary,
        [EnumMember(Value = "WORK")]
        Work,
        [EnumMember(Value = "HOME")]
        Home
    }
}