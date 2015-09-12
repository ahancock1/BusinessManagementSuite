using System.Runtime.Serialization;

namespace Com.Framework.Data
{
    [DataContract]
    public enum EmploymentStatus
    {
        [EnumMember(Value = "ACTIVE")]
        Active,
        [EnumMember(Value = "TERMINATED")]
        Terminated
    }
}