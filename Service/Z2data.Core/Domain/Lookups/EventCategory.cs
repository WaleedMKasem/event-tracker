using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Z2data.Core.Domain.Lookups
{
    public class EventCategory:BaseEntity
    {
        public string Name { get; set; }
        public IList<CategoryEventType> EventTypes { get; set; }
    }
}
