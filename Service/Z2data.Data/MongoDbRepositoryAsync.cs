using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Z2data.Core;
using Z2data.Core.Data;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;
using MongoDB.Driver.GeoJsonObjectModel;
using Z2data.Core.Domain.Common;
using Z2data.Core.Domain.Events;

namespace Z2data.Data
{
    public partial class MongoDbRepositoryAsync<T> : IMongoRepositoryAsync<T> where T : BaseEntity
    {
        #region Fields

        private readonly  IMongoCollection<T> _collection;
        private readonly IMongoDatabase _db;

        #endregion

        #region Ctor

        /// <summary>
        /// Ctor
        /// </summary>
        public MongoDbRepositoryAsync(string connection = "MongoDB")
        {
            _db = Connect(connection);
            _collection = _db.GetCollection<T>(CommonHelper.ToCamelCase(typeof(T).Name));
        }

        #endregion

        #region Methods

        public async Task<T> GetByIdAsync(ObjectId id)
        {
            return await _collection.Find(d => d.Id == id).FirstOrDefaultAsync();
        }
        public async Task<List<T>> GetCollection()
        {
            return await _collection.Find(d => true).ToListAsync();
        }

        public async Task<IList<T>> GetByNear(Expression<Func<T, double[]>> field, double longitude, double latitude, double radius)
        {
            
            var filter = Builders<T>.Filter.Near("location.coordinates", GeoJson.Point(new GeoJson2DCoordinates(longitude, latitude)), radius * 1000, 0);
            var result= await _collection.Find(filter).ToListAsync();
            return result;
        }

        public async Task<IList<TField>> GetDistinctAsync<TField>(Expression<Func<T, TField>> field,
            Expression<Func<T, bool>> filter = null)
        {
            return filter == null
                ? await _collection.DistinctAsync(field, new BsonDocument()).Result.ToListAsync()
                : await _collection.DistinctAsync(field, filter).Result.ToListAsync();
        }
        public async Task<bool> AddAsync(T entity)
        {
            await _collection.InsertOneAsync(entity); 
            return true;
        }

        public async Task<bool> UpdateAsync(T entity)
        {
            await _collection.ReplaceOneAsync(d => d.Id == entity.Id, entity);
            return true;
        }

        public async Task<bool> IncrementAsync(Expression<Func<T, long>> field, ObjectId id)
        {
            var update = Builders<T>.Update.Inc(field, 1);
            var options = new UpdateOptions { IsUpsert = true };
            await _collection.UpdateOneAsync(d => d.Id == id, update, options);
            return true;
        }

        public async Task<bool> RemoveAsync(ObjectId id)
        {
            await _collection.DeleteOneAsync(d => d.Id == id);
            return true;
        }

        public async Task<List<T>> GetBySpecAsync(Expression<Func<T, bool>> filter, int pageIndex, int pageSize)
        {
            if (filter == null)
                filter = d => true;
            return await _collection.Find(filter).Skip((pageIndex - 1) * pageSize)
                .Limit(pageSize).ToListAsync();
        }
        public async Task<List<T>> GetBySpecAsync(Expression<Func<T, bool>> filter, int pageIndex, int pageSize,bool isDescOrder )
        {
            if (filter == null)
                filter = d => true; 
            if(isDescOrder)
                return await _collection.Find(filter).SortByDescending(e => e.Id).Skip((pageIndex - 1) * pageSize)
                    .Limit(pageSize).ToListAsync();

            return await _collection.Find(filter).Skip((pageIndex - 1) * pageSize)
                .Limit(pageSize).ToListAsync(); 
        }
        public async Task<long> GetCountAsync(Expression<Func<T, bool>> filter=null)
        {
            if (filter == null)
                filter = d => true;
            return await _collection.Find(filter).CountAsync();
        }

        public async Task<ItemsWithTotal<T>> GetPagedAsync(Expression<Func<T, bool>> filter, int pageIndex, int pagesize)
        {
            var result = new ItemsWithTotal<T>
            {
                Items = await GetBySpecAsync(filter, pageIndex, pagesize),
                Total = await GetCountAsync(filter)
            };

            return result;
        }

        public async Task<List<T>> GetBySpecAsync(int skip, int take)
        {
            return await _collection.Find(d => true).Skip(skip)
                .Limit(take).ToListAsync();
        }
        #endregion

        #region Properties

        public IMongoCollection<T> Collection
        {
            get { return _collection; }
        }

        public IMongoDatabase Database
        {
            get { return _db; }
        }
        #endregion

        #region Private Methods

        private IMongoDatabase Connect(string connection)
        {
            var uri = ConfigurationManager.ConnectionStrings[connection.Trim()].ConnectionString;
            var client = new MongoClient(uri);
            var database = client.GetDatabase(new MongoUrl(uri).DatabaseName);

            var pack = new ConventionPack();
            pack.Add(new CamelCaseElementNameConvention());
            pack.Add(new IgnoreIfNullConvention(true));
            pack.Add(new IgnoreExtraElementsConvention(true));
            ConventionRegistry.Register("camel case", pack, t => true);

            return database;
        }
        #endregion


    }
}