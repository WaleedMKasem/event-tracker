using System.Collections.Generic;
using System.Threading.Tasks;
using Z2data.Core.Domain.Lookups;

namespace Z2data.Services.Lookups.States
{
    public interface IStateService
    {
        IList<State> GetStates(int countryId);
        Task<IList<State>> GetEventsStates(int countryId);
    }
}