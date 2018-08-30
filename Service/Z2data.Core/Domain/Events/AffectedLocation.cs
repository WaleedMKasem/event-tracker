using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Z2data.Core.Domain.Lookups;
using Z2data.Core.Enums;

namespace Z2data.Core.Domain.Events
{
    public class AffectedLocation : BaseEntity
    {
        public object LocationId { get; set; }
        public string Name { get; set; }
        public Location Location { get; set; }
        public AffectedLocationType Type { get; set; }
        public IList<string> LocationType { get; set; }
        public string Iata { get; set; }
        public string Locode { get; set; }
        public Lookup[] DisasterTypes { get; set; }
        public double Distance { get; set; }
        public double? AssociatedDistance { get; set; }
        public Effect Status { get; set; }
        public bool IsConfirmed { get; set; }
    }
}
