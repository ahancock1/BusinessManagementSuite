using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Com.Framework.Data.Restaurants.Tables;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Com.Framework.Data
{
    [DataContract]
    public class User : Entity<long>
    {
        [DataMember, Required(ErrorMessage = "{0} is required.")]
        public string Username { get; set; }

        [DataMember, Required(ErrorMessage = "{0} is required.")]
        public string FirstName { get; set; }

        [DataMember, Required(ErrorMessage = "{0} is required.")]
        public string LastName { get; set; }

        [DataMember]
        [EmailAddress, Required(ErrorMessage = "{0} is required.")]
        public Email Email { get; set; }

        [DataMember]
        public Image Image { get; set; }

        [DataMember]
        public bool? IsSubscribed { get; set; }

        [DataMember]
        public virtual Credential Credential { get; set; }

        [NotMapped]
        public string Password { get; set; }

        public string Confirm

        protected virtual ICollection<Review> Reviews { get; set; }

        protected virtual ICollection<Reservation> Reservations { get; set; }

        protected virtual Premise Premise { get; set; }


        public string FullName => String.Format("{0} {1}", FirstName, LastName);
    }
}