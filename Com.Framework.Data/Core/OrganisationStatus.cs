using System.Runtime.Serialization;

namespace Com.Framework.Data
{
    [DataContract]
    public enum PremiseStatus
    {
        [EnumMember(Value = "ACTIVE")]
        Active
    }
}