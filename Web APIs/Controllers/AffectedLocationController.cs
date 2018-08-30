using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Z2data.Core;
using Z2data.Core.Domain.Common;
using Z2data.Core.Domain.Events;
using Z2data.Core.Domain.Lookups;
using Z2data.Core.Enums;
using Z2data.Services.Affected;

namespace Z2data.Web.APIs.Controllers
{
    [RoutePrefix(nameof(AffectedLocation))]
    public class AffectedLocationController : ApiController
    {
        #region Fields
        private readonly IAffectedLocationService _affectedLocationItemService;
        #endregion

        #region Ctor
        public AffectedLocationController(IAffectedLocationService affectedLocationItemService)
        {
            _affectedLocationItemService = affectedLocationItemService;
        }
        #endregion

        #region Methods
        public async Task<IList<AffectedLocation>> Get()
        {
            return await _affectedLocationItemService.GetAffectedLocation();
        }

        public async Task<AffectedLocation> Get(string id)
        {
            return await _affectedLocationItemService.GetAffectedLocationById(new ObjectId(id));
        }

        [Route("GetAffectedLocation")]
        public async Task<ItemsWithTotal<AffectedLocation>> GetAffectedLocation(int pageIndex = 1, int pagesize = 2)
        {
            var result = new ItemsWithTotal<AffectedLocation>
            {
                Items = await _affectedLocationItemService.GetAffectedLocation(d => true, pageIndex, pagesize),
                Total = await _affectedLocationItemService.GetAffectedLocationCount()
            };
            return result;
        }
        [Route("GetAffectedLocations")]
        public async Task<IList<AffectedLocation>> GetAffectedLocations(double originalLat, double originalLong, double originalAffected, double originalNear)
        {
            EffectRange originalRange = new EffectRange()
            {
                Location = new Location() { Type = LocationType.Point,Coordinates = new [] { originalLat, originalLong } },
                AffectedRadius = originalAffected,
                NearRadius = originalNear
            };
            var result = await _affectedLocationItemService.GetAffectedLocations(originalRange, null);
            return result;
        }
        public async Task<bool> Post(AffectedLocation affectedLocationItem)
        {
            return await _affectedLocationItemService.AddAffectedLocation(affectedLocationItem);
        }

        public async Task<bool> Put(string id, AffectedLocation affectedLocationItem)
        {
            affectedLocationItem.Id = new ObjectId(id);
            return await _affectedLocationItemService.UpdateAffectedLocation(affectedLocationItem);
        }

        public async Task<bool> Delete(string id)
        {
            return await _affectedLocationItemService.RemoveAffectedLocation(new ObjectId(id));
        }
        #endregion 
    }
}
