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
    public interface IAirportService
    {
        Task<IList<Airport>> GetNearAirports(double longitude, double latitude, double radius);
        Task<bool> AddAirport(Airport airportItem);
        Task<int> ImportAirports(IList<AirportMap> airports);
    }
}