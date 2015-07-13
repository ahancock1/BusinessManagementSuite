using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Restaurant.Data.Accounting
{
    [DataContract]
    public class VenueType : Entity
    {
        public int VenueTypeID { get; set; }

        [Required, DataMember]
        public string Name { get; set; }

        public virtual ICollection<Venue> Restaurants { get; set; }
    }

    [DataContract]
    public class Venue : Entity
    {
        [DataMember]
        public int VenueID { get; set; }

        [Required, DataMember]
        public string Name { get; set; }

        [Required, DataMember]
        public string Description { get; set; }

        [DataMember]
        public float Rating { get; set; }

        [DataMember]
        public string Url { get; set; }

        public virtual ICollection<User> Users { get; set; }

        public virtual VenueType RestaurantType { get; set; }

        public virtual Account Account { get; set; }

        public virtual IList<VenueReview> Reviews { get; set; }

        public Venue()
        {
            Name = String.Empty;
            Description = String.Empty;
        }

        public float GetUserRating()
        {
            if (Reviews != null)
            {
                return Reviews.Sum(r => r.Rating) / Reviews.Count;
            }
            return 0f;
        }
    }

}
