using System;

namespace Com.Framework.Data
{
    public class Address : Entity
    {
        public int AddressID { get; set; }

        public AddressType AddressType { get; set; }

        public string House { get; set; }

        public string Street { get; set; }

        public string Town { get; set; }

        public string City { get; set; }

        public string Region { get; set; }

        public string PostalCode { get; set; }

        public string Country { get; set; }


        public Address()
        {
            AddressType = AddressType.Default;
        }

        public static bool Validate(Address address)
        {
            throw new NotImplementedException("Address velidation is not yet implemented");
        }
    }


}
