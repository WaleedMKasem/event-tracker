using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Z2data.Core.Domain.Locations;

namespace Z2data.Services.SeportTypes
{
    public interface ISeportTypeService
    {
        Task<IList<SeportType>> GetSeportType();
        Task<SeportType> GetSeportTypeById(ObjectId seportTypeId);
        Task<bool> RemoveSeportType(ObjectId seportTypeId);
        Task<bool> UpdateSeportType(SeportType seportTypeItem);
        Task<IList<SeportType>> GetSeportType(Expression<Func<SeportType, bool>> filter, int pageIndex, int pageSize);
        Task<bool> AddSeportType(SeportType seportType);
        Task<long> GetSeportTypeCount(Expression<Func<SeportType, bool>> filter = null);
        Task<SeportType> GetSeportTypeByName(string name);
    }
}
