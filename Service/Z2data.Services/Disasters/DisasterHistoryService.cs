using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Z2data.Core.Data;
using Z2data.Core.Domain.Events;
using Z2data.Core.Domain.Lookups;
using Z2data.Core.Enums;
using Z2data.Services.DisastersTypes;
using Z2data.Services.EventTypes;
using Z2data.Services.Lookups.Disasters;

namespace Z2data.Services.Disasters
{
    public class DisasterHistoryService : IDisasterHistoryService
    {
        #region Fields
        private readonly IMongoRepositoryAsync<DisasterHistory> _disasterHistoryRepositoryAsync;
        private readonly IEventTypeService _eventTypeService;
        private readonly ISubEventTypeService _subEventTypeService;
        #endregion

        #region Ctor
        public DisasterHistoryService(IMongoRepositoryAsync<DisasterHistory> disasterHistoryRepositoryAsync, ISubEventTypeService disasterSubTypeService, IDisasterService disasterService, IEventTypeService eventTypeService, ISubEventTypeService subEventTypeService)
        {
            _disasterHistoryRepositoryAsync = disasterHistoryRepositoryAsync;
            _eventTypeService = eventTypeService;
            _subEventTypeService = subEventTypeService;
        }
        #endregion

        #region Methods
        public virtual async Task<IList<DisasterHistory>> GetDisaster()
        {
            return await _disasterHistoryRepositoryAsync.GetCollection();
        }

        public virtual async Task<IList<DisasterHistory>> GetDisaster(Expression<Func<DisasterHistory, bool>> filter, int pageIndex, int pageSize)
        {
            return await _disasterHistoryRepositoryAsync.GetBySpecAsync(filter, pageIndex, pageSize);
        }

        public virtual async Task<DisasterHistory> GetDisasterById(ObjectId disasterId)
        {
            if (disasterId == null)
                throw new ArgumentNullException(nameof(disasterId));

            return await _disasterHistoryRepositoryAsync.GetByIdAsync(disasterId);
        }

        public Task<long> GetDisasterCount(Expression<Func<DisasterHistory, bool>> filter = null)
        {
            return _disasterHistoryRepositoryAsync.GetCountAsync(filter);
        }

        public Task<bool> AddDisaster(DisasterHistory disaster)
        {
            if (disaster == null)
                throw new ArgumentNullException(nameof(disaster));

            return _disasterHistoryRepositoryAsync.AddAsync(disaster);
        }

        public Task<bool> UpdateDisaster(DisasterHistory disasterItem)
        {
            if (disasterItem == null)
                throw new ArgumentNullException(nameof(disasterItem));

            return _disasterHistoryRepositoryAsync.UpdateAsync(disasterItem);
        }

        public Task<bool> RemoveDisaster(ObjectId disasterId)
        {
            if (disasterId == null)
                throw new ArgumentNullException(nameof(disasterId));

            return _disasterHistoryRepositoryAsync.RemoveAsync(disasterId);
        }

        public virtual async Task<int> ImportDisasters(IList<DisasterHistoryMap> disasters)
        {
            if (disasters == null)
                throw new ArgumentNullException(nameof(disasters));

            int count = 0;
            foreach (DisasterHistoryMap disaster in disasters)
            {
                var eventType = await _eventTypeService.GetEventTypeByName(disaster.DisasterType);
                if (eventType == null)
                    await _eventTypeService.AddEventType(new EventType()
                    {
                        Name = disaster.DisasterType,
                        Unit = disaster.DisasterUnit
                    });

                var subEventType = await _subEventTypeService.GetDisasterTypeByName(disaster.SubTypeName);
                if (subEventType == null)
                    await _subEventTypeService.AddEventType(new SubEventType()
                    {
                        Name = disaster.SubTypeName,
                        Parent = new Lookup()
                        {
                            Id = eventType.Id.ToString(),
                            Name = eventType.Name
                        }
                    });

                if (disaster.Status == ImportStatus.Insert)
                {
                    try
                    {
                        DisasterHistory disasterHistory = new DisasterHistory()
                        {
                            StartDate = disaster.StartDate,
                            EndDate = disaster.EndDate,
                            Place = new Place()
                            {
                                Country = new Country()
                                {
                                    CountryId = disaster.CountryId,
                                    Name = disaster.CountryName
                                },
                            },
                            Location = new Location()
                            {
                                Type = LocationType.Point,
                                Coordinates = new double[] { disaster.Longitude, disaster.Latitude }
                            },
                            Type = new Lookup()
                            {
                                Id = eventType.Id.ToString(),
                                Name = eventType.Name
                            },
                            Value = disaster.Value,
                            Unit = DisasterUnit.Richter,
                            SubType = new SubEventType()
                            {
                                Name = subEventType.Name,
                                Parent = new Lookup()
                                {
                                    Id = eventType.Id.ToString(),
                                    Name = eventType.Name
                                }
                            },
                            AssociatedDisaster = disaster.AssociatedDisasterName,
                            OtherAssociatedDisaster = disaster.OtherAssociatedDisasterName,
                            TotalDamage = disaster.TotalDamage,
                            TotalAffected = disaster.TotalAffected,
                            TotalDeaths = disaster.TotalDeaths,
                            DisasterName = disaster.DisasterName,
                            Severity = Severity.Moderate,
                            Radius = disaster.Radius
                        };

                        await AddDisaster(disasterHistory);
                    }
                    catch (Exception ex)
                    {
                    }
                }
                else if (disaster.Status == ImportStatus.Update)
                {
                    DisasterHistory editDisaster = await GetDisasterById(ObjectId.Parse(disaster.DisasterId));
                    if (editDisaster != null)
                    {
                        editDisaster.StartDate = disaster.StartDate;
                        editDisaster.EndDate = disaster.EndDate;
                        editDisaster.Place = new Place()
                        {
                            Country = new Country()
                            {
                                CountryId = disaster.CountryId,
                                Name = disaster.CountryName
                            },
                        };
                        editDisaster.Location = new Location()
                        {
                            Type = LocationType.Point,
                            Coordinates = new double[] { disaster.Longitude, disaster.Latitude }
                        };
                        editDisaster.Type = new Lookup()
                        {
                            Id = eventType.Id.ToString(),
                            Name = eventType.Name
                        };
                        editDisaster.Value = disaster.Value;
                        editDisaster.Unit = DisasterUnit.Richter;
                        editDisaster.SubType = new SubEventType()
                        {
                            Name = subEventType.Name,
                            Parent = new Lookup()
                            {
                                Id = eventType.Id.ToString(),
                                Name = eventType.Name
                            }
                        };
                        editDisaster.AssociatedDisaster = disaster.AssociatedDisasterName;
                        editDisaster.OtherAssociatedDisaster = disaster.OtherAssociatedDisasterName;
                        editDisaster.TotalDamage = disaster.TotalDamage;
                        editDisaster.TotalAffected = disaster.TotalAffected;
                        editDisaster.TotalDeaths = disaster.TotalDeaths;
                        editDisaster.DisasterName = disaster.DisasterName;
                        editDisaster.Severity = Severity.Moderate;
                        editDisaster.Radius = disaster.Radius;
                        await UpdateDisaster(editDisaster);
                    }
                }
                else if (disaster.Status == ImportStatus.Delete)
                {
                    DisasterHistory deleteDisaster = await GetDisasterById(ObjectId.Parse(disaster.DisasterId));
                    if (deleteDisaster != null)
                    {
                        await RemoveDisaster(deleteDisaster.Id);
                    }
                }
                count++;
            }
            return count;
        }
        #endregion
    }
}
