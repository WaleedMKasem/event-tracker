using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.GeoJsonObjectModel;
using Z2data.Core.Domain.Events;
using Z2data.Core.Data;
using Z2data.Core.Domain.Locations;
using Z2data.Core.Domain.Lookups;
using Z2data.Core.Enums;
using Z2data.Services.Locations;
using System.Device;
using System.Device.Location;
using Z2data.Core;

namespace Z2data.Services.Affected
{
    public class AffectedLocationService : IAffectedLocationService
    {
        #region Fields

        private readonly IMongoRepositoryAsync<AffectedLocation> _affectedLocationRepositoryAsync;
        private readonly IAirportService _airportService;
        private readonly ISeaportService _seaportService;
        private  string Url = ConfigurationManager.AppSettings["AffectedAPI"];
        private const string Api = "CompanyLocation/GetAffectedLocations";
        #endregion

        #region Ctor

        public AffectedLocationService(IMongoRepositoryAsync<AffectedLocation> affectedLocationRepositoryAsync, IAirportService airportService, ISeaportService seaportService)
        {
            _affectedLocationRepositoryAsync = affectedLocationRepositoryAsync;
            _airportService = airportService;
            _seaportService = seaportService;
        }

        #endregion

        #region Methods

        public virtual async Task<IList<AffectedLocation>> GetAffectedLocation()
        {
            return await _affectedLocationRepositoryAsync.GetCollection();
        }

        public virtual async Task<IList<AffectedLocation>> GetAffectedLocations(EffectRange originalRange,
            EffectRange associatedRange)
        {
            Dictionary<string,string> urlParameters = new Dictionary<string, string>();
            urlParameters.Add("Latitude", originalRange.Location.Coordinates[0].ToString());
            urlParameters.Add("Longitude", originalRange.Location.Coordinates[1].ToString());
            urlParameters.Add("Radius", originalRange.NearRadius.ToString());
            var result = new List<AffectedLocation>();
            var originalPoint = new GeoCoordinate(originalRange.Location.Coordinates[0], originalRange.Location.Coordinates[1]);
            if (originalRange != null)
            {
                var returnedLocations = new HttpAction().RequestUrl<List<AffectedLocation>>(Url, Api, "GET", urlParameters);

                foreach (AffectedLocation returnedLocation in returnedLocations)
                {
                    returnedLocation.Type = AffectedLocationType.Company;
                    returnedLocation.Status = returnedLocation.Distance < originalRange.AffectedRadius ? Effect.Affected : Effect.Near;
                    returnedLocation.IsConfirmed = true;
                }
                result.AddRange(returnedLocations);

                //Affected Airports
                var airports = await _airportService.GetNearAirports(originalRange.Location.Coordinates[1], originalRange.Location.Coordinates[0], originalRange.NearRadius ?? 0);
                foreach (Airport airport in airports)
                {

                    var airportPoint = new GeoCoordinate(airport.Location.Coordinates[0], airport.Location.Coordinates[1]);
                    var distance = originalPoint.GetDistanceTo(airportPoint);
                    result.Add(new AffectedLocation()
                    {
                        LocationId = airport.Id,
                        Name = airport.Name,
                        Iata = airport.IataCode,
                        Type = AffectedLocationType.Airport,
                        Location = airport.Location,
                        Distance = distance / 1000,
                        Status = distance / 1000 < originalRange.AffectedRadius ? Effect.Affected : Effect.Near,
                        IsConfirmed = true
                    });
                }


                //Affected Seaports
                var seaports = await _seaportService.GetNearSeaports(originalRange.Location.Coordinates[1], originalRange.Location.Coordinates[0], originalRange.NearRadius ?? 0);
                foreach (Seaport seaport in seaports)
                {

                    var seaportPoint = new GeoCoordinate(seaport.Location.Coordinates[0], seaport.Location.Coordinates[1]);
                    var distance = originalPoint.GetDistanceTo(seaportPoint);
                    result.Add(new AffectedLocation()
                    {
                        LocationId = seaport.Id,
                        Name = seaport.Name,
                        Locode = seaport.LoCode,
                        Type = AffectedLocationType.Seaport,
                        Location = seaport.Location,
                        Distance = distance / 1000,
                        Status = distance / 1000 < originalRange.AffectedRadius ? Effect.Affected : Effect.Near,
                        IsConfirmed = true
                    });
                }

            }
            return result.OrderBy(i=>i.Distance).ToList();
        }

        public virtual async Task<IList<AffectedLocation>> GetAffectedLocation(Expression<Func<AffectedLocation, bool>> filter, int pageIndex, int pageSize)
        {
            return await _affectedLocationRepositoryAsync.GetBySpecAsync(filter, pageIndex, pageSize);
        }

        public virtual async Task<AffectedLocation> GetAffectedLocationById(ObjectId affectedLocationId)
        {
            if (affectedLocationId == null)
                throw new ArgumentNullException(nameof(affectedLocationId));

            return await _affectedLocationRepositoryAsync.GetByIdAsync(affectedLocationId);
        }

        public Task<long> GetAffectedLocationCount(Expression<Func<AffectedLocation, bool>> filter = null)
        {
            return _affectedLocationRepositoryAsync.GetCountAsync(filter);
        }

        public virtual Task<bool> AddAffectedLocation(AffectedLocation affectedLocationItem)
        {
            if (affectedLocationItem == null)
                throw new ArgumentNullException(nameof(affectedLocationItem));

            return _affectedLocationRepositoryAsync.AddAsync(affectedLocationItem);
        }

        public virtual Task<bool> RemoveAffectedLocation(ObjectId affectedLocationId)
        {
            if (affectedLocationId == null)
                throw new ArgumentNullException(nameof(affectedLocationId));

            return _affectedLocationRepositoryAsync.RemoveAsync(affectedLocationId);
        }

        public virtual Task<bool> UpdateAffectedLocation(AffectedLocation affectedLocationItem)
        {
            if (affectedLocationItem == null)
                throw new ArgumentNullException(nameof(affectedLocationItem));

            return _affectedLocationRepositoryAsync.UpdateAsync(affectedLocationItem);
        }
        #endregion
    }
}
