﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Z2data.Core.Domain.Lookups;
using Z2data.Core.Enums;

namespace Z2data.Core.Domain.Events
{
    public class EventDetails
    {
        public Lookup Category { get; set; }
        public Lookup Type { get; set; }
        public DateTime? StartDate { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public IList<Source> Sources { get; set; }
        public IList<MiniAttachment> Images { get; set; }
        public IList<MiniAttachment> Attachments { get; set; }
        public Severity Severity { get; set; }
        public Status Status { get; set; }
        public float? StatusPercentage { get; set; }
        public DateTime? CloseDate { get; set; }
        public string CloseNotes { get; set; }
    }
}
