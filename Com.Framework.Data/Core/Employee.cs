using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Com.Framework.Data.PayRoll;

namespace Com.Framework.Data
{
    [DataContract]
    public class Employee : Entity
    {
        [DataMember]
        public int EmployeeID { get; set; }

        [DataMember]
        public string FirstName { get; set; }

        [DataMember]
        public string LastName { get; set; }

        [DataMember]
        public string MiddleNames { get; set; }

        [DataMember]
        public string Title { get; set; }

        [DataMember]
        public string Username { get; set; }

        [DataMember]
        public Gender Gender { get; set; }

        [DataMember]
        public DateTime? BirthDate { get; set; }

        [DataMember]
        public Email Email { get; set; }

        [DataMember]
        public ICollection<PhoneNumber> PhoneNumbers { get; set; }

        [DataMember]
        public DateTime? StartDate { get; set; }

        [DataMember]
        public DateTime? HiredDate { get; set; }

        [DataMember]
        public DateTime? TerminationDate { get; set; }

        [DataMember]
        public string JobTitle { get; set; }

        [DataMember]
        public string EmployeeNumber { get; set; }

        [DataMember]
        public string NationalInsuranceNumber { get; set; }

        [DataMember]
        public EmploymentType EmploymnentBasis { get; set; }

        [DataMember]
        public PaymentSchedule PaymentSchedule { get; set; }

        [DataMember]
        public ICollection<Address> WorkLocations { get; set; }

        [DataMember]
        public ICollection<SalaryAndWage> SalaryAndWages { get; set; }

        [DataMember]
        public PaymentMethod PaymentMethod { get; set; }

        [DataMember]
        public EmploymentStatus EmploymentStatus
            => TerminationDate == null ? EmploymentStatus.Active : EmploymentStatus.Terminated;

        [DataMember]
        public EmployeeGroup EmployeeGroup { get; set; }

        [DataMember]
        public TerminalCredential TerminalCredential { get; set; }
    }
}
