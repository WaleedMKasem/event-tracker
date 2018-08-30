using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Z2data.Core.Enums;

namespace Z2data.Core.Domain.Locations
{
    public class SeaportMap
    {
        public string SeaportName { get; set; }
        public string Type { get; set; }
        public int CountryId { get; set; }
        public string CountryName { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string LoCode { get; set; }
        public ImportStatus Status { get; set; }
    }
}
