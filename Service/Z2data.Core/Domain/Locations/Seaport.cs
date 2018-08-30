using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Z2data.Core.Domain.Events;
using Z2data.Core.Domain.Lookups;

namespace Z2data.Core.Domain.Locations
{
    public class Seaport : BaseEntity
    {
        public string Name { get; set; }
        public Lookup Type { get; set; }
        public Place Place { get; set; }
        public Location Location { get; set; }
        public string LoCode { get; set; }
    }
}
