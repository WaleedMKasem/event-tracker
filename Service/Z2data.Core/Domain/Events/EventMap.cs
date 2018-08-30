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
    public class EventMap
    {
        public string Id { get; set; }
        public string Code { get; set; }
        public int CountryId { get; set; }
        public string CountryName { get; set; }
        public int CityId { get; set; }
        public string CityName { get; set; }
        public int StateId { get; set; }
        public string Name { get; set; }
        public string Other { get; set; }
        public string CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string TypeId { get; set; }
        public string TypeName { get; set; }
        public DateTime? StartDate { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public IList<SourceMap> Sources { get; set; }
        public IList<MiniAttachment> Images { get; set; }
        public IList<MiniAttachment> Attachments { get; set; }
        public Severity Severity { get; set; }
        public Status Status { get; set; }
        public float? StatusPercentage { get; set; }
        public DateTime? CloseDate { get; set; }
        public string CloseNotes { get; set; }
        public double? Value { get; set; }
        public DisasterUnit Unit { get; set; }

        //(Human)
        public int? PopulationAffected { get; set; }
        public int? PopulationDeaths { get; set; }
        public int? PopulationMissing { get; set; }

        //(Properties)
        public double? AcresBurned { get; set; }
        public double? DamageInMillionUsd { get; set; }
        public string DamageInProperty { get; set; }
        public double? InsuredLosses { get; set; }
        public string Notes { get; set; }
        public double? AffectedRadius { get; set; }
        public double? NearRadius { get; set; }
        public LocationType Type { get; set; }

        [BsonRepresentation(BsonType.Double, AllowTruncation = true)]
        public double[] Coordinates { get; set; }
        public string AssociatedEventCategoryId { get; set; }
        public string AssociatedEventCategoryName { get; set; }
        public string AssociatedEventTypeId { get; set; }
        public string AssociatedEventTypeName { get; set; }
        public Severity AssociatedEventSeverity { get; set; }
        public double? AssociatedEventAffectedRadius { get; set; }
        public double? AssociatedEventNearRadius { get; set; }
        public LocationType AssociatedEventType { get; set; }

        [BsonRepresentation(BsonType.Double, AllowTruncation = true)]
        public double[] AssociatedEventCoordinates { get; set; }
        public IList<AffectedLocation> AffectedLocations { get; set; }
        public bool IsAlert { get; set; }
        public IList<Event> Updates { get; set; }
    }
}
