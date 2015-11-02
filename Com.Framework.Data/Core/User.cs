using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Com.Framework.Data.Restaurants.Tables;

namespace Com.Framework.Data
{
    [DataContract]
    public class User : BaseEntity
    {
        [DataMember]
        public int UserID { get; set; }

        [DataMember]
        public string Username { get; set; }

        [DataMember]
        public string FirstName { get; set; }

        [DataMember]
        public string LastName { get; set; }

        [DataMember]
        public Email Email { get; set; }

        [DataMember]
        public Gender Gender { get; set; }

        [DataMember]
        public Image Image { get; set; }

        [DataMember]
        public bool? IsSubscribed { get; set; }

        [DataMember]
        public virtual Credential Credential { get; set; }

        [DataMember]
        public UserGroup UserGroup { get; set; }

        [DataMember]
        public UserType UserType { get; set; }

        protected virtual ICollection<Review> Reviews { get; set; }

        protected virtual ICollection<Reservation> Reservations { get; set; }



        public string FullName => String.Format("{0}, {1}", LastName, FirstName);
    }
}