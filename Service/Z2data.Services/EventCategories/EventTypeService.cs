using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using Z2data.Core.Domain.Lookups;
using Z2data.Core.Data;
using EventTracker;

namespace Z2data.Services.EventTypes
{
    public class EventTypeService : IEventTypeService
    {
        #region Fields

        private readonly IMongoRepositoryAsync<EventType> _eventRepositoryAsync;

        #endregion

        #region Ctor

        public EventTypeService(IMongoRepositoryAsync<EventType> eventRepositoryAsync)
        {
            _eventRepositoryAsync = eventRepositoryAsync;
        }

        #endregion

        #region Methods

        public virtual async Task<IList<EventType>> GetEventType()
        {
            return await _eventRepositoryAsync.GetCollection();
        }

        public virtual Task<bool> AddEventType(EventType categoryItem)
        {
            if (categoryItem == null)
                throw new ArgumentNullException(nameof(categoryItem));

            return _eventRepositoryAsync.AddAsync(categoryItem);
         }

        public virtual async Task<IList<EventType>> GetEventTypes(Expression<Func<EventType, bool>> filter, int pageIndex, int pageSize)
        {
            return await _eventRepositoryAsync.GetBySpecAsync(filter, pageIndex, pageSize);
        }

        public virtual async Task<EventType> GetEventTypeById(ObjectId eventTypeId)
        {
            if (eventTypeId == null)
                throw new ArgumentNullException(nameof(eventTypeId));

            return await _eventRepositoryAsync.GetByIdAsync(eventTypeId);
        }
        public virtual async Task<EventType> GetEventTypeByName(string name)
        {
            if (name == null)
                throw new ArgumentNullException(nameof(name));

            var result = await _eventRepositoryAsync.GetBySpecAsync(i => i.Name == name, 1, 1);
            return result.FirstOrDefault();
        }
        public virtual Task<long> GetEventTypesCount(Expression<Func<EventType, bool>> filter = null)
        {
            return _eventRepositoryAsync.GetCountAsync(filter);
        }

        public virtual Task<bool> RemoveEventType(ObjectId eventTypeId)
        {
            if (eventTypeId == null)
                throw new ArgumentNullException(nameof(eventTypeId));

            return _eventRepositoryAsync.RemoveAsync(eventTypeId);
        }

        public virtual Task<bool> UpdateEventType(EventType categoryItem)
        {
            if (categoryItem == null)
                throw new ArgumentNullException(nameof(categoryItem));

            return _eventRepositoryAsync.UpdateAsync(categoryItem);
        }

        public virtual async Task<long> GetEventTypeCount(Expression<Func<EventType, bool>> filter = null)
        {
            return await _eventRepositoryAsync.GetCountAsync(filter);
        }
        #endregion
    }
}
