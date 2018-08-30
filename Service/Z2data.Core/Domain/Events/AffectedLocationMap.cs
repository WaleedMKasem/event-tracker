using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Z2data.Core.Enums;

namespace Z2data.Core.Domain.Events
{
    public class AffectedLocationMap
    {
        public object LocationId { get; set; }
        public string Name { get; set; }
        public LocationType Type { get; set; }

        [BsonRepresentation(BsonType.Double, AllowTruncation = true)]
        public double[] Coordinates { get; set; }
        public IList<string> LocationType { get; set; }
        public string Iata { get; set; }
        public string Locode { get; set; }
        public string DisasterId { get; set; }
        public string DisasterName { get; set; }
        public double Distance { get; set; }
        public double? AssociatedDistance { get; set; }
        public Effect Status { get; set; }
        public bool IsConfirmed { get; set; }
    }
}
