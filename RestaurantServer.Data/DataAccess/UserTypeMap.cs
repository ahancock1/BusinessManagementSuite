using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using RestaurantServer.Data.DataModel;

namespace RestaurantServer.Data.DataAccess
{
    public class UserTypeMap : EntityTypeConfiguration<UserType>
    {
        public UserTypeMap()
        {
            Property(u => u.Name).HasMaxLength(12).IsRequired();
        }


    }
}