using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestuarantServer.Data;

namespace RestaurantServer.DataAccess
{
    public class UserTypeMap : EntityTypeConfiguration<UserType>
    {
        public UserTypeMap()
        {
            Property(u => u.Name).HasMaxLength(12).IsRequired();
        }


    }
}
