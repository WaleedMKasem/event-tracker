using System.Collections.Generic;
using System.Threading.Tasks;
using Z2data.Core.Domain.Lookups;

namespace Z2data.Services.Lookups.Cities
{
    public interface ICityService
    {
        IList<City> GetCities(int stateId);
        Task<IList<City>> GetEventsCities(int stateId);
    }
}