using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using MongoDB.Bson;
using Z2data.Core.Domain.Common;
using Z2data.Core.Domain.Events;
using Z2data.Core.Enums;
using Z2data.Services.Events;

namespace Z2data.Web.APIs.Controllers
{
    [RoutePrefix(nameof(Event))]
    public class EventController : ApiController
    {
        #region Fields

        private readonly IEventService _eventItemService;

        #endregion

        #region Ctor

        public EventController(IEventService eventItemService)
        {
            _eventItemService = eventItemService;
        }

        #endregion

        #region Methods

        public async Task<Event> Get(string id)
        {
            return await _eventItemService.GetEventById(new ObjectId(id));
        }
        public async Task<IList<Event>> Get()
        {
            return await _eventItemService.GetEvents(d => true, 1, 200);
        }
        [Route("GetPagedEvents")]
        public async Task<ItemsWithTotal<MiniEvent>> GetPagedEvents(int? countryId = null, int? stateId = null, int? cityId = null,
            string categoryId = null, string typeId = null, string dateFrom = null, string dateTo = null,
            Severity? severity = null, Status? status = null, bool? isAlert = null,
            int pageIndex = 1, int pagesize = 2)
        {
            //ObjectId category=new ObjectId();
            //if (!string.IsNullOrEmpty(categoryId)) category = ObjectId.Parse(categoryId);

            //ObjectId type = new ObjectId();
            //if (!string.IsNullOrEmpty(typeId)) type = ObjectId.Parse(typeId);

            DateTime fromDate = new DateTime();
            if (!string.IsNullOrEmpty(dateFrom))
                fromDate = DateTime.ParseExact(dateFrom, "yyyy-M-d", null).Date;

            DateTime toDate = new DateTime();
            if (!string.IsNullOrEmpty(dateTo))
                toDate = DateTime.ParseExact(dateTo, "yyyy-M-d", null).Date.AddDays(1).AddSeconds(-1);

            var items = await _eventItemService.GetEvents(d => (
                (countryId == null || d.Place.Country.CountryId == countryId)
                && (stateId == null || d.Place.State.StateId == stateId)
                && (cityId == null || d.Place.City.CityId == cityId)
                && (categoryId == null || d.Details.Category.Id == categoryId)
                && (typeId == null || d.Details.Type.Id == typeId)
                && (dateFrom == null || d.Details.StartDate >= fromDate)
                && (dateTo == null || d.Details.StartDate <= toDate)
                && (severity == null || d.Details.Severity == severity)
                && (status == null || d.Details.Status == status)
                && (isAlert == null || d.IsAlert == isAlert)
            ), pageIndex, pagesize);

           

            var result = new ItemsWithTotal<MiniEvent>
            {
                Items = items.Select(x => new MiniEvent()
                {
                    Code = x.Code,
                    Category = x.Details?.Category?.Name,
                    Type = x.Details?.Type?.Name,
                    Country = x.Place?.Country?.Name,
                    State = x.Place?.State?.Name,
                    City = x.Place?.City?.Name,
                    Title = x.Details?.Title,
                    StartDate = x.Details?.StartDate,
                    Severity = x.Details?.Severity.ToString(),
                    Status = (x.Details?.StatusPercentage != null ? x.Details.StatusPercentage.ToString() + "% " : string.Empty) + x.Details?.Status.ToString(),
                    LastUpdated = x.ModifiedOn,
                    Id = x.Id
                }).ToList()
                ,
                Total = await _eventItemService.GetEventsCount(d => (
                (countryId == null || d.Place.Country.CountryId == countryId)
                && (stateId == null || d.Place.State.StateId == stateId)
                && (cityId == null || d.Place.City.CityId == cityId)
                && (categoryId == null || d.Details.Category.Id == categoryId)
                && (typeId == null || d.Details.Type.Id == typeId)
                && (dateFrom == null || d.Details.StartDate >= fromDate)
                && (dateTo == null || d.Details.StartDate <= toDate)
                && (severity == null || d.Details.Severity == severity)
                && (status == null || d.Details.Status == status)
                && (isAlert == null || d.IsAlert==isAlert)
                ))
            };
            return result;
        }

        public async Task<bool> Post(Event eventItem)
        {
            return await _eventItemService.AddEvent(eventItem);

        }

        [Route("GetSubEvent")]
        public async Task<Event> GetSubEvent(string id,int index)
        {
            var eventItem= await _eventItemService.GetEventById(new ObjectId(id));
           return  eventItem.Updates[index];
        }
        [HttpPost]
        [Route("AddSubEvent")]
        public async Task<bool> AddSubEvent(string id, Event subEvent)
        {
            var eventItem = await _eventItemService.GetEventById(ObjectId.Parse(id));
            if (eventItem.Updates != null)
                eventItem.Updates.Add(subEvent);
            else
                eventItem.Updates = new List<Event> { subEvent };

            var result = await _eventItemService.UpdateEvent(eventItem);
            return result;
        }
        [HttpPut]
        [Route("UpdateSubEvent")]
        public async Task<bool> UpdateSubEvent(string id, int index, Event subEvent)
        {
            var eventItem = await _eventItemService.GetEventById(ObjectId.Parse(id));
            if (eventItem.Updates[index] != null)
                eventItem.Updates[index] = subEvent;
            var result = await _eventItemService.UpdateEvent(eventItem);
            return result;
        }
        [HttpDelete]
        [Route("DeleteSubEvent")]
        public async Task<bool> DeleteSubEvent(string id, int index)
        {
            var eventItem = await _eventItemService.GetEventById(ObjectId.Parse(id));
            if (eventItem.Updates[index] != null)
                eventItem.Updates.RemoveAt(index);
            var result = await _eventItemService.UpdateEvent(eventItem);
            return result;
        }

        public async Task<bool> Put(string id, Event eventItem)
        {
            var latestEvent=await _eventItemService.GetEventById(new ObjectId(id));

            eventItem.Id = new ObjectId(id);
            eventItem.Updates = latestEvent?.Updates;

            return await _eventItemService.UpdateEvent(eventItem);
        }
        [HttpGet]
        [Route("CloseEvent")]
        public async Task<bool> CloseEvent(string id, string closeDate, string closeNotes)
        {
            Event eventItem =await _eventItemService.GetEventById(new ObjectId(id));
            eventItem.Details.CloseDate = DateTime.ParseExact(closeDate, "yyyy/M/d", null);
            eventItem.Details.CloseNotes = closeNotes;
            eventItem.Details.Status = Status.Closed;
            return await _eventItemService.UpdateEvent(eventItem);
        }

        public async Task<bool> Delete(string id)
        {
            return await _eventItemService.RemoveEvent(new ObjectId(id));
        }

        #endregion
    }
}