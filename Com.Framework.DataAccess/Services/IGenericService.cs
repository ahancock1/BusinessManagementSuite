using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ServiceModel;
using System.Threading.Tasks;
using Com.Framework.Data;
using PagedList;

namespace Com.Framework.DataAccess.Services
{
    [ServiceContract]
    public interface IGenericService
    {
        [OperationContract]
        IEnumerable<T> All<T>(Func<T, bool> where, params Expression<Func<T, object>>[] include)
            where T : BaseEntity;

        [OperationContract]
        IPagedList<T> AllPaginated<T>(int page, int pagesize, Func<T, bool> where, params Expression<Func<T, object>>[] include)
            where T : BaseEntity;

        [OperationContract]
        T Get<T>(Func<T, bool> where, params Expression<Func<T, object>>[] include)
            where T : BaseEntity;

        [OperationContract]
        bool Update<T>(params T[] items) where T : BaseEntity;

        [OperationContract]
        Task<bool> UpdateAsync<T>(params T[] items) where T : BaseEntity;
    }
}