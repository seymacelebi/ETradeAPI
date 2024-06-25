using ETradeAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeAPI.Domain.Entities
{
    public class ReturnRequest:BaseEntity
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public string Reason { get; set; }
        public string Status { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
    }

    public class OrderFulfillment : BaseEntity
    {
        public int OrderId { get; set; }
        public int WarehouseId { get; set; }
        public string FulfillmentStatus { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        public virtual Order Order { get; set; }
        public virtual WarehouseLocation WarehouseLocation { get; set; }
    }
}
