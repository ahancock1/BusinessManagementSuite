using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using Com.Framework.Data;

namespace Com.Framework.DataAccess.Mapping
{
    public class UserMapping : EntityTypeConfiguration<User>
    {

        public UserMapping()
        {
            HasOptional(u => u.Credential).WithRequired(c => c.User);
        }

    }
}
