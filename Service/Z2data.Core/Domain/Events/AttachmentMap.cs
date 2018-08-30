using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Z2data.Core.Domain.Events
{
    public class AttachmentMap
    {
        public string Name { get; set; }
        public string Extension { get; set; }
    }

    public class MiniAttachmentMap
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Extension { get; set; }
    }
}
