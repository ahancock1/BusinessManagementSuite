using System.Runtime.Serialization;

namespace Com.Framework.Data.Rotas
{
    [DataContract]
    public enum ShiftType
    {
        [EnumMember(Value = "NORMAL")]
        Normal,
        [EnumMember(Value = "SPLIT")]
        Split
    }
}