using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Z2data.Core
{
    /// <summary>
    /// Base class for entities
    /// </summary>
    public abstract partial class BaseEntity
    {
        /// <summary>
        /// Gets or sets the entity identifier
        /// </summary>
        [BsonElement(Order = 1)]
        public ObjectId Id { get; set; }

    }
    public abstract partial class BaseEmbeddedEntity
    {
        public string Id { get; set; }

    }
}
