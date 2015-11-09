namespace Com.Framework.Data
{
    public class UserType : Entity<long>
    {
        public int UserTypeID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}