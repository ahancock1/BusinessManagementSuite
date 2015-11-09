using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Com.Framework.Data.Pos
{
    [DataContract]
    public enum TerminalState
    {
        [EnumMember(Value = "ONLINE")]
        Online
    }

    [DataContract]
    public class Terminal : Entity<long>
    {

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public TerminalState TerminalState { get; set; }

        [DataMember]
        public Employee Operator { get; set; }

        public virtual ICollection<TerminalHistory> TerminalHistory { get; set; }
    }

    [DataContract]
    public class TerminalHistory : Entity<long>
    {

        [DataMember]
        public virtual Terminal Terminal { get; set; }

        [DataMember]
        public virtual Employee Employee { get; set; }

        [DataMember]
        public DateTime Timestamp { get; set; }

        /// <summary>
        /// The amount of money present in the till when the 
        /// employee logs into the termnial
        /// </summary>
        [DataMember]
        public CashFloat CashFloat { get; set; }
    }

    public class CashFloat
    {

        public Currency Currency { get; set; }


    }

    public class Currency
    {

    }

    /// <summary>
    /// This is an Xml file stored locally on the terminal
    /// </summary>
    [DataContract]
    public class TerminalConfig
    {
        public static string FilePath = "";

        [DataMember]
        public Terminal Terminal { get; set; }

        [DataMember]
        public string IpAddress { get; set; }

        [DataMember]
        public TerminalType TerminalType { get; set; }

    }

    [DataContract]
    public enum TerminalType
    {
        [EnumMember(Value = "DEFAULT")]
        Default,
        [EnumMember(Value = "MAIN")]
        Main
    }
}
