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
    public class DisasterHistoryMap
    {
        public string DisasterId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int CountryId { get; set; }
        public string CountryName { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string DisasterType { get; set; }
        public double? Value { get; set; }
        public string DisasterUnit { get; set; }
        public string SubTypeName { get; set; }
        public string AssociatedDisasterName { get; set; }
        public string OtherAssociatedDisasterName { get; set; }
        public int? TotalDeaths { get; set; }
        public int? TotalAffected { get; set; }
        public double? TotalDamage { get; set; }
        public double? InsuredLosses { get; set; }
        public string DisasterName { get; set; }
        public string SeverityLevel { get; set; }
        public double? Radius { get; set; }
        public ImportStatus Status { get; set; }
    }
}
