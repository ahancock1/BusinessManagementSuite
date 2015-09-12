using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Dynamic;
using System.Linq.Expressions;
using System.ServiceModel;
using Com.Framework.Common.Logging;
using Com.Framework.Data;
using DataEntityState = Com.Framework.Data.EntityState;
using EntityState = System.Data.Entity.EntityState;


namespace Com.Framework.DataAccess.Services
{
    [ServiceContract]
    public interface IGenericService
    {
        [OperationContract]
        IList<T> All<T>() where T : Entity;

        [OperationContract]
        IList<T> All<T>(string where, params string[] include)
            where T : Entity;

        [OperationContract]
        IList<T> All<T>(Func<T, bool> where, params Expression<Func<T, object>>[] include)
            where T : Entity;

        [OperationContract]
        T Get<T>(string where, params string[] include) where T : Entity;

        [OperationContract]
        T Get<T>(Func<T, bool> where, params Expression<Func<T, object>>[] include)
            where T : Entity;

        [OperationContract]
        bool Update<T>(params T[] items) where T : Entity;
    }

    public class GenericService : IGenericService
    {
        public virtual IList<T> All<T>() where T : Entity
        {
            using (var context = new DataContext())
            {
                return context.Set<T>().ToList();
            }
        }

        public virtual IList<T> All<T>(params Expression<Func<T, object>>[] include)
            where T : Entity
        {
            using (var context = new DataContext())
            {
                return Query(context, include).AsNoTracking().ToList();
            }
        }

        public virtual IList<T> All<T>(Func<T, bool> where, params Expression<Func<T, object>>[] include)
            where T : Entity
        {
            using (var context = new DataContext())
            {
                return Query(context, include).AsNoTracking().Where(where).ToList();
            }
        }

        public virtual IList<T> All<T>(string where, params string[] include)
            where T : Entity
        {
            using (var context = new DataContext())
            {
                return Query<T>(context, include).AsNoTracking().Where(where).ToList();
            }
        }

        public virtual T Get<T>(Func<T, bool> where, params Expression<Func<T, object>>[] include)
            where T : Entity
        {
            try
            {
                using (var context = new DataContext())
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
                Logger.Error(String.Format("Couldn't \"GET\" {0}, {1}", typeof(T).Name, where), e);
                return default(T);
                //                return null;
            }
        }

        public virtual T Get<T>(string where, params string[] include)
            where T : Entity
        {
            try
            {
                using (var context = new DataContext())
                {
                    return Query<T>(context, include).AsNoTracking().Where(where).FirstOrDefault();
                }
            }
            catch (DbEntityValidationException)
            {
                return default(T);
            }
            catch (Exception e)
            {
                Logger.Error(String.Format("Couldn't \"GET\" {0}, {1}", typeof(T).Name, where), e);
                return default(T);
            }
        }

        public virtual bool Update<T>(params T[] items) where T : Entity
        {
            using (var context = new DataContext())
            {
                DbSet<T> dbSet = context.Set<T>();
                foreach (T item in items)
                {
                    Console.WriteLine("{0}: {1}", item.EntityState, item);
                    dbSet.Add(item);

                    foreach (DbEntityEntry<Entity> entry in context.ChangeTracker.Entries<Entity>())
                    {
                        entry.State = GetEntityState(entry.Entity.EntityState);
                    }
                }
                return context.SaveChanges() == items.Length;
            }
        }

        private static IQueryable<T> Query<T>(DbContext context, params Expression<Func<T, object>>[] include) where T : Entity
        {
            return include.Aggregate((IQueryable<T>)context.Set<T>(), (current, item) => current.Include(item));
        }

        private static IQueryable<T> Query<T>(DbContext context, params string[] include) where T : Entity
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
