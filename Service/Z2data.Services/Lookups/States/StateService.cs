using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using Z2data.Core;
using Z2data.Core.Data;
using Z2data.Core.Domain.Events;
using Z2data.Core.Domain.Lookups;

namespace Z2data.Services.Lookups.States
{
    public class StateService : IStateService
    {
        #region Fields

        private readonly IMongoRepositoryAsync<Event> _eventRepositoryAsync;

        #endregion

        #region Ctor

        public StateService(IMongoRepositoryAsync<Event> eventRepositoryAsync)
        {
            _eventRepositoryAsync = eventRepositoryAsync;
        }

        #endregion
        #region Methods

        private string Url = ConfigurationManager.AppSettings["PlaceAPI"];
        private const string Api = "LocationIntegratedServiceManagement/GetState";

        public IList<State> GetStates(int countryId)
        {
            string urlParameters = "CountryID=" + countryId;
            var result = new HttpAction().RequestUrl<List<StateApi>>(Url, Api, "GET", urlParameters);
            return result.Select(i => new State() { StateId = i.ID, Name = i.Text }).ToList();
        }

        public async Task<IList<State>> GetEventsStates(int countryId)
        {
            return await _eventRepositoryAsync.GetDistinctAsync(e => e.Place.State, i => i.Place.Country.CountryId == countryId);
        }

        #endregion
    }
}
