using System;
using System.Runtime.Serialization;

namespace Com.Framework.Data
{
    [DataContract, Flags]
    public enum PremiseCategory
    {
        [EnumMember(Value = "RESTAURANT")]
        Restaurant,
        [EnumMember(Value = "BAR")]
        Bar,
        [EnumMember(Value = "CLUB")]
        Club
    }
}