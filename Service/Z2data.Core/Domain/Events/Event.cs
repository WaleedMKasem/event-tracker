using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Z2data.Core.Domain.Events
{
   public class Event:AuditEntity
    {
        public string Code { get; set; }
        public Place Place { get; set; }
        public EventDetails Details { get; set; }
        public EventFeature Features { get; set; }
        public EffectRange EffectRange { get; set; }
        public AssociatedEvent AssociatedEvent { get; set; }
        public IList<AffectedLocation> AffectedLocations { get; set; }
        public bool IsAlert { get; set; }
        public IList<Event> Updates { get; set; }
    }
}
