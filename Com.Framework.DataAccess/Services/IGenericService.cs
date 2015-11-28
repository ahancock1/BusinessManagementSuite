using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ServiceModel;
using System.Threading.Tasks;
using Com.Framework.Data;
using PagedList;

namespace Com.Framework.DataAccess.Services
{
    // TODO: Make this interface Async
    [ServiceContract]
    public interface IGenericService
    {
        [OperationContract]
        bool Any<T>(Func<T, bool> where, params Expression<Func<T, object>>[] include)
            where T : class, IBaseEntity;

        [OperationContract]
        IEnumerable<T> All<T>()
            where T : class, IBaseEntity;

        [OperationContract]
        IEnumerable<T> All<T>(params Expression<Func<T, object>>[] include)
        where T : class, IBaseEntity;

        [OperationContract]
        IEnumerable<T> All<T>(Func<T, bool> where, params Expression<Func<T, object>>[] include)
        where T : class, IBaseEntity;

        [OperationContract]
        IPagedList<T> AllPaginated<T>(int page, int pagesize, Func<T, bool> where, params Expression<Func<T, object>>[] include)
            where T : class, IBaseEntity;

        [OperationContract]
        T Get<T>(Func<T, bool> where, params Expression<Func<T, object>>[] include)
            where T : class, IBaseEntity;

        [OperationContract]
        bool Update<T>(params T[] items) where T : class, IBaseEntity;

        [OperationContract]
        Task<bool> UpdateAsync<T>(params T[] items) where T : class, IBaseEntity;
    }
}
