using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Z2data.Core.Domain.Lookups;

namespace Z2data.Core.Domain.Events
{
    public class Place
    {
        public Country Country { get; set; }
        public State State { get; set; }
        public City City { get; set; }
        public string Other { get; set; }
    }
}
