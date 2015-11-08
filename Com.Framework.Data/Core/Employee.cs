using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Com.Framework.Data.PayRoll;
using Newtonsoft.Json;

namespace Com.Framework.Data
{
    [DataContract]
    public class Employee : AuditableEntity<long>
    {
        #region Keys

        [DataMember]
        public int PremiseID { get; set; }

        //[DataMember]
        //public int PaymentMethodID { get; set; }

        //[DataMember]
        //public int DepartmentID { get; set; }

        [DataMember]
        public int EmployeeGroupID { get; set; }

        [DataMember]
        public int EmailID { get; set; }

        //[DataMember]
        //public PaymentMethod PaymentMethod { get; set; }

        #endregion

        #region Properties
        [DataMember]
        public string FirstName { get; set; }

        [DataMember]
        public string LastName { get; set; }

        [DataMember]
        public string MiddleNames { get; set; }

        [DataMember]
        public string Title { get; set; }

        [DataMember]
        public string UserName { get; set; }

        [DataMember]
        public int AccessFailedCount { get; set; }

        [DataMember]
        public bool LockoutEnabled { get; set; }

        [DataMember]
        public DateTime LockoutEndDate { get; set; }

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
        public EmploymentStatus EmploymentStatus
            => TerminationDate == null ? EmploymentStatus.Active : EmploymentStatus.Terminated;

        [DataMember]
        public EmployeeGroup EmployeeGroup { get; set; }

        //[DataMember]
        //public virtual TerminalCredential TerminalCredential { get; set; }


        #endregion

        #region Navigation Properties

        [JsonIgnore]
        public virtual Premise Premise { get; set; }

        #endregion

        public Employee()
        {

        }

        public override string ToString()
        {
            return String.Format("{0} {1} {2}", Title, FirstName, LastName);
        }
    }
}
