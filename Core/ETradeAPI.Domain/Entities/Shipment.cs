using ETradeAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeAPI.Domain.Entities
{
    public class Shipment :BaseEntity
    {
        public int OrderId { get; set; }
        public DateTime ShipmentDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public string ShippingMethod { get; set; }
        public string TrackingNumber { get; set; }

        // Navigation property
        public Order Order { get; set; }
    }
}
