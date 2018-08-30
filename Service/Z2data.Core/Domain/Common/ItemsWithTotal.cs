using System.Collections.Generic;

namespace Z2data.Core.Domain.Common
{
    public class ItemsWithTotal<T>
    {
        public IList<T> Items { get; set; }
        public long Total { get; set; }
    }
}