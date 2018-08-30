using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using Z2data.Core.Data;
using Z2data.Core.Domain.Events;
using Z2data.Core.Domain.Locations;
using Z2data.Core.Domain.Lookups;
using Z2data.Core.Enums;
using Z2data.Services.Lookups.AirportTypes;
using EventTracker;

namespace Z2data.Services.Locations
{
    public class AirportService : IAirportService
    {
        private readonly IMongoRepositoryAsync<Airport> _airportRepositoryAsync;
        private readonly IAirportTypeService _airportTypeService;

        public AirportService(IMongoRepositoryAsync<Airport> airportRepositoryAsync,
            IAirportTypeService airportTypeService)
        {
            _airportRepositoryAsync = airportRepositoryAsync;
            _airportTypeService = airportTypeService;
        }

        public async Task<IList<Airport>> GetNearAirports(double longitude, double latitude, double radius)
        {
            return await _airportRepositoryAsync.GetByNear(a => a.Location.Coordinates, longitude, latitude, radius);
        }

        public virtual Task<bool> AddAirport(Airport airportItem)
        {
            if (airportItem == null)
                throw new ArgumentNullException(nameof(airportItem));

            return _airportRepositoryAsync.AddAsync(airportItem);
        }

        public virtual Task<bool> UpdateAirport(Airport airportItem)
        {
            if (airportItem == null)
                throw new ArgumentNullException(nameof(airportItem));

            return _airportRepositoryAsync.UpdateAsync(airportItem);
        }

        public virtual Task<bool> RemoveAirport(ObjectId airportId)
        {
            if (airportId == null)
                throw new ArgumentNullException(nameof(airportId));

            return _airportRepositoryAsync.RemoveAsync(airportId);
        }

        public virtual async Task<Airport> GetAirportByName(string name)
        {
            if (name == null)
                throw new ArgumentNullException(nameof(name));

            var result = await _airportRepositoryAsync.GetBySpecAsync(i => i.Name == name, 1, 1);
            return result.FirstOrDefault();
        }

        public virtual async Task<int> ImportAirports(IList<AirportMap> airports)
        {
            if (airports == null)
                throw new ArgumentNullException(nameof(airports));

            int count = 0;
            foreach (AirportMap airport in airports)
            {
                try
                {
                    if (airport.Status == ImportStatus.Insert)
                    {
                        AirportType airportType = await _airportTypeService.GetAirportTypeByName(airport.Type);
                        Airport newAirport = new Airport()
                        {
                            Name = airport.AirportName,
                            Code = airport.IDCode,
                            Elevation = airport.Elevation,
                            IataCode = airport.IATACode,
                            Place = new Place()
                            {
                                Country = new Country()
                                {
                                    CountryId = airport.CountryId,
                                    Name = airport.CountryName
                                },
                                City = new City()
                                {
                                    CityId = airport.CityId,
                                    Name = airport.CityName
                                }
                            },
                            Location = new Location()
                            {
                                Type = LocationType.Point,
                                Coordinates = new[] { airport.Longitude, airport.Latitude }
                            },
                            Type = new Lookup()
                            {
                                Id = airportType.Id.ToString(),
                                Name = airportType.Name
                            }
                        };
                        await AddAirport(newAirport);
                    }
                    else if (airport.Status == ImportStatus.Update)
                    {
                        AirportType airportType = await _airportTypeService.GetAirportTypeByName(airport.Type);
                        Airport newAirport = await GetAirportByName(airport.AirportName);
                        if (newAirport != null)
                        {
                            newAirport.Name = airport.AirportName;
                            newAirport.Code = airport.IDCode;
                            newAirport.Elevation = airport.Elevation;
                            newAirport.IataCode = airport.IATACode;
                            newAirport.Place = new Place()
                            {
                                Country = new Country()
                                {
                                    CountryId = airport.CountryId,
                                    Name = airport.CountryName
                                },
                                City = new City()
                                {
                                    CityId = airport.CityId,
                                    Name = airport.CityName
                                }
                            };
                            newAirport.Location = new Location()
                            {
                                Type = LocationType.Point,
                                Coordinates = new[] { airport.Longitude, airport.Latitude }
                            };
                            newAirport.Type = new Lookup()
                            {
                                Id = airportType.Id.ToString(),
                                Name = airportType.Name
                            };

                            await UpdateAirport(newAirport);
                        }
                    }
                    else if (airport.Status == ImportStatus.Delete)
                    {
                        Airport newAirport = await GetAirportByName(airport.AirportName);
                        if (newAirport != null)
                        {
                            await RemoveAirport(newAirport.Id);
                        }
                    }
                    count++;
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
            return count;
        }
    }
}