using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using Z2data.Core.Domain.Lookups;
using Z2data.Services.Lookups.States;

namespace Z2data.Web.APIs.Controllers
{
    [RoutePrefix(nameof(State))]
    public class StateController : ApiController
    {
        #region Fields

        private readonly IStateService _stateService;

        #endregion

        #region Ctor

        public StateController(IStateService stateService)
        {
            _stateService = stateService;
        }

        #endregion

        #region Methods
        public IList<State> Get(int id)
        {
            return  _stateService.GetStates(id);
        }
        [Route("GetEventsStates")]
        public async Task<IList<State>> GetEventsStates(int id)
        {
            return await _stateService.GetEventsStates(id);
        }

        #endregion
    }
}