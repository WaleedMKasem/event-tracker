using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Z2data.Core.Data;
using Z2data.Core.Domain.Locations;

namespace Z2data.Services.Locations
{
    public interface ISeaportService
    {
        Task<IList<Seaport>> GetSeaport();
        Task<Seaport> GetSeaportById(ObjectId seaportId);
        Task<Seaport> GetSeaportByName(string name);
        Task<IList<Seaport>> GetNearSeaports(double longitude, double latitude, double radius);
        Task<bool> RemoveSeaport(ObjectId seaportId);
        Task<bool> UpdateSeaport(Seaport seaportItem);
        Task<IList<Seaport>> GetSeaport(Expression<Func<Seaport, bool>> filter, int pageIndex, int pageSize);
        Task<bool> AddSeaport(Seaport seaport);
        Task<long> GetSeaportCount(Expression<Func<Seaport, bool>> filter = null);
        Task<int> ImportSeaports(IList<SeaportMap> seaports);
    }
}