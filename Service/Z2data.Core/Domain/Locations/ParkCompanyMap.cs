using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Z2data.Core.Enums;

namespace Z2data.Core.Domain.Locations
{
    public class ParkCompanyMap
    {    
        public string ParkName { get; set; }
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public ImportStatus Status { get; set; }
    }
}
