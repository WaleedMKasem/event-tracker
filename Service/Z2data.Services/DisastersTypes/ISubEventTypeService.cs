using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Z2data.Core.Domain.Lookups;

namespace Z2data.Services.DisastersTypes
{
    public interface ISubEventTypeService
    {
        Task<IList<SubEventType>> GetDisasterType();
        Task<SubEventType> GetDisasterTypeById(ObjectId seportTypeId);
        Task<long> GetDisasterTypeCount(Expression<Func<SubEventType, bool>> filter = null);
        Task<SubEventType> GetDisasterTypeByName(string name);
        Task<bool> RemoveEventType(ObjectId subEventTypeId);
        Task<bool> UpdateEventType(SubEventType subEventTypeItem);
        Task<bool> AddEventType(SubEventType subEventType);
    }
}
