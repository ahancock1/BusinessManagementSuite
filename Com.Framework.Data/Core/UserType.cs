namespace Com.Framework.Data
{
    public class UserType : BaseEntity
    {
        public int UserTypeID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}