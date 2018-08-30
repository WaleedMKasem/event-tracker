using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Z2data.Core.Domain.Lookups;

namespace Z2data.Core.Domain.Events
{
    public class EffectRange
    {
        //Event Georgaphical Place
        public double? AffectedRadius { get; set; }
        public double? NearRadius { get; set; }
        public Location Location { get; set; }

    }
}
