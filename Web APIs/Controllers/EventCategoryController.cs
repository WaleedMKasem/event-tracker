using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Z2data.Core.Domain.Common;
using Z2data.Core.Domain.Lookups;
using Z2data.Services.EventCategories;

namespace Z2data.Web.APIs.Controllers
{
    [RoutePrefix(nameof(EventCategory))]
    public class EventCategoryController : ApiController
    {
        #region Fields
        private readonly IEventCategoryService _eventCategoryItemService;
        #endregion

        #region Ctor
        public EventCategoryController(IEventCategoryService eventCategoryItemService)
        {
            _eventCategoryItemService = eventCategoryItemService;
        }
        #endregion

        #region Methods
        public async Task<IList<EventCategory>> Get()
        {
            return await _eventCategoryItemService.GetEventCategory();
        }

        public async Task<EventCategory> Get(string id)
        {
            return await _eventCategoryItemService.GetEventCategoryById(new ObjectId(id));
        }

        [Route("GetEventCategory")]
        public async Task<ItemsWithTotal<EventCategory>> GetEventCategory(int pageIndex = 1, int pagesize = 2)
        {
            var result = new ItemsWithTotal<EventCategory>
            {
                Items = await _eventCategoryItemService.GetEventCategories(d => true, pageIndex, pagesize),
                Total = await _eventCategoryItemService.GetEventCategoryCount()
            };
            return result;
        }

        public async Task<bool> Post(EventCategory eventCategoryItem)
        {
            return await _eventCategoryItemService.AddEventCategory(eventCategoryItem);
        }

        public async Task<bool> Put(string id, EventCategory eventCategoryItem)
        {
            eventCategoryItem.Id = new ObjectId(id);
            return await _eventCategoryItemService.UpdateEventCategory(eventCategoryItem);
        }

        public async Task<bool> Delete(string id)
        {
            return await _eventCategoryItemService.RemoveEventCategory(new ObjectId(id));
        }
        #endregion  
    }
}
