using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Z2data.Core.Domain.Lookups;
using Z2data.Core.Enums;

namespace Z2data.Core.Domain.Events
{
    public class DisasterHistory : AuditEntity
    {
        //public int DisasterId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public Place Place { get; set; }
        public Location Location { get; set; }
        public Lookup Type { get; set; }
        public double? Value { get; set; }
        public DisasterUnit Unit { get; set; }
        public SubEventType SubType { get; set; }
        public string AssociatedDisaster { get; set; }
        public string OtherAssociatedDisaster { get; set; }
        public int? TotalDeaths { get; set; }
        public int? TotalAffected { get; set; }
        public double? TotalDamage { get; set; }
        public double? InsuredLosses { get; set; }
        public string DisasterName { get; set; }
        public Severity Severity { get; set; }
        public double? Radius { get; set; }
    }
}
