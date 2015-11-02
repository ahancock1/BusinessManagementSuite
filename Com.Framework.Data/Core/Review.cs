using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Com.Framework.Data
{
    [DataContract]
    public class Review : BaseEntity
    {
        [DataMember]
        public int ReviewID { get; set; }

        [DataMember]
        public int PremiseID { get; set; }

        [DataMember]
        public int UserID { get; set; }

        [DataMember, Required, MaxLength(25, ErrorMessage = "{0} can have a max of {1} characters")]
        public string Subject { get; set; }

        [DataMember, Required]
        public string Content { get; set; }

        [DataMember, Required, Range(0, 10, ErrorMessage = "Rating must be between 0 and 10")]
        public int Rating { get; set; }

        [DataMember]
        public User User { get; set; }


        // Navigational Properties
        protected virtual Premise Premise { get; set; }


        public Review()
        {


        }
    }
}
