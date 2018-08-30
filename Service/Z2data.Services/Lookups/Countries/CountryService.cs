using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using Z2data.Core;
using Z2data.Core.Data;
using Z2data.Core.Domain.Events;
using Z2data.Core.Domain.Lookups;

namespace Z2data.Services.Lookups.Countries
{
    public class CountryService : ICountryService
    {

        #region Fields

        private readonly IMongoRepositoryAsync<Event> _eventRepositoryAsync;

        #endregion

        #region Ctor

        public CountryService(IMongoRepositoryAsync<Event> eventRepositoryAsync)
        {
            _eventRepositoryAsync = eventRepositoryAsync;
        }

        #endregion
        #region Methods

        private string Url = ConfigurationManager.AppSettings["PlaceAPI"];
        private const string Api = "LocationIntegratedServiceManagement/GetCountries";
        private string urlParameters = string.Empty;
        public IList<Country> GetCountries()
        {
            var result = new HttpAction().RequestUrl<List<CountryApi>>(Url, Api, "GET", urlParameters);
            return result.Select(i=>new Country() {CountryId = i.ID, Name = i.Text}).ToList();
        }
        public async Task<IList<Country>> GetEventsCountries()
        {
            return await _eventRepositoryAsync.GetDistinctAsync(e => e.Place.Country,e=>e.Place.Country.Name!=null);
        }

        #endregion
    }
}
