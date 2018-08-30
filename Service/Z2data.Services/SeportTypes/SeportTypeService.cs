using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using Z2data.Core.Domain.Locations;
using Z2data.Core.Data;

namespace Z2data.Services.SeportTypes
{
    public class SeportTypeService : ISeportTypeService
    {
        #region Fields
        private readonly IMongoRepositoryAsync<SeportType> _seportTypeRepositoryAsync;
        #endregion

        #region Ctor
        public SeportTypeService(IMongoRepositoryAsync<SeportType> seportTypeRepositoryAsync)
        {
            _seportTypeRepositoryAsync = seportTypeRepositoryAsync;
        }
        #endregion

        #region Methods
        public virtual async Task<IList<SeportType>> GetSeportType()
        {
            return await _seportTypeRepositoryAsync.GetCollection();
        }

        public virtual async Task<IList<SeportType>> GetSeportType(Expression<Func<SeportType, bool>> filter, int pageIndex, int pageSize)
        {
            return await _seportTypeRepositoryAsync.GetBySpecAsync(filter, pageIndex, pageSize);
        }

        public virtual async Task<SeportType> GetSeportTypeById(ObjectId seportTypeId)
        {
            if (seportTypeId == null)
                throw new ArgumentNullException(nameof(seportTypeId));

            return await _seportTypeRepositoryAsync.GetByIdAsync(seportTypeId);
        }

        public Task<long> GetSeportTypeCount(Expression<Func<SeportType, bool>> filter = null)
        {
            return _seportTypeRepositoryAsync.GetCountAsync(filter);
        }

        public Task<bool> AddSeportType(SeportType seportType)
        {
            if (seportType == null)
                throw new ArgumentNullException(nameof(seportType));

            return _seportTypeRepositoryAsync.AddAsync(seportType);
        }

        public Task<bool> UpdateSeportType(SeportType seportTypeItem)
        {
            if (seportTypeItem == null)
                throw new ArgumentNullException(nameof(seportTypeItem));

            return _seportTypeRepositoryAsync.UpdateAsync(seportTypeItem);
        }

        public Task<bool> RemoveSeportType(ObjectId seportTypeId)
        {
            if (seportTypeId == null)
                throw new ArgumentNullException(nameof(seportTypeId));

            return _seportTypeRepositoryAsync.RemoveAsync(seportTypeId);
        }

        public virtual async Task<SeportType> GetSeportTypeByName(string name)
        {
            if (name == null)
                throw new ArgumentNullException(nameof(name));

            var result = await _seportTypeRepositoryAsync.GetBySpecAsync(i => i.Name == name, 1, 1);
            return result.FirstOrDefault();
        }
        #endregion
    }
}
