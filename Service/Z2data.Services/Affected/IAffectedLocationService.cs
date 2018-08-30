using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Z2data.Core.Domain.Events;

namespace Z2data.Services.Affected
{
    public interface IAffectedLocationService
    {
        Task<IList<AffectedLocation>> GetAffectedLocation();
        Task<IList<AffectedLocation>> GetAffectedLocations(EffectRange originalRange, EffectRange associatedRange);
        Task<AffectedLocation> GetAffectedLocationById(ObjectId affectedLocationId);
        Task<bool> RemoveAffectedLocation(ObjectId affectedLocationId);
        Task<bool> UpdateAffectedLocation(AffectedLocation affectedLocationItem);
        Task<IList<AffectedLocation>> GetAffectedLocation(Expression<Func<AffectedLocation, bool>> filter, int pageIndex, int pageSize);
        /// <summary>
        /// Inserts a Event
        /// </summary>
        /// <param name="eventItem">Event</param>
        Task<bool> AddAffectedLocation(AffectedLocation affectedLocationItem);
        Task<long> GetAffectedLocationCount(Expression<Func<AffectedLocation, bool>> filter = null);
    }
}
