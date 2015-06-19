using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Dynamic;
using System.Linq.Expressions;
using System.ServiceModel;
using DataEntityState = Restaurant.DataModels.EntityState;
using IEntity = Restaurant.DataModels.IEntity;

namespace Restaurant.DataAccess.Services
{
    [ServiceContract]
    public interface IGenericService<T> where T : class, IEntity
    {
        [OperationContract]
        IList<T> GetAll(params Expression<Func<T, object>>[] navigationProperties);

        [OperationContract]
        IList<T> GetAll(Func<T, bool> where, params Expression<Func<T, object>>[] navigationProperties);

        [OperationContract]
        IList<T> GetAll(string where, params Expression<Func<T, object>>[] navigationProperties);

        [OperationContract]
        T Get(Func<T, bool> where, params Expression<Func<T, object>>[] navigationProperties);

        [OperationContract]
        T Get(string where, params Expression<Func<T, object>>[] navigationProperties);

        [OperationContract]
        bool Update(params T[] items);
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

        public virtual IList<T> GetAll(Func<T, bool> where, params Expression<Func<T, object>>[] navigationProperties)
        {
            using (var context = new RestaurantDbContext())
            {
                return GetQuery(context, navigationProperties).AsNoTracking().Where(where).ToList();
            }
        }

        public virtual IList<T> GetAll(string where, params Expression<Func<T, object>>[] navigationProperties)
        {
            using (var context = new RestaurantDbContext())
            {
                return GetQuery(context, navigationProperties).AsNoTracking().Where(where).ToList();
            }
        }

        public virtual T Get(Func<T, bool> where, params Expression<Func<T, object>>[] navigationProperties)
        {
            try
            {
                using (var context = new RestaurantDbContext())
                {
                    return GetQuery(context, navigationProperties).AsNoTracking().Where(where).FirstOrDefault();
                }
            }
            catch (DbEntityValidationException)
            {
                return default(T);
            }
            catch (Exception)
            {
                return default(T);
            }
        }
        
        public virtual T Get(string where, params Expression<Func<T, object>>[] navigationProperties)
        {
            try
            {
                using (var context = new RestaurantDbContext())
                {
                    return GetQuery(context, navigationProperties).AsNoTracking().Where(where).FirstOrDefault();
                }
            }
            catch (DbEntityValidationException)
            {
                return default(T);
            }
            catch (Exception)
            {
                return default(T);
            }
        }

        public virtual bool Update(params T[] items)
        {
            using (var context = new RestaurantDbContext())
            {
                DbSet<T> dbSet = context.Set<T>();
                foreach (T item in items)
                {
                    Console.WriteLine("{0}: {1}", item.EntityState, item);
                    dbSet.Add(item);

                    foreach (DbEntityEntry<IEntity> entry in context.ChangeTracker.Entries<IEntity>())
                    {
                        entry.State = GetEntityState(entry.Entity.EntityState);
                    }
                }
                return context.SaveChanges() == items.Length;
            }
        }

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
