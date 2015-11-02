using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Com.Framework.Data
{
    [DataContract]
    public class Image : BaseEntity
    {
        [DataMember]
        public int ImageID { get; set; }

        [DataMember]
        public ImageType ImageType { get; set; }

        [DataMember]
        public byte[] Data { get; set; }

        // Navigation Properties
        protected ICollection<Organisation> Organisations { get; set; }


        public Image()
        {
            ImageType = ImageType.Default;
        }


        public static Image DefaultImage()
        {
            // TODO read an image and store it
            return new Image
            {
                ImageID = 1
            };
        }
    }
}