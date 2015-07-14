using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.Data.Accounting
{
    [DataContract]
    public class Review : Entity
    {
        [Key, DataMember]
        public int ReviewID { get; set; }

        [DataMember, Required, MaxLength(150, ErrorMessage = "Title must not exceed 150 characters")]
        public string Title { get; set; }

        [DataMember, Required]
        public string Content { get; set; }

        [DataMember, Required, Range(0, 5, ErrorMessage = "Rating must be between 0 and 5")]
        public int Rating { get; set; }

        [DataMember]
        public virtual User User { get; set; }

        [DataMember, Required]
        public virtual Venue Venue { get; set; }
    }
}
