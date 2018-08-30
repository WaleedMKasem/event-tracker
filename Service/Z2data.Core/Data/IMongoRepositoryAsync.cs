using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using Z2data.Core.Domain.Common;

//using MongoDB.Driver.Builders;

namespace Z2data.Core.Data
{
    /// <summary>
    /// Repository
    /// </summary>

    public interface IMongoRepositoryAsync<T> where T : BaseEntity
    {
        Task<T> GetByIdAsync(ObjectId id);
        Task<bool> AddAsync(T entity);
        Task<bool> UpdateAsync(T entity);
        Task<bool> IncrementAsync(Expression<Func<T, long>> field, ObjectId id);
        Task<bool> RemoveAsync(ObjectId id);
        //Task<List<T>> GetBySpecAsync(Expression<Func<T, bool>> filter, FindOptions options = null);
        IMongoCollection<T> Collection { get; }
        IMongoDatabase Database { get; }
        //Task<List<T>> GetBySpecAsync(int pageIndex, int pageSize);
        //Task<List<T>> GetBySpecAsync(int pageIndex, int pageSize, Expression<Func<T, bool>> filter = null, FindOptions options = null);
        Task<List<T>> GetBySpecAsync(Expression<Func<T, bool>> filter, int pageIndex, int pageSize);
        Task<long> GetCountAsync(Expression<Func<T, bool>> filter = null);
        Task<ItemsWithTotal<T>> GetPagedAsync(Expression<Func<T, bool>> filter, int pageIndex, int pagesize);
        Task<List<T>> GetCollection();
        Task<IList<T>> GetByNear(Expression<Func<T, double[]>> field, double longitude, double latitude, double radius);

        Task<IList<TField>> GetDistinctAsync<TField>(Expression<Func<T, TField>> field,
            Expression<Func<T, bool>> filter = null);

        Task<List<T>> GetBySpecAsync(Expression<Func<T, bool>> filter, int pageIndex, int pageSize,bool isDescOrder );
    }
}