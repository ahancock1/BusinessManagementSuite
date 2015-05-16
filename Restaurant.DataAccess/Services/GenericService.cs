using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;

using DataEntityState = Restaurant.Data.EntityState;
using IEntity = Restaurant.Data.IEntity;

namespace Restaurant.DataAccess.Services
{
    public interface IGenericService<T> where T : class, IEntity
    {
        IList<T> GetAll(params Expression<Func<T, object>>[] navigationProperties);

        IList<T> GetAll(Func<T, bool> where, params Expression<Func<T, object>>[] navigationProperties);

        T Get(Func<T, bool> where, params Expression<Func<T, object>>[] navigationProperties);

//        bool Create(params T[] items);

        bool Update(params T[] items);

//        bool Delete(params T[] items);
    }

    public class GenericService<T> : IGenericService<T> where T : class, IEntity
    {
        public virtual IList<T> GetAll(params Expression<Func<T, object>>[] navigationProperties)
        {
            using (var context = new RestaurantDbContext())
            {
                return GetQuery(context, navigationProperties).AsNoTracking().ToList();
            }
        }

        public virtual IList<T> GetAll(Func<T, bool> @where, params Expression<Func<T, object>>[] navigationProperties)
        {
            using (var context = new RestaurantDbContext())
            {
                return GetQuery(context, navigationProperties).AsNoTracking().Where(where).ToList();
            }
        }

        public virtual T Get(Func<T, bool> @where, params Expression<Func<T, object>>[] navigationProperties)
        {
            using (var context = new RestaurantDbContext())
            {
                return GetQuery(context, navigationProperties).AsNoTracking().FirstOrDefault(where);
            }
        }
//
//        public virtual bool Create(params T[] items)
//        {
//            return Update(items);
//        }

        public virtual bool Update(params T[] items)
        {
            using (var context = new RestaurantDbContext())
            {
                DbSet<T> dbSet = context.Set<T>();
                foreach (T item in items)
                {
                    dbSet.Add(item);
                    foreach (DbEntityEntry<IEntity> entry in context.ChangeTracker.Entries<IEntity>())
                    {
                        entry.State = GetEntityState(entry.Entity.EntityState);
                    }
                }
                return context.SaveChanges() > 0;
            }
        }
//
//        public virtual bool Delete(params T[] items)
//        {
//            return Update(items);
//        }

        protected static IQueryable<T> GetQuery(DbContext context, params Expression<Func<T, object>>[] navigationProperties)
        {
            IQueryable<T> query = context.Set<T>();

            // Apply eager loading
            foreach (Expression<Func<T, object>> navigationProperty in navigationProperties)
            {
                query = query.Include(navigationProperty);
            }

            return query;
        }
        
        protected static EntityState GetEntityState(DataEntityState entityState)
        {
            switch (entityState)
            {
                case DataEntityState.Unchanged:
                    {
                        return EntityState.Unchanged;
                    }
                case DataEntityState.Added:
                    {
                        return EntityState.Added;
                    }
                case DataEntityState.Modified:
                    {
                        return EntityState.Modified;
                    }
                case DataEntityState.Deleted:
                    {
                        return EntityState.Deleted;
                    }
                default:
                    {
                        return EntityState.Detached;
                    }
            }
        }
    }
}
