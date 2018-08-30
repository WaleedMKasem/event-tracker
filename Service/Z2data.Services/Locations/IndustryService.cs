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
    public class IndustryService : IIndustryService
    {
        private readonly IMongoRepositoryAsync<Industry> _industryRepositoryAsync;

        public IndustryService(IMongoRepositoryAsync<Industry> industryRepositoryAsync)
        {
            _industryRepositoryAsync = industryRepositoryAsync;
        }

        public virtual Task<bool> AddIndustry(Industry industryItem)
        {
            if (industryItem == null)
                throw new ArgumentNullException(nameof(industryItem));

            return _industryRepositoryAsync.AddAsync(industryItem);
        }

        public virtual Task<bool> UpdateIndustry(Industry industryItem)
        {
            if (industryItem == null)
                throw new ArgumentNullException(nameof(industryItem));

            return _industryRepositoryAsync.UpdateAsync(industryItem);
        }

        public virtual Task<bool> RemoveIndustry(ObjectId industryId)
        {
            if (industryId == null)
                throw new ArgumentNullException(nameof(industryId));

            return _industryRepositoryAsync.RemoveAsync(industryId);
        }

        public virtual async Task<Industry> GetIndustryByName(string name)
        {
            if (name == null)
                throw new ArgumentNullException(nameof(name));

            var result = await _industryRepositoryAsync.GetBySpecAsync(i => i.Name == name, 1, 1);
            return result.FirstOrDefault();
        }

        public virtual async Task<int> ImportIndustries(IList<IndustryMap> industries)
        {
            if (industries == null)
                throw new ArgumentNullException(nameof(industries));

            int count = 0;
            foreach (IndustryMap industry in industries)
            {
                try
                {
                    if (industry.Status == ImportStatus.Insert)
                    {
                        Industry Seaport = new Industry()
                        {
                            Name = industry.IndustryName,
                        };

                        await AddIndustry(Seaport);
                    }
                    else if (industry.Status == ImportStatus.Delete)
                    {
                        Industry deleteIndustry = await GetIndustryByName(industry.IndustryName);
                        if (deleteIndustry != null)
                        {
                            await RemoveIndustry(deleteIndustry.Id);
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