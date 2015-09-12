using System.Runtime.Serialization;

namespace Com.Framework.Data
{
    [DataContract]
    public enum EmploymentType
    {
        [EnumMember(Value = "FULLTIME")]
        FullTime,
        [EnumMember(Value = "PARTTIME")]
        PartTime,
        [EnumMember(Value = "PAIDLEAVE")]
        PaidLeave,
        [EnumMember(Value = "UNPAIDLEAVE")]
        UnpaidLeave
    }
}