using System;
using System.Runtime.Serialization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.Framework.Data
{
    [DataContract]
    public class Email : BaseEntity
    {
        [DataMember]
        public int EmailID { get; set; }

        [DataMember]
        public string Address { get; set; }

        [DataMember]
        public bool Confirmed { get; set; }

        // Navigational Properties
        protected ICollection<Premise> Premises { get; set; }

        protected ICollection<Organisation> Organisations { get; set; }

        public Email() : this("") { }

        public Email(string address)
        {
            Address = address;
        }

        public static bool Validate(Email email)
        {
            throw new NotImplementedException("Email validation is not yet implemented");
        }

    }
}
