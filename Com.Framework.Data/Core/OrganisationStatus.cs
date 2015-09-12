using System.Runtime.Serialization;

namespace Com.Framework.Data
{
    [DataContract]
    public enum OrganisationStatus
    {
        [EnumMember(Value = "ACTIVE")]
        Active
    }
}