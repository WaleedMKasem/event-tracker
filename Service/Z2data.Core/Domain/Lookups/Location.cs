using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Z2data.Core.Enums;

namespace Z2data.Core.Domain.Lookups
{
    public class Location 
    {
        public LocationType Type { get; set; }
        public double[] Coordinates { get; set; }
    }
}
