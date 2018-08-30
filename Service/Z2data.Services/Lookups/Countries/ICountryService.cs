using System.Collections.Generic;
using System.Threading.Tasks;
using Z2data.Core.Domain.Lookups;

namespace Z2data.Services.Lookups.Countries
{
    public interface ICountryService
    {
        IList<Country> GetCountries();
        Task<IList<Country>> GetEventsCountries();
    }
}