using System;
using System.Collections.Generic;

namespace RestaurantServer.Data.DataModel
{
    public class UserType 
    {
        public int UserTypeID { get; set; }

        public string Name { get; set; }

        public virtual ICollection<User> Users { get; set; }

        public UserType()
        {
            Name = String.Empty;
        }
        
        public override string ToString()
        {
            return String.Format("UserType: {0}", Name);
        }
    }
}