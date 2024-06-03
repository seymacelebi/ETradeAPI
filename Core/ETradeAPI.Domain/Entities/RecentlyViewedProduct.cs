using ETradeAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeAPI.Domain.Entities
{
    public class RecentlyViewedProduct :BaseEntity
    {
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
        public DateTime ViewedAt { get; set; }

        public Product Product { get; set; }
        public Customer Customer { get; set; }

    }
}
