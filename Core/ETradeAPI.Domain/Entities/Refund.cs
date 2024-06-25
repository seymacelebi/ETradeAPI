using ETradeAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeAPI.Domain.Entities
{
    public class Refund : BaseEntity
    {
        public int OrderId { get; set; }
        public decimal Amount { get; set; }
        public string Reason { get; set; }
        public DateTime RefundDate { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        public virtual Order Order { get; set; }
    }

    public class Invoice : BaseEntity
    {
        public int OrderId { get; set; }
        public string InvoiceNumber { get; set; }
        public DateTime InvoiceDate { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        public virtual Order Order { get; set; }
    }
}
