using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using EventTracker;
using MongoDB.Bson;
using Z2data.Core.Domain.Lookups;
using Z2data.Core.Data;
using Z2data.Core.Domain.Events;
using Z2data.Core.Domain.Locations;
using Z2data.Core.Enums;
using Z2data.Services.EventTypes;

namespace Z2data.Services.EventCategories
{
    public class EventCategoryService : IEventCategoryService
    {
        #region Fields

        private readonly IMongoRepositoryAsync<EventCategory> _eventRepositoryAsync;
        private readonly IEventTypeService _eventTypeService;

        #endregion

        #region Ctor

        public EventCategoryService(IMongoRepositoryAsync<EventCategory> eventRepositoryAsync, IEventTypeService eventTypeService)
        {
            _eventRepositoryAsync = eventRepositoryAsync;
            _eventTypeService = eventTypeService;
        }

        #endregion

        #region Methods

        public virtual async Task<IList<EventCategory>> GetEventCategory()
        {
            return await _eventRepositoryAsync.GetCollection();
        }

        public virtual Task<bool> AddEventCategory(EventCategory categoryItem)
        {
            if (categoryItem == null)
                throw new ArgumentNullException(nameof(categoryItem));

            return _eventRepositoryAsync.AddAsync(categoryItem);
        }

        public virtual async Task<IList<EventCategory>> GetEventCategories(Expression<Func<EventCategory, bool>> filter, int pageIndex, int pageSize)
        {
            return await _eventRepositoryAsync.GetBySpecAsync(filter, pageIndex, pageSize);
        }

        public virtual async Task<EventCategory> GetEventCategoryById(ObjectId eventCategoryId)
        {
            if (eventCategoryId == null)
                throw new ArgumentNullException(nameof(eventCategoryId));

            return await _eventRepositoryAsync.GetByIdAsync(eventCategoryId);
        }
        public virtual async Task<EventCategory> GetEventCategoryByName(string name)
        {
            if (name == null)
                throw new ArgumentNullException(nameof(name));

            var result = await _eventRepositoryAsync.GetBySpecAsync(i => i.Name == name, 1, 1);
            return result.FirstOrDefault();
        }
        public virtual Task<long> GetEventCategoriesCount(Expression<Func<EventCategory, bool>> filter = null)
        {
            return _eventRepositoryAsync.GetCountAsync(filter);
        }

        public virtual Task<bool> RemoveEventCategory(ObjectId eventCategoryId)
        {
            if (eventCategoryId == null)
                throw new ArgumentNullException(nameof(eventCategoryId));

            return _eventRepositoryAsync.RemoveAsync(eventCategoryId);
        }

        public virtual Task<bool> UpdateEventCategory(EventCategory categoryItem)
        {
            if (categoryItem == null)
                throw new ArgumentNullException(nameof(categoryItem));

            return _eventRepositoryAsync.UpdateAsync(categoryItem);
        }

        public virtual async Task<long> GetEventCategoryCount(Expression<Func<EventCategory, bool>> filter = null)
        {
            return await _eventRepositoryAsync.GetCountAsync(filter);
        }
        public virtual async Task<int> ImportEventCategories(IList<EventCategoryMap> eventCategories)
        {
            if (eventCategories == null)
                throw new ArgumentNullException(nameof(eventCategories));

            int count = 0;
            foreach (EventCategoryMap eventCategory in eventCategories)
            {
                try
                {
                    EventCategory existing = await GetEventCategoryByName(eventCategory.EventCategory);
                    if (existing == null && eventCategory.Status != ImportStatus.Delete)
                    {
                        existing = new EventCategory()
                        {
                            Name = eventCategory.EventCategory,
                            EventTypes = new List<CategoryEventType>()
                        };
                        await AddEventCategory(existing);
                    }
                    if (existing != null && existing.EventTypes == null)
                    {
                        existing.EventTypes = new List<CategoryEventType>();
                    }
                    if (eventCategory.Status == ImportStatus.Insert)
                    {
                        EventType newType = new EventType()
                        {
                            Name = eventCategory.EventType,
                            Unit = eventCategory.Unit
                        };
                        await _eventTypeService.AddEventType(newType);
                        existing.EventTypes.Add(new CategoryEventType()
                        {
                            Id = newType.Id.ToString(),
                            Name = newType.Name,
                            Unit = newType.Unit
                        });
                        await UpdateEventCategory(existing);
                    }
                    else if (eventCategory.Status == ImportStatus.Update)
                    {
                        EventType existingType = await _eventTypeService.GetEventTypeByName(eventCategory.EventType);
                        if (existingType != null)
                        {
                            existingType.Unit = eventCategory.Unit;
                            await _eventTypeService.UpdateEventType(existingType);
                            CategoryEventType existingTypeInCategory = existing.EventTypes.FirstOrDefault(i=>i.Id== existingType.Id.ToString());
                            if (existingTypeInCategory != null)
                            {
                                existingTypeInCategory.Name = eventCategory.EventType;
                                existingTypeInCategory.Unit = eventCategory.Unit;
                            }
                            else
                            {
                                existing.EventTypes.Add(new CategoryEventType()
                                {
                                    Id = existingType.Id.ToString(),
                                    Name = existingType.Name,
                                    Unit = existingType.Unit
                                });
                            }
                            await UpdateEventCategory(existing);
                        }
                    }
                    else if (eventCategory.Status == ImportStatus.Delete)
                    {
                        EventType eventType = await _eventTypeService.GetEventTypeByName(eventCategory.EventType);
                        if (eventType != null)
                        {
                            var catEvent=existing.EventTypes.FirstOrDefault(e => e.Id == eventType.Id.ToString());
                            existing.EventTypes.Remove(catEvent);
                            await UpdateEventCategory(existing);
                            await _eventTypeService.RemoveEventType(eventType.Id);
                        }
                    }
                    count++;
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
            return count;
        }
        #endregion
    }
}
