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
    public class AirportMap
    {    
        public string AirportName { get; set; }
        public string Type { get; set; }
        public int CountryId { get; set; }
        public string CountryName { get; set; }
        public int CityId { get; set; }
        public string CityName { get; set; }
        public string IATACode { get; set; }
        public string IDCode { get; set; }
        [BsonRepresentation(BsonType.Double, AllowTruncation = true)]
        public double Latitude { get; set; }
        [BsonRepresentation(BsonType.Double, AllowTruncation = true)]
        public double Longitude { get; set; }
        public double? Elevation { get; set; }
        public ImportStatus Status { get; set; }
    }
}
