using System;
using System.Runtime.Serialization;

namespace Com.Framework.Data
{
    [DataContract, Flags]
    public enum OrganisationCategory
    {
        [EnumMember(Value = "RESTAURANT")]
        Restaurant,
        [EnumMember(Value = "BAR")]
        Bar,
        [EnumMember(Value = "CLUB")]
        Club
    }
}