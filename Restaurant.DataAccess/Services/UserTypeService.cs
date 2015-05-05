using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Restaurant.Data;

namespace Restaurant.DataAccess.Services
{
    public interface IUserTypeService
    {
        UserType GetById(int id);

        IEnumerable<UserType> GetAll();

        bool Create(UserType userType);

        bool Update(UserType userType);

        bool Delete(int id);
    }

    public class UserTypeService : IUserTypeService
    {
        public UserType GetById(int id)
        {
            using (var context = new RestaurantDbContext())
            {
                return context.UserTypes.SingleOrDefault(u => u.UserTypeID == id);
            }
        }

        public IEnumerable<UserType> GetAll()
        {
            using (var context = new RestaurantDbContext())
            {
                return context.UserTypes;
            }
        }

        public bool Create(UserType userType)
        {
            using (var context = new RestaurantDbContext())
            {
                context.UserTypes.Add(userType);
                return context.SaveChanges() > 0;
            }
        }

        public bool Update(UserType userType)
        {
            using (var context = new RestaurantDbContext())
            {
                context.UserTypes.Attach(userType);
                context.Entry(userType).State = EntityState.Modified;
                return context.SaveChanges() > 0;
            }
        }

        public bool Delete(int id)
        {
            using (var context = new RestaurantDbContext())
            {
                UserType userType = context.UserTypes.Find(id);
                context.UserTypes.Remove(userType);
                return context.SaveChanges() > 0;
            }
        }
    }
}
