using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Com.Framework.Common.Logging;
using Com.Framework.Data;
using PagedList;
using DataEntityState = Com.Framework.Data.EntityState;
using EntityState = System.Data.Entity.EntityState;


namespace Com.Framework.DataAccess.Services
{
    public class GenericService : IGenericService
    {
        private readonly bool trace;

        public GenericService()
        {
#if DEBUG
            trace = true;
#endif
        }

        public virtual IEnumerable<T> All<T>(Func<T, bool> where, params Expression<Func<T, object>>[] include)
            where T : BaseEntity
        {
            using (var context = new DataContext())
            {
                if (trace)
                {
                    context.Database.Log = Console.WriteLine;
                }
                return Query(context, include).AsNoTracking().Where(where);
            }
        }

        public virtual IPagedList<T> AllPaginated<T>(int page, int pageSize, Func<T, bool> where, params Expression<Func<T, object>>[] include)
            where T : BaseEntity
        {
            using (var context = new DataContext())
            {
                if (trace)
                {
                    context.Database.Log = Console.WriteLine;
                }
                return Query(context, include).AsNoTracking().Where(where).ToPagedList(page, pageSize);
            }
        }

        public virtual T Get<T>(Func<T, bool> where, params Expression<Func<T, object>>[] include)
            where T : BaseEntity
        {
            try
            {
                using (var context = new DataContext())
                {
                    if (trace)
                    {
                        context.Database.Log = Console.WriteLine;
                    }
                    return Query(context, include).AsNoTracking().Where(where).FirstOrDefault();
                }
            }
            catch (DbEntityValidationException)
            {
                return default(T);
            }
            catch (Exception e)
            {
                Logger.Error(String.Format("Couldn't \"GET\" {0}.", typeof(T).Name), e);
                return default(T);
                //                return null;
            }
        }

        public virtual bool Update<T>(params T[] items) where T : BaseEntity
        {
            using (var context = new DataContext())
            {
                if (trace)
                {
                    context.Database.Log = Console.WriteLine;
                }

                DbSet<T> dbSet = context.Set<T>();
                // Change this to for int i ... if i need to return updated items
                foreach (T item in items)
                {
                    Console.WriteLine("{0}: {1}", item.EntityState, item);
                    dbSet.Add(item);

                    foreach (DbEntityEntry<BaseEntity> entry in context.ChangeTracker.Entries<BaseEntity>())
                    {
                        entry.State = GetEntityState(entry.Entity.EntityState);
                    }
                }
                return context.SaveChanges() == items.Length;
            }
        }

        public async virtual Task<bool> UpdateAsync<T>(params T[] items) where T : BaseEntity
        {
            using (var context = new DataContext())
            {
                if (trace)
                {
                    context.Database.Log = Console.WriteLine;
                }

                DbSet<T> dbSet = context.Set<T>();
                // Change this to for int i ... if i need to return updated items
                foreach (T item in items)
                {
                    Console.WriteLine("{0}: {1}", item.EntityState, item);
                    dbSet.Add(item);

                    foreach (DbEntityEntry<BaseEntity> entry in context.ChangeTracker.Entries<BaseEntity>())
                    {
                        entry.State = GetEntityState(entry.Entity.EntityState);
                    }
                }
                return await context.SaveChangesAsync() == items.Length;
            }
        }

        private static IQueryable<T> Query<T>(DbContext context, params Expression<Func<T, object>>[] include) where T : BaseEntity
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
