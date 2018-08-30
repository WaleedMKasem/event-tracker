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
    public class AssociatedEventMap
    {
        public string CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string TypeId { get; set; }
        public string TypeName { get; set; }
        public Severity Severity { get; set; }
        public double? AffectedRadius { get; set; }
        public double? NearRadius { get; set; }
        public LocationType Type { get; set; }

        [BsonRepresentation(BsonType.Double, AllowTruncation = true)]
        public double[] Coordinates { get; set; }
    }
}
