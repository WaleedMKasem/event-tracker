using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Z2data.Core.Domain.Lookups;

namespace Z2data.Services.EventCategories
{
    public interface IEventCategoryService
    {
        Task<IList<EventCategory>> GetEventCategory();
        Task<EventCategory> GetEventCategoryById(ObjectId eventCategoryId);
        Task<EventCategory> GetEventCategoryByName(string name);
        Task<bool> RemoveEventCategory(ObjectId eventCategoryId);
        Task<bool> UpdateEventCategory(EventCategory categoryItem);
        Task<IList<EventCategory>> GetEventCategories(Expression<Func<EventCategory, bool>> filter, int pageIndex, int pageSize);
        /// <summary>
        /// Inserts a Event
        /// </summary>
        /// <param name="eventItem">Event</param>
        Task<bool> AddEventCategory(EventCategory categoryItem);
        Task<long> GetEventCategoriesCount(Expression<Func<EventCategory, bool>> filter = null);
        Task<long> GetEventCategoryCount(Expression<Func<EventCategory, bool>> filter = null);
        Task<int> ImportEventCategories(IList<EventCategoryMap> eventCategories);
    }
}
