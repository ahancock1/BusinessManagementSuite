using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

using Restaurant.Data;

namespace Restaurant.DataAccess.Services
{
    public interface IGuestService
    {
        Guest GetByName(string name);

        IEnumerable<Guest> GetAll(); 

        bool Create(Guest guest);

        bool Update(Guest guest);

        bool Delete(int id);
    }

    public class GuestService : IGuestService
    {
        public Guest GetByName(string name)
        {
            using (var context = new RestaurantDbContext())
            {
                return context.Guests.SingleOrDefault(g => g.Name == name);
            }
        }

        public IEnumerable<Guest> GetAll()
        {
            using (var context = new RestaurantDbContext())
            {
                return context.Guests.ToList();
            }
        }

        public bool Create(Guest guest)
        {
            using (var context = new RestaurantDbContext())
            {
                context.Guests.Add(guest);
                return context.SaveChanges() > 0;
            }
        }

        public bool Update(Guest guest)
        {
            using (var context = new RestaurantDbContext())
            {
                context.Guests.Attach(guest);
                context.Entry(guest).State = EntityState.Modified;
                return context.SaveChanges() > 0;
            }
    }

        public bool Delete(int id)
        {
            using (var context = new RestaurantDbContext())
            {
                Guest guest = context.Guests.Find(id);
                context.Guests.Remove(guest);
                return context.SaveChanges() > 0;
            }
        }
    }
}
