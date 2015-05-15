using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Restaurant.Data;

namespace Restaurant.DataAccess.Services
{
    public interface IUserService
    {
        User GetByUsername(string username);

        IEnumerable<User> GetAll();

        bool Create(User user);

        bool Update(User user);

        bool Delete(int id);
    }

    public class UserService : IUserService
    {
        public User GetByUsername(string username)
        {
            using (var context = new RestaurantDbContext())
            {
                return context.Users.SingleOrDefault(u => u.Username == username);
            }
        }

        public IEnumerable<User> GetAll()
        {
            using (var context = new RestaurantDbContext())
            {
                return context.Users.ToList();
            }
        }
        
        public bool Create(User user)
        {
            using (var context = new RestaurantDbContext())
            {
                context.Users.Add(user);
                return context.SaveChanges() > 0;
            }
        }

        public bool Update(User user)
        {
            using (var context = new RestaurantDbContext())
            {
                context.Users.Attach(user);
                context.Entry(user).State = EntityState.Modified;
                return context.SaveChanges() > 0;
            }
        }

        public bool Delete(int id)
        {
            using (var context = new RestaurantDbContext())
            {
                User user = context.Users.Find(id);
                context.Users.Remove(user);
                return context.SaveChanges() > 0;
            }
        }
    }
}
