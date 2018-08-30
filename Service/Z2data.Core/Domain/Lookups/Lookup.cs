using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Z2data.Core.Domain.Lookups
{
    public class Lookup : BaseEmbeddedEntity
    {
        public string Name { get; set; }
    }
}
