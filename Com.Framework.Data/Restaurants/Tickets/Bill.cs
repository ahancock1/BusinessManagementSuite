using System;
using System.Runtime.Serialization;

namespace Com.Framework.Data.Restaurants.Tickets
{
    [DataContract]
    public class Bill
    {

        [DataMember]
        public DateTime PaidDate { get; set; }
    }
}
