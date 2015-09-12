using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Com.Framework.Data.Restaurants.Tables;
using Com.Framework.Data.Restaurants.Menus;

namespace Com.Framework.Data.Restaurants
{
    [DataContract, Table("Restaurants")]
    public class Restaurant : Premise
    {
        [Key, DataMember]
        public int RestaurantID { get; set; }

        [DataMember]
        protected virtual ICollection<Table> Tables { get; set; }

        [DataMember]
        public virtual ICollection<Menu> Menus { get; set; }

        [DataMember]
        protected virtual ICollection<Reservation> Reservations { get; set; }

        [DataMember]
        public int Capacity { get; set; }

        [DataMember]
        public int FoodRating { get; set; }

        public ICollection<Facility> Facilities { get; set; }

        [DataMember]
        public ICollection<Ambience> Ambience { get; set; }

        [DataMember]
        public ICollection<Cuisine> Cuisines { get; set; }
    }
}

