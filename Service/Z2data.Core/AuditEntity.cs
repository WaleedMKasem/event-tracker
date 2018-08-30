using System;

namespace Z2data.Core
{
    public abstract partial class AuditEntity: BaseEntity
    {
        public int? CreatedBy { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public bool IsDeleted { get; set; }
        public int? DeletedBy { get; set; }
        public DateTime? DeletedOn { get; set; }
    }
}