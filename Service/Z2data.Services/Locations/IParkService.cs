using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Bson;
using Z2data.Core.Domain.Locations;

namespace Z2data.Services.Locations
{
    public interface IParkService
    {
        Task<bool> AddPark(Park park);
        Task<int> ImportParks(IList<ParkMap> parks);
        Task<int> ImportParkCompanies(IList<ParkCompanyMap> parkCompanies);
        Task<int> ImportParkIndustries(IList<ParkIndustryMap> parkIndustries);
        Task<Park> GetParkByName(string name);
        Task<bool> UpdatePark(Park park);
        Task<bool> RemovePark(ObjectId eventId);
    }
}