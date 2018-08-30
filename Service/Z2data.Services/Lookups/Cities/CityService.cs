using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Z2data.Core;
using Z2data.Core.Data;
using Z2data.Core.Domain.Events;
using Z2data.Core.Domain.Lookups;

namespace Z2data.Services.Lookups.Cities
{
    public class CityService : ICityService
    {
        #region Fields

        private readonly IMongoRepositoryAsync<Event> _eventRepositoryAsync;

        #endregion

        #region Ctor

        public CityService(IMongoRepositoryAsync<Event> eventRepositoryAsync)
        {
            _eventRepositoryAsync = eventRepositoryAsync;
        }
        #endregion
        #region Methods

        private string Url = ConfigurationManager.AppSettings["PlaceAPI"];
        private const string Api = "LocationIntegratedServiceManagement/GetCity";

        public IList<City> GetCities(int stateId)
        {
            string urlParameters = "StateID=" + stateId;
            var result = new HttpAction().RequestUrl<List<CityApi>>(Url, Api, "GET", urlParameters);
            return result.Select(i => new City() { CityId = i.ID, Name = i.Text }).ToList();
        }

        public IList<T> GetApis<T>(params Expression<Func<T, bool>>[] queries)
        {
            string urlParameters = string.Empty;
            foreach (var query in queries)
            {
                urlParameters += query.ToString() + "=" + query;
            }
            var result = new HttpAction().RequestUrl<IList<T>>(Url, Api, "GET", urlParameters);
            return result;
        }
        public async Task<IList<City>> GetEventsCities(int stateId)
        {
            return await _eventRepositoryAsync.GetDistinctAsync(e => e.Place.City, i => i.Place.State.StateId == stateId);
        }
        #endregion
    }
}
