using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Com.Framework.Data
{
    [DataContract]
    public class Address : Entity<long>
    {
        [DataMember]
        public AddressType AddressType { get; set; }

        [DataMember]
        public string House { get; set; }

        [DataMember]
        public string Street { get; set; }

        [DataMember]
        public string Town { get; set; }

        [DataMember]
        public string City { get; set; }

        [DataMember]
        public string Region { get; set; }

        [DataMember]
        public string PostalCode { get; set; }

        [DataMember]
        public string Country { get; set; }

        // Navigation Properties
        protected ICollection<Employee> Employees { get; set; }

        protected ICollection<Premise> Premises { get; set; }

        //protected ICollection<Organisation> Organisations { get; set; }


        public Address()
        {
            AddressType = AddressType.Default;
        }

        public static bool Validate(Address address)
        {
            throw new NotImplementedException("Address validation is not yet implemented");
        }
    }


}
