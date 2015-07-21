using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Data.Management.Inventory
{
    public class Supplier
    {
        public int SupplierID { get; set; }

        public string Name { get; set; }


        public Supplier()
        {

        }

    }


    public struct Address
    {
        public int AddressID { get; set; }

        public int House { get; set; }

        public string Postcode { get; set; }

        public string Street { get; set; }

        public string City { get; set; }

        public string County { get; set; }

        public string Country { get; set; }


        public static bool Validate(Address address)
        {

        }
    }

}
