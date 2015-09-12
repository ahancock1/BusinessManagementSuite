namespace Com.Framework.Data
{
    public class Image : Entity
    {
        public int ImageID { get; set; }

        public ImageType ImageType { get; set; }

        public byte[] Data { get; set; }
    }
}