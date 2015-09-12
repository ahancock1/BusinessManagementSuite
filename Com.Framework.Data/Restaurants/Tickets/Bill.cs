using System;
using System.Runtime.Serialization;

namespace Com.Framework.Data.Restaurants.Tickets
{
    [DataContract]
    public class Bill
    {
        [DataMember]
        public int BillID { get; set; }

        [DataMember]
        public DateTime PaidDate { get; set; }
    }
}
