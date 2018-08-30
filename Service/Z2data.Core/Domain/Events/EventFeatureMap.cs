using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Z2data.Core.Enums;

namespace Z2data.Core.Domain.Events
{
    public class EventFeatureMap
    {
        //(Magnitude)
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
    }
}
