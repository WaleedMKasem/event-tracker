using EventTracker;
using System;
using System.Linq;
using System.Threading.Tasks;
using Z2data.Core.Data;
using Z2data.Core.Domain.Lookups;

namespace Z2data.Services.Lookups.AirportTypes
{
    public class AirportTypeService : IAirportTypeService
    {
        #region Fields

        private readonly IMongoRepositoryAsync<AirportType> _airportTypeRepositoryAsync;

        #endregion

        #region Ctor

        public AirportTypeService(IMongoRepositoryAsync<AirportType> airportTypeRepositoryAsync)
        {
            _airportTypeRepositoryAsync = airportTypeRepositoryAsync;
        }

        #endregion

        #region Methods

        public virtual async Task<AirportType> GetAirportTypeByName(string name)
        {
            if (name == null)
                throw new ArgumentNullException(nameof(name));

            var result=  await _airportTypeRepositoryAsync.GetBySpecAsync(i => i.Name == name,1,1);
            return result.FirstOrDefault();
        }


        #endregion
    }
}
