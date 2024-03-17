using ETradeAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeAPI.Domain.Entities
{
    public class Order : BaseEntity
    {
        public Guid? CustomerId { get; set; }
        public Guid? BasketId { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string OrderCode { get; set; }

        public Basket Basket { get; set; }
        public Customer Customer { get; set; }
        public decimal TotalAmount { get; set; }
        public string PaymentMethod { get; set; }
        public string ShippingMethod { get; set; }
        public string ShippingTrackingNumber { get; set; }
        public PaymentStatusEnum PaymentStatus { get; set; }

        //order status     
        public CompletedOrder CompletedOrder { get; set; }
    }
    public enum PaymentStatusEnum
    {
        Pending = 10,
        Failed = 20,
        Paid = 30,
        Refunded = 40,
    }

}
