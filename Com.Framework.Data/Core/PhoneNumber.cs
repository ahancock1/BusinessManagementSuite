using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Com.Framework.Data
{
    [DataContract]
    public class PhoneNumber : BaseEntity
    {
        [DataMember]
        public int PhoneNumberID { get; set; }

        [DataMember]
        public string CountryCode { get; set; }

        [DataMember]
        public string NationalNumber { get; set; }

        [DataMember]
        public PhoneType PhoneType { get; set; }


        // Navigation Properties
        protected ICollection<Organisation> Organisations { get; set; }


        public PhoneNumber() : this("", "")
        {
        }

        public PhoneNumber(string countryCode, string nationalNumber)
        {
            CountryCode = countryCode;
            NationalNumber = nationalNumber;
            PhoneType = PhoneType.Default;
        }


        public bool Validate(PhoneNumber phoneNumber)
        {
            throw new NotImplementedException("Phone number validation is not yet implemented.");
        }
    }
}
