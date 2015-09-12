using System.Runtime.Serialization;

namespace Com.Framework.Data
{
    public enum ImageType
    {
        [EnumMember(Value = "DEFAULT")]
        Default,
        [EnumMember(Value = "PRIMARY")]
        Primary,
        [EnumMember(Value = "SECONDARY")]
        Secondary
    }
}