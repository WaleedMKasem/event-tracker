using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Z2data.Core.Domain.Lookups;
using Z2data.Core.Enums;

namespace Z2data.Core.Domain.Events
{
    public class AssociatedEvent
    {
        public Lookup Category { get; set; }
        public Lookup Type { get; set; }
        public Severity Severity { get; set; }
        public EffectRange EffectRange { get; set; }
        public Status CategoryStatus { get; set; }
    }
}
