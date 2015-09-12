using System.Runtime.Serialization;

namespace Com.Framework.Data.PayRoll
{
    [DataContract]
    public enum PaymentSchedule
    {
        [EnumMember(Value = "WEEKLY")]
        Weekly,
        [EnumMember(Value = "BIWEEKLY")]
        BiWeekly,
        [EnumMember(Value = "MONTHLY")]
        Monthly,
        [EnumMember(Value = "SEMIMONTHLY")]
        SemiMonthly,
        [EnumMember(Value = "FIXEDLENGTH")]
        FixedLength,
        [EnumMember(Value = "CUSTOM")]
        Custom
    }
}
