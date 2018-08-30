using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Z2data.Core.Domain.Events;
using Z2data.Core.Domain.Lookups;

namespace Z2data.Core.Domain.Locations
{
    public class Airport : BaseEntity
    {
        //public int AirportId { get; set; }
        public string Name { get; set; }
        public Lookup Type { get; set; }
        public Place Place { get; set; }
        public string IataCode { get; set; }
        public string Code { get; set; }
        public Location Location { get; set; }
        public double? Elevation { get; set; }
    }
}
