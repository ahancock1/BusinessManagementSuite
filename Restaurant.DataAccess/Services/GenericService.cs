﻿using System;
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
        IList<T> All<T>(string where, params string[] include)
            where T : class, IEntity;

        [OperationContract]
        IList<T> All<T>(Func<T, bool> where, params Expression<Func<T, object>>[] include)
            where T : class, IEntity;

        [OperationContract]
        T Get<T>(string where, params string[] include) where T : class, IEntity;

        [OperationContract]
        T Get<T>(Func<T, bool> where, params Expression<Func<T, object>>[] include)
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

        public virtual IList<T> All<T>(string where, params string[] include)
            where T : class, IEntity
        {
            using (var context = new RestaurantContext())
            {
                return Query<T>(context, include).AsNoTracking().Where(where).ToList();
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

        public virtual T Get<T>(string where, params string[] include)
            where T : class, IEntity
        {
            try
            {
                using (var context = new RestaurantContext())
                {
                    return Query<T>(context, include).AsNoTracking().Where(where).FirstOrDefault();
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

        private static IQueryable<T> Query<T>(DbContext context, params Expression<Func<T, object>>[] include) where T : class, IEntity
        {
            return include.Aggregate((IQueryable<T>)context.Set<T>(), (current, item) => current.Include(item));
        }

        private static IQueryable<T> Query<T>(DbContext context, params string[] include) where T : class, IEntity
        {
            return include.Aggregate((IQueryable<T>)context.Set<T>(), (current, item) => current.Include(item));
        }

        private EntityState GetEntityState(DataEntityState entityState)
        {
            if (entityState == DataEntityState.Unchanged)
            {
                return EntityState.Unchanged;
            }
            if (entityState == DataEntityState.Added)
            {
                return EntityState.Added;
            }
            if (entityState == DataEntityState.Modified)
            {
                return EntityState.Modified;
            }
            if (entityState == DataEntityState.Deleted)
            {
                return EntityState.Deleted;
            }
            return EntityState.Detached;
        }
    }
}
