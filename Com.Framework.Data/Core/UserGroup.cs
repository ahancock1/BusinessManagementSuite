namespace Com.Framework.Data
{
    public class UserGroup : Entity<long>
    {
        public int UserGroupID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}