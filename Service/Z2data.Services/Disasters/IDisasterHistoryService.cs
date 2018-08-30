using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Z2data.Core.Domain.Events;

namespace Z2data.Services.Disasters
{
    public interface IDisasterHistoryService
    {
        Task<IList<DisasterHistory>> GetDisaster();
        Task<DisasterHistory> GetDisasterById(ObjectId disasterId);
        Task<bool> RemoveDisaster(ObjectId disasterId);
        Task<bool> UpdateDisaster(DisasterHistory disasterItem);
        Task<IList<DisasterHistory>> GetDisaster(Expression<Func<DisasterHistory, bool>> filter, int pageIndex, int pageSize);
        Task<bool> AddDisaster(DisasterHistory disaster);
        Task<long> GetDisasterCount(Expression<Func<DisasterHistory, bool>> filter = null);
        Task<int> ImportDisasters(IList<DisasterHistoryMap> disaster);
    }
}
