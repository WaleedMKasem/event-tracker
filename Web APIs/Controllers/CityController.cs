using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using Z2data.Core.Domain.Lookups;
using Z2data.Services.Lookups.Cities;

namespace Z2data.Web.APIs.Controllers
{
    [RoutePrefix(nameof(City))]
    public class CityController : ApiController
    {
        #region Fields

        private readonly ICityService _cityService;

        #endregion

        #region Ctor

        public CityController(ICityService cityService)
        {
            _cityService = cityService;
        }

        #endregion

        #region Methods
        public IList<City> Get(int id)
        {
            return  _cityService.GetCities(id);
        }
        [Route("GetEventsCities")]
        public async Task<IList<City>> GetEventsCities(int id)
        {
            return await _cityService.GetEventsCities(id);
        }
        #endregion
    }
}