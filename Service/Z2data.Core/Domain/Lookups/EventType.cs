namespace Z2data.Core.Domain.Lookups
{
    public class CategoryEventType : BaseEmbeddedEntity
    {
        public string Name { get; set; }
        public string Unit { get; set; }
    }
    public class EventType : BaseEntity
    {
        public string Name { get; set; }
        public string Unit { get; set; }
    }
}
