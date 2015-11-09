using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Com.Framework.Data
{
    [DataContract]
    public class Image : Entity<long>
    {
        [DataMember]
        public ImageType ImageType { get; set; }

        [DataMember]
        public byte[] Data { get; set; }

        // Navigation Properties
        protected ICollection<Premise> Premises { get; set; }


        public Image()
        {
            ImageType = ImageType.Default;
        }

    }
}