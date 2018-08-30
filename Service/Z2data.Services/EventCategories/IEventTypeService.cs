using EventTracker;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Z2data.Core.Domain.Lookups;

namespace Z2data.Services.EventTypes
{
    public interface IEventTypeService
    {
        Task<IList<EventType>> GetEventType();
        Task<EventType> GetEventTypeById(ObjectId eventTypeId);
        Task<EventType> GetEventTypeByName(string name);
        Task<bool> RemoveEventType(ObjectId eventTypeId);
        Task<bool> UpdateEventType(EventType categoryItem);
        Task<IList<EventType>> GetEventTypes(Expression<Func<EventType, bool>> filter, int pageIndex, int pageSize);
        /// <summary>
        /// Inserts a Event
        /// </summary>
        /// <param name="eventItem">Event</param>
        Task<bool> AddEventType(EventType categoryItem);
        Task<long> GetEventTypesCount(Expression<Func<EventType, bool>> filter = null);
        Task<long> GetEventTypeCount(Expression<Func<EventType, bool>> filter = null);
    }
}
