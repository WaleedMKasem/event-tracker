using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Z2data.Core.Data;
using Z2data.Core.Domain.Lookups;

namespace Z2data.Services.DisastersTypes
{
    public class SubEventTypeService : ISubEventTypeService
    {
        #region Fields
        private readonly IMongoRepositoryAsync<SubEventType> _disasterTypeRepositoryAsync;
        #endregion

        #region Ctor
        public SubEventTypeService(IMongoRepositoryAsync<SubEventType> disasterTypeRepositoryAsync)
        {
            _disasterTypeRepositoryAsync = disasterTypeRepositoryAsync;
        }
        #endregion

        #region Methods
        public virtual async Task<IList<SubEventType>> GetDisasterType()
        {
            return await _disasterTypeRepositoryAsync.GetCollection();
        }

        public virtual async Task<SubEventType> GetDisasterTypeById(ObjectId disasterTypeId)
        {
            if (disasterTypeId == null)
                throw new ArgumentNullException(nameof(disasterTypeId));

            return await _disasterTypeRepositoryAsync.GetByIdAsync(disasterTypeId);
        }

        public virtual async Task<SubEventType> GetDisasterTypeByName(string name)
        {
            if (name == null)
                throw new ArgumentNullException(nameof(name));

            var result = await _disasterTypeRepositoryAsync.GetBySpecAsync(i => i.Name == name, 1, 1);
            return result.FirstOrDefault();
        }

        public Task<long> GetDisasterTypeCount(Expression<Func<SubEventType, bool>> filter = null)
        {
            return _disasterTypeRepositoryAsync.GetCountAsync(filter);
        }

        public Task<bool> AddEventType(SubEventType subEventType)
        {
            if (subEventType == null)
                throw new ArgumentNullException(nameof(subEventType));

            return _disasterTypeRepositoryAsync.AddAsync(subEventType);
        }

        public Task<bool> RemoveEventType(ObjectId subEventTypeId)
        {
            if (subEventTypeId == null)
                throw new ArgumentNullException(nameof(subEventTypeId));

            return _disasterTypeRepositoryAsync.RemoveAsync(subEventTypeId);
        }

        public Task<bool> UpdateEventType(SubEventType subEventTypeItem)
        {
            if (subEventTypeItem == null)
                throw new ArgumentNullException(nameof(subEventTypeItem));

            return _disasterTypeRepositoryAsync.UpdateAsync(subEventTypeItem);
        }
        #endregion
    }
}
