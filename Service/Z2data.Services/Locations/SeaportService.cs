using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Z2data.Core.Data;
using Z2data.Core.Domain.Events;
using Z2data.Core.Domain.Locations;
using Z2data.Core.Domain.Lookups;
using Z2data.Core.Enums;
using Z2data.Services.SeportTypes;

namespace Z2data.Services.Locations
{
    public class SeaportService:ISeaportService
    {
        #region Fields
        private readonly IMongoRepositoryAsync<Seaport> _seaportRepositoryAsync;
        private readonly ISeportTypeService _seportTypeService;
        #endregion

        #region Ctor
        public SeaportService(IMongoRepositoryAsync<Seaport> seaportRepositoryAsync, ISeportTypeService seportTypeService)
        {
            _seaportRepositoryAsync = seaportRepositoryAsync;
            _seportTypeService = seportTypeService;
        }
        #endregion

        #region Methods
        public virtual async Task<IList<Seaport>> GetSeaport()
        {
            return await _seaportRepositoryAsync.GetCollection();
        }

        public virtual async Task<IList<Seaport>> GetSeaport(Expression<Func<Seaport, bool>> filter, int pageIndex, int pageSize)
        {
            return await _seaportRepositoryAsync.GetBySpecAsync(filter, pageIndex, pageSize);
        }

        public virtual async Task<Seaport> GetSeaportById(ObjectId seaportId)
        {
            if (seaportId == null)
                throw new ArgumentNullException(nameof(seaportId));

            return await _seaportRepositoryAsync.GetByIdAsync(seaportId);
        }

        public virtual async Task<Seaport> GetSeaportByName(string name)
        {
            if (name == null)
                throw new ArgumentNullException(nameof(name));

            var result = await _seaportRepositoryAsync.GetBySpecAsync(i => i.Name == name, 1, 1);
            return result.FirstOrDefault();
        }

        public Task<long> GetSeaportCount(Expression<Func<Seaport, bool>> filter = null)
        {
            return _seaportRepositoryAsync.GetCountAsync(filter);
        }

        public Task<bool> AddSeaport(Seaport seaport)
        {
            if (seaport == null)
                throw new ArgumentNullException(nameof(seaport));

            return _seaportRepositoryAsync.AddAsync(seaport);
        }

        public Task<bool> UpdateSeaport(Seaport seaportItem)
        {
            if (seaportItem == null)
                throw new ArgumentNullException(nameof(seaportItem));

            return _seaportRepositoryAsync.UpdateAsync(seaportItem);
        }

        public Task<bool> RemoveSeaport(ObjectId seaportId)
        {
            if (seaportId == null)
                throw new ArgumentNullException(nameof(seaportId));

            return _seaportRepositoryAsync.RemoveAsync(seaportId);
        }
        public async Task<IList<Seaport>> GetNearSeaports(double longitude, double latitude, double radius)
        {
            return await _seaportRepositoryAsync.GetByNear(a => a.Location.Coordinates, longitude, latitude, radius);
        }

        public virtual async Task<int> ImportSeaports(IList<SeaportMap> seaports)
        {
            if (seaports == null)
                throw new ArgumentNullException(nameof(seaports));

            int count = 0;
            foreach (SeaportMap seaport in seaports)
            {
                if (seaport.Status == ImportStatus.Insert)
                {
                    SeportType seportType = await _seportTypeService.GetSeportTypeByName(seaport.Type);
                    if (seportType == null)
                        await _seportTypeService.AddSeportType(new SeportType()
                        {
                            Name = seaport.Type,
                        });

                    Seaport existAirport = await GetSeaportByName(seaport.SeaportName);
                    if (existAirport == null)
                    {
                        Seaport Seaport = new Seaport()
                        {
                            Name = seaport.SeaportName,
                            LoCode = seaport.LoCode,
                            Place = new Place()
                            {
                                Country = new Country()
                                {
                                    CountryId = seaport.CountryId,
                                    Name = seaport.CountryName
                                },
                            },
                            Location = new Location()
                            {
                                //Type = (LocationType)Enum.Parse(typeof(LocationType), seaport.Type),
                                Type = LocationType.Point,
                                Coordinates = new double[] { seaport.Longitude, seaport.Latitude }
                            },
                            Type = new Lookup()
                            {
                                Id = seportType.Id.ToString(),
                                Name = seportType.Name
                            }
                        };

                        await AddSeaport(Seaport);
                    }
                }
                else if (seaport.Status == ImportStatus.Update)
                {
                    SeportType seportType = await _seportTypeService.GetSeportTypeByName(seaport.Type);
                    Seaport editAirport = await GetSeaportByName(seaport.SeaportName);
                    if (editAirport != null)
                    {
                        editAirport.Name = seaport.SeaportName;
                        editAirport.LoCode = seaport.LoCode;
                        editAirport.Place = new Place()
                        {
                            Country = new Country()
                            {
                                CountryId = seaport.CountryId,
                                Name = seaport.CountryName
                            },
                        };
                        editAirport.Location = new Location()
                        {
                            Type = LocationType.Point,
                            Coordinates = new double[] { seaport.Longitude, seaport.Latitude }
                        };
                        editAirport.Type = new Lookup()
                        {
                            Id = seportType.Id.ToString(),
                            Name = seportType.Name
                        };

                        await UpdateSeaport(editAirport);
                    }
                }
                else if (seaport.Status == ImportStatus.Delete)
                {
                    Seaport deleteSeaport = await GetSeaportByName(seaport.SeaportName);
                    if (deleteSeaport != null)
                    {
                        await RemoveSeaport(deleteSeaport.Id);
                    }
                }
                count++;
            }
            return count;
        }
        #endregion
    }
}