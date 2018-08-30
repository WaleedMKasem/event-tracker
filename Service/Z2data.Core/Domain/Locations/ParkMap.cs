using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Z2data.Core.Domain.Lookups;
using Z2data.Core.Enums;

namespace Z2data.Core.Domain.Locations
{
    public class ParkMap
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public int CountryId { get; set; }
        public string CountryName { get; set; }
        public int CityId { get; set; }
        public string CityName { get; set; }
        public int StateId { get; set; }
        public string StateName { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Rating { get; set; }
        public int? EstablishedYear { get; set; }
        public double? Area { get; set; }
        public ImportStatus Status { get; set; }
    }
}
