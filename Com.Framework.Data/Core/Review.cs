using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Com.Framework.Data
{
    [DataContract]
    public class Review : Entity
    {
        [DataMember]
        public int ReviewID { get; set; }

        [DataMember, Required, MaxLength(150, ErrorMessage = "Subject must not exceed 150 characters")]
        public string Subject { get; set; }

        [DataMember, Required]
        public string Content { get; set; }

        [DataMember, Required, Range(0, 10, ErrorMessage = "Rating must be between 0 and 10")]
        public int Rating { get; set; }

        [DataMember]
        public User User { get; set; }

        protected virtual Premise Premise { get; set; }
    }
}
