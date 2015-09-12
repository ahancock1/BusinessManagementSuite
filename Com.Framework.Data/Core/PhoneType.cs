using System.Runtime.Serialization;

namespace Com.Framework.Data
{
    [DataContract]
    public enum PhoneType
    {
        [EnumMember(Value = "DEAFULT")]
        Default,
        [EnumMember(Value = "MOBILE")]
        Mobile,
        [EnumMember(Value = "LADNLINE")]
        LandLine,
        [EnumMember(Value = "FAX")]
        Fax
    }
}