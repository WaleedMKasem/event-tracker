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
using EventTracker;

namespace Z2data.Services.Locations
{
    public class ParkService : IParkService
    {
        private readonly IMongoRepositoryAsync<Park> _parkRepositoryAsync;
        private readonly IIndustryService _industryService;

        public ParkService(IMongoRepositoryAsync<Park> parkRepositoryAsync, IIndustryService industryService)
        {
            _parkRepositoryAsync = parkRepositoryAsync;
            _industryService = industryService;
        }

        public virtual Task<bool> AddPark(Park parkItem)
        {
            if (parkItem == null)
                throw new ArgumentNullException(nameof(parkItem));

            return _parkRepositoryAsync.AddAsync(parkItem);
        }

        public virtual Task<bool> UpdatePark(Park parkItem)
        {
            if (parkItem == null)
                throw new ArgumentNullException(nameof(parkItem));

            return _parkRepositoryAsync.UpdateAsync(parkItem);
        }

        public virtual Task<bool> RemovePark(ObjectId parkId)
        {
            if (parkId == null)
                throw new ArgumentNullException(nameof(parkId));

            return _parkRepositoryAsync.RemoveAsync(parkId);
        }

        public virtual async Task<int> ImportParkCompanies(IList<ParkCompanyMap> parkCompanies)
        {
            if (parkCompanies == null)
                throw new ArgumentNullException(nameof(parkCompanies));

            int count = 0;
            foreach (ParkCompanyMap parkCompany in parkCompanies)
            {
                try
                {
                    Park existing = await GetParkByName(parkCompany.ParkName);
                    if (existing == null && parkCompany.Status != ImportStatus.Delete)
                    {
                        existing = new Park()
                        {
                            Name = parkCompany.ParkName,
                            Companies = new List<Company>()
                        };
                        await AddPark(existing);
                    }
                    if (existing != null && existing.Companies == null)
                    {
                        existing.Companies = new List<Company>();
                    }
                    if (parkCompany.Status == ImportStatus.Insert)
                    {
                        existing.Companies.Add(new Company()
                        {
                            CompanyId = parkCompany.CompanyId,
                            Name = parkCompany.CompanyName
                        });
                        await UpdatePark(existing);
                    }
                    else if (parkCompany.Status == ImportStatus.Update)
                    {
                        Company existingCompanyInPark = existing.Companies.FirstOrDefault(i => i.CompanyId == parkCompany.CompanyId);
                        if (existingCompanyInPark != null)
                        {
                            existingCompanyInPark.Name = parkCompany.CompanyName;
                        }
                        else
                        {
                            existing.Companies.Add(new Company()
                            {
                                CompanyId = parkCompany.CompanyId,
                                Name = parkCompany.CompanyName
                            });
                        }
                        await UpdatePark(existing);
                    }
                    else if (parkCompany.Status == ImportStatus.Delete && existing != null)
                    {
                        var existingCompanyInPark = existing.Companies.FirstOrDefault(e => e.CompanyId == parkCompany.CompanyId);
                        if (existingCompanyInPark != null)
                        {
                            existing.Companies.Remove(existingCompanyInPark);
                            await UpdatePark(existing);
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
        public virtual async Task<int> ImportParkIndustries(IList<ParkIndustryMap> parkIndustries)
        {
            if (parkIndustries == null)
                throw new ArgumentNullException(nameof(parkIndustries));

            int count = 0;
            foreach (ParkIndustryMap parkIndustry in parkIndustries)
            {
                try
                {
                    Park existing = await GetParkByName(parkIndustry.ParkName);
                    if (existing == null && parkIndustry.Status != ImportStatus.Delete)
                    {
                        existing = new Park()
                        {
                            Name = parkIndustry.ParkName,
                            Industries = new List<Lookup>()
                        };
                        await AddPark(existing);
                    }
                    if (existing != null && existing.Industries == null)
                    {
                        existing.Industries = new List<Lookup>();
                    }
                    Industry existingIndustry = await _industryService.GetIndustryByName(parkIndustry.IndustryName);
                    if (existingIndustry == null && parkIndustry.Status != ImportStatus.Delete)
                    {
                        existingIndustry = new Industry()
                        {
                            Name = parkIndustry.IndustryName,
                        };
                        await _industryService.AddIndustry(existingIndustry);
                    }
                    var existingIndustryInPark = existing?.Industries.FirstOrDefault(e => e.Id == existingIndustry?.Id.ToString());
                    if (parkIndustry.Status == ImportStatus.Insert)
                    {
                        if (existingIndustryInPark == null)
                        {
                            existing.Industries.Add(new Lookup()
                            {
                                Name = existingIndustry.Name,
                                Id = existingIndustry.Id.ToString()

                            });
                        }
                        await UpdatePark(existing);
                    }
                    else if (parkIndustry.Status == ImportStatus.Update)
                    {
                        if (existingIndustryInPark == null)
                        {
                            existing.Industries.Add(new Lookup()
                            {
                                Name = existingIndustry.Name,
                                Id = existingIndustry.Id.ToString()

                            });
                        }
                        await UpdatePark(existing);
                    }
                    else if (parkIndustry.Status == ImportStatus.Delete && existing != null)
                    {
                        if (existingIndustryInPark != null)
                        {
                            existing.Industries.Remove(existingIndustryInPark);
                            await UpdatePark(existing);
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
        public virtual async Task<Park> GetParkByName(string name)
        {
            if (name == null)
                throw new ArgumentNullException(nameof(name));

            var result = await _parkRepositoryAsync.GetBySpecAsync(i => i.Name == name, 1, 1);
            return result.FirstOrDefault();
        }

        public virtual async Task<int> ImportParks(IList<ParkMap> parks)
        {
            if (parks == null)
                throw new ArgumentNullException(nameof(parks));

            int count = 0;
            foreach (ParkMap park in parks)
            {
                try
                {
                    if (park.Status == ImportStatus.Insert)
                    {
                        Park Seaport = new Park()
                        {
                            Name = park.Name,
                            Address = park.Address,
                            Place = new Place()
                            {
                                Country = new Country()
                                {
                                    CountryId = park.CountryId,
                                    Name = park.CountryName
                                },

                                City = new City()
                                {
                                    CityId = park.CityId,
                                    Name = park.CityName
                                },

                                State = new State()
                                {
                                    StateId = park.StateId,
                                    Name = park.StateName
                                },
                            },
                            Location = new Location()
                            {
                                Type = LocationType.Point,
                                Coordinates = new double[] { park.Longitude, park.Latitude }
                            },
                            Rating = (Rating)Enum.Parse(typeof(Rating), park.Rating),
                            EstablishedYear = park.EstablishedYear,
                            Area = park.Area
                        };

                        await AddPark(Seaport);
                    }
                    else if (park.Status == ImportStatus.Update)
                    {
                        Park editPark = await GetParkByName(park.Name);
                        if (editPark != null)
                        {
                            editPark.Name = park.Name;
                            editPark.Address = park.Address;
                            editPark.Place = new Place()
                            {
                                Country = new Country()
                                {
                                    CountryId = park.CountryId,
                                    Name = park.CountryName
                                },

                                City = new City()
                                {
                                    CityId = park.CityId,
                                    Name = park.CityName
                                },

                                State = new State()
                                {
                                    StateId = park.StateId,
                                    Name = park.StateName
                                },
                            };
                            editPark.Location = new Location()
                            {
                                Type = LocationType.Point,
                                Coordinates = new double[] { park.Longitude, park.Latitude }
                            };
                            editPark.Rating = (Rating)Enum.Parse(typeof(Rating), park.Rating);
                            editPark.EstablishedYear = park.EstablishedYear;
                            editPark.Area = park.Area;

                            await UpdatePark(editPark);
                        }
                    }
                    else if (park.Status == ImportStatus.Delete)
                    {
                        Park deletePark = await GetParkByName(park.Name);
                        if (deletePark != null)
                        {
                            await RemovePark(deletePark.Id);
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