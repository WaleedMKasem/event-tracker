using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Z2data.Core.Domain.Lookups;
using Z2data.Core.Enums;

namespace Z2data.Core.Domain.Events
{
   public class MiniEvent:BaseEntity
    {
        public string Code { get; set; }
        public string Category { get; set; }
        public string Type { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? LastUpdated { get; set; }
        public string Title { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Severity { get; set; }
        public string Status { get; set; }
    }
}
