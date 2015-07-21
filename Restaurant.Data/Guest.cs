using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Restaurant.Data
{
    /// <summary>
    /// Class containing customer information
    /// </summary>
    [DataContract]
    public class User : Entity
    {
        [Key, DataMember]
        public int GuestID { get; set; }

        [DataMember]
        public string FirstName { get; set; }

        [DataMember]
        public string LastName { get; set; }

        [DataMember]
        public string Address { get; set; }

        [DataMember]
        public string House { get; set; }

        [DataMember]
        public string PostCode { get; set; }

        [DataMember]
        public string PhoneNumber { get; set; }

        [DataMember]
        public string Email { get; set; }

        [DataMember]
        public string Username { get; set; }

        [DataMember]
        public Credential Credential { get; set; }



        public string FullName
        {
            get { return String.Format("{0}, {1}", LastName, FirstName); }
        }
    }
}
