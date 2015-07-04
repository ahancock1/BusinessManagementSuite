using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Dynamic;
using System.Linq.Expressions;
using System.ServiceModel;

using DataEntityState = Restaurant.Data.EntityState;
using IEntity = Restaurant.Data.IEntity;


namespace Restaurant.DataAccess.Services
{
    [ServiceContract]
    public interface IGenericService
    {
        [OperationContract]
        IList<T> All<T>() where T : class, IEntity;

        [OperationContract]
        IList<T> All<T>(params Expression<Func<T, object>>[] include)
            where T : class, IEntity;

        [OperationContract]
        IList<T> All<T>(Func<T, bool> where, params Expression<Func<T, object>>[] include)
            where T : class, IEntity;

        [OperationContract]
        IList<T> All<T>(string where, params Expression<Func<T, object>>[] include)
            where T : class, IEntity;

        [OperationContract]
        T Get<T>(Func<T, bool> where, params Expression<Func<T, object>>[] include)
            where T : class, IEntity;

        [OperationContract]
        T Get<T>(string where, params Expression<Func<T, object>>[] include)
            where T : class, IEntity;

        [OperationContract]
        bool Update<T>(params T[] items) where T : class, IEntity;
    }

    public class GenericService : IGenericService
    {
        public virtual IList<T> All<T>() where T : class, IEntity
        {
            using (var context = new RestaurantContext())
            {
                return context.Set<T>().ToList();
            }
        }

        public virtual IList<T> All<T>(params Expression<Func<T, object>>[] include)
            where T : class, IEntity
        {
            using (var context = new RestaurantContext())
            {
                return Query(context, include).AsNoTracking().ToList();
            }
        }

        public virtual IList<T> All<T>(Func<T, bool> where, params Expression<Func<T, object>>[] include)
            where T : class, IEntity
        {
            using (var context = new RestaurantContext())
            {
                return Query(context, include).AsNoTracking().Where(where).ToList();
            }
        }

        public virtual IList<T> All<T>(string where, params Expression<Func<T, object>>[] include)
            where T : class, IEntity
        {
            using (var context = new RestaurantContext())
            {
                return Query(context, include).AsNoTracking().Where(where).ToList();
            }
        }

        public virtual T Get<T>(Func<T, bool> where, params Expression<Func<T, object>>[] include)
            where T : class, IEntity
        {
            try
            {
                using (var context = new RestaurantContext())
                {
                    return Query(context, include).AsNoTracking().Where(where).FirstOrDefault();
                }
            }
            catch (DbEntityValidationException)
            {
                return default(T);
            }
            catch (Exception e)
            {
                return default(T);
                //                return null;
            }
        }

        public virtual T Get<T>(string where, params Expression<Func<T, object>>[] include)
            where T : class, IEntity
        {
            try
            {
                using (var context = new RestaurantContext())
                {
                    return Query(context, include).AsNoTracking().Where(where).FirstOrDefault();
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

        public virtual bool Update<T>(params T[] items) where T : class, IEntity
        {
            using (var context = new RestaurantContext())
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

        protected static IQueryable<T> Query<T>(DbContext context, params Expression<Func<T, object>>[] include) where T : class, IEntity
        {
            IQueryable<T> query = context.Set<T>();

            // Apply eager loading
            foreach (Expression<Func<T, object>> item in include)
            {
                query = query.Include(item);
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
