using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Z2data.Core.Domain.Lookups;

namespace Z2data.Services.Lookups.Disasters
{
    public interface IDisasterService
    {
        Task<IList<Disaster>> GetDisaster();
        Task<Disaster> GetDisasterById(ObjectId disasterId);
        Task<Disaster> GetDisasterByName(string name);
        Task<bool> RemoveDisaster(ObjectId disasterId);
        Task<bool> UpdateDisaster(Disaster disasterItem);
        Task<bool> AddDisaster(Disaster disasterItem);
        Task<long> GetDisasterCount(Expression<Func<Disaster, bool>> filter = null);
    }
}
