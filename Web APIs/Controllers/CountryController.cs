using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using Z2data.Core.Domain.Lookups;
using Z2data.Services.Lookups.Countries;

namespace Z2data.Web.APIs.Controllers
{
    [RoutePrefix(nameof(Country))]
    public class CountryController : ApiController
    {
        #region Fields

        private readonly ICountryService _countryService;

        #endregion

        #region Ctor

        public CountryController(ICountryService countryService)
        {
            _countryService = countryService;
        }

        #endregion

        #region Methods
        public IList<Country> Get()
        {
            return  _countryService.GetCountries();
        }
        [Route("GetEventsCountries")]
        public async Task<IList<Country>> GetEventsCountries()
        {
            return await _countryService.GetEventsCountries();
        }

        #endregion
    }
}