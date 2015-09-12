using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Com.Framework.Data
{
    [DataContract]
    public class PhoneNumber : Entity
    {
        [DataMember]
        public int PhoneNumberID { get; set; }

        [DataMember]
        public string CountryCode { get; set; }

        [DataMember]
        public string NationalNumber { get; set; }

        [DataMember]
        public PhoneType PhoneType { get; set; }


        public bool Validate(PhoneNumber phoneNumber)
        {
            throw new NotImplementedException("Phone number validation is not yet implemented.");
        }
    }
}
