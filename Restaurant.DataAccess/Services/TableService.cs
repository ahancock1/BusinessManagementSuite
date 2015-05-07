using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

using Restaurant.Data;

namespace Restaurant.DataAccess.Services
{
    public interface ITableService
    {
        Table GetByNumber(int number);

        IEnumerable<Table> GetAll(); 

        bool Create(Table table);

        bool Update(Table table);

        bool Delete(int id);
    }

    public class TableService : ITableService
    {
        public Table GetByNumber(int number)
        {
            using (var context = new RestaurantDbContext())
            {
                return context.Tables.SingleOrDefault(t => t.Number == number);
            }
        }

        public IEnumerable<Table> GetAll()
        {
            using (var context = new RestaurantDbContext())
            {
                return context.Tables.ToList();
            }
        } 

        public bool Create(Table table)
        {
            using (var context = new RestaurantDbContext())
            {
                context.Tables.Add(table);
                return context.SaveChanges() > 0;
            }
        }

        public bool Update(Table table)
        {
            using (var context = new RestaurantDbContext())
            {
                context.Tables.Attach(table);
                context.Entry(table).State = EntityState.Modified;
                return context.SaveChanges() > 0;
            }
        }

        public bool Delete(int id)
        {
            using (var context = new RestaurantDbContext())
            {
                Table table = context.Tables.Find(id);
                context.Tables.Remove(table);
                return context.SaveChanges() > 0;
            }
        }
    }
}
