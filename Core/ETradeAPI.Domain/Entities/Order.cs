using ETradeAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ETradeAPI.Domain.Entities
{
    public class Order : BaseEntity
    {
        // Foreign key
        public int CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public string Status { get; set; }
        public decimal TotalAmount { get; set; }
        public string PaymentMethod { get; set; }
        public int ShippingAddressId { get; set; }
        public int BillingAddressId { get; set; }

        public Customer Customer { get; set; }
        public Address ShippingAddress { get; set; }
        public Address BillingAddress { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
        public ICollection<Payment> Payments { get; set; }
        public ICollection<Shipment> Shipments { get; set; } // New relationship

        public virtual ICollection<OrderFulfillment> OrderFulfillments { get; set; }
        public virtual ICollection<Refund> Refunds { get; set; }
        public virtual ICollection<Invoice> Invoices { get; set; }


    }

}
