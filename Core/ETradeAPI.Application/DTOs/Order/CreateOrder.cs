using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeAPI.Application.DTOs.Order
{
    public class CreateOrder
    {
        public string? CustomerId { get; set; }
        public string? BasketId { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public decimal TotalAmount { get; set; }
        public string PaymentMethod { get; set; }
        public string ShippingMethod { get; set; }
        public string ShippingTrackingNumber { get; set; }
    }
}
