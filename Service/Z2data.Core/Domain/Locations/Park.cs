using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Z2data.Core.Domain.Events;
using Z2data.Core.Domain.Lookups;
using Z2data.Core.Enums;

namespace Z2data.Core.Domain.Locations
{
    public class Park : BaseEntity
    {
        //public int ParkId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public Place Place { get; set; }
        public Location Location { get; set; }
        public Rating Rating { get; set; }
        public int? EstablishedYear { get; set; }
        public double? Area { get; set; }
        public IList<Company> Companies { get; set; }
        public IList<Lookup> Industries { get; set; }
    }
}
