using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Z2data.Core.Data;
using MongoDB.Bson;
using MongoDB.Driver;
using Z2data.Core.Domain.Common;
using Z2data.Core.Domain.Events;
using Z2data.Core.Domain.Lookups;

namespace Z2data.Services.Events
{
    public class EventService : IEventService
    {
        #region Fields

        private readonly IMongoRepositoryAsync<Event> _eventRepositoryAsync;

        #endregion

        #region Ctor

        public EventService(IMongoRepositoryAsync<Event> eventRepositoryAsync)
        {
            _eventRepositoryAsync = eventRepositoryAsync;
        }

        #endregion
        
        #region Methods

        /// <summary>
        /// Gets a Event
        /// </summary>
        /// <param name="eventId">The Event identifier</param>
        /// <returns>Event</returns>
        public virtual async Task<Event> GetEventById(ObjectId eventId)
        {
            if (eventId == null)
                throw new ArgumentNullException(nameof(eventId));

            return await _eventRepositoryAsync.GetByIdAsync(eventId);
        }

        /// <summary>
        /// Gets events
        /// </summary>
        /// <returns>Events</returns>
        public virtual async Task<IList<Event>> GetEvents()
        {
            return await _eventRepositoryAsync.Collection.Find(a => true).ToListAsync();
        }

        /// <summary>
        /// Gets events
        /// </summary>
        /// <returns>Events</returns>
        public virtual async Task<IList<Event>> GetEvents(Expression<Func<Event, bool>> filter, int pageIndex, int pageSize)
        {
            return await _eventRepositoryAsync.GetBySpecAsync(filter, pageIndex, pageSize,true);
        }
        public virtual async Task<ItemsWithTotal<Event>> GetPagedEvents(Expression<Func<Event, bool>> filter, int pageIndex, int pageSize)
        {
            return await _eventRepositoryAsync.GetPagedAsync(filter, pageIndex, pageSize);
        }
        public virtual async Task<long> GetEventsCount(Expression<Func<Event, bool>> filter=null)
        {
            return await _eventRepositoryAsync.GetCountAsync(filter);
        }
        /// <summary>
        /// Inserts a Event
        /// </summary>
        /// <param name="eventItem">Event</param>
        public virtual Task<bool> AddEvent(Event eventItem)
        {
            if (eventItem == null)
                throw new ArgumentNullException(nameof(eventItem));

            return _eventRepositoryAsync.AddAsync(eventItem);
        }

        /// <summary>
        /// Updates the Event
        /// </summary>
        /// <param name="eventItem">Event</param>
        public virtual Task<bool> UpdateEvent(Event eventItem)
        {
            if (eventItem == null)
                throw new ArgumentNullException(nameof(eventItem));

            return _eventRepositoryAsync.UpdateAsync(eventItem);
        }

        /// <summary>
        /// Deletes a Event
        /// </summary>
        /// <param name="eventId"></param>
        public virtual Task<bool> RemoveEvent(ObjectId eventId)
        {
            if (eventId == null)
                throw new ArgumentNullException(nameof(eventId));

            return _eventRepositoryAsync.RemoveAsync(eventId);
        }

        #endregion
    }
}
