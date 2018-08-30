using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Z2data.Core.Data;
using Z2data.Core.Domain.Lookups;

namespace Z2data.Services.Lookups.Disasters
{
    public class DisasterService : IDisasterService
    {
        #region Fields

        private readonly IMongoRepositoryAsync<Disaster> _disastertRepositoryAsync;

        #endregion

        #region Ctor

        public DisasterService(IMongoRepositoryAsync<Disaster> disastertRepositoryAsync)
        {
            _disastertRepositoryAsync = disastertRepositoryAsync;
        }

        #endregion

        #region Methods
        public virtual async Task<IList<Disaster>> GetDisaster()
        {
            return await _disastertRepositoryAsync.Collection.Find(a => true).ToListAsync();
        }

        public virtual async Task<Disaster> GetDisasterById(ObjectId disasterId)
        {
            if (disasterId == null)
                throw new ArgumentNullException(nameof(disasterId));

            return await _disastertRepositoryAsync.GetByIdAsync(disasterId);
        }

        public virtual async Task<Disaster> GetDisasterByName(string name)
        {
            if (name == null)
                throw new ArgumentNullException(nameof(name));

            var result = await _disastertRepositoryAsync.GetBySpecAsync(i => i.Name == name, 1, 1);
            return result.FirstOrDefault();
        }

        public virtual async Task<long> GetDisasterCount(Expression<Func<Disaster, bool>> filter = null)
        {
            return await _disastertRepositoryAsync.GetCountAsync(filter);
        }

        public virtual Task<bool> AddDisaster(Disaster disasterItem)
        {
            if (disasterItem == null)
                throw new ArgumentNullException(nameof(disasterItem));

            return _disastertRepositoryAsync.AddAsync(disasterItem);
        }

        public Task<bool> UpdateDisaster(Disaster disasterItem)
        {
            if (disasterItem == null)
                throw new ArgumentNullException(nameof(disasterItem));

            return _disastertRepositoryAsync.UpdateAsync(disasterItem);
        }

        public Task<bool> RemoveDisaster(ObjectId disasterId)
        {
            if (disasterId == null)
                throw new ArgumentNullException(nameof(disasterId));

            return _disastertRepositoryAsync.RemoveAsync(disasterId);
        }
        #endregion
    }
}
