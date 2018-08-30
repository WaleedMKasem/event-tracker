using EventTracker;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Z2data.Core.Domain.Lookups;

namespace Z2data.Services.Lookups.AirportTypes
{
    public interface IAirportTypeService
    {
        Task<AirportType> GetAirportTypeByName(string name);
    }
}
