using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;

namespace Restaurant.DataAccess
{
    public static class DbContextExtensions
    {
        public static ObjectContext ToObjectContext(this DbContext context)
        {
            return (context as IObjectContextAdapter).ObjectContext;
        }
    }
}
