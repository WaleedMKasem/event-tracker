using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Bson;
using Z2data.Core.Domain.Locations;
using Z2data.Core.Domain.Lookups;

namespace Z2data.Services.Locations
{
    public interface IIndustryService
    {
        Task<bool> AddIndustry(Industry industry);
        Task<int> ImportIndustries(IList<IndustryMap> industries);
        Task<Industry> GetIndustryByName(string name);
        Task<bool> UpdateIndustry(Industry industry);
        Task<bool> RemoveIndustry(ObjectId eventId);
    }
}