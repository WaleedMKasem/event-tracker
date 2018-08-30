using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using Z2data.Core.Domain.Common;
using Z2data.Core.Domain.Events;

namespace Z2data.Services.Events
{
    public interface IEventService
    {
        Task<Event> GetEventById(ObjectId eventId);
        Task<bool> RemoveEvent(ObjectId eventId);
        Task<bool> UpdateEvent(Event eventItem);
        Task<IList<Event>> GetEvents(Expression<Func<Event, bool>> filter, int pageIndex, int pageSize);
        Task<ItemsWithTotal<Event>> GetPagedEvents(Expression<Func<Event, bool>> filter, int pageIndex, int pageSize);
        /// <summary>
        /// Inserts a Event
        /// </summary>
        /// <param name="eventItem">Event</param>
        Task<bool> AddEvent(Event eventItem);

        Task<long> GetEventsCount(Expression<Func<Event, bool>> filter = null);
    }
}