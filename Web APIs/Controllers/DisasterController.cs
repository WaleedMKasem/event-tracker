using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Z2data.Core.Domain.Lookups;
using Z2data.Services.Lookups.Disasters;

namespace Z2data.Web.APIs.Controllers
{
    [RoutePrefix(nameof(Disaster))]
    public class DisasterController : ApiController
    {
        #region Fields

        private readonly IDisasterService _disasterItemService;

        #endregion

        #region Ctor

        public DisasterController(IDisasterService disasterItemService)
        {
            _disasterItemService = disasterItemService;
        }

        #endregion

        #region Methods
        public async Task<Disaster> Get(string id)
        {
            return await _disasterItemService.GetDisasterById(new ObjectId(id));
        }
        public async Task<IList<Disaster>> Get()
        {
            return await _disasterItemService.GetDisaster();
        }
        #endregion
    }
}
