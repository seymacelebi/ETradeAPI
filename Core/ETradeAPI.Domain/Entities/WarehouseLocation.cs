using ETradeAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeAPI.Domain.Entities
{
    public class WarehouseLocation : BaseEntity
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }

        public virtual ICollection<InventoryMovement> InventoryMovements { get; set; }
    }

    public class InventoryMovement : BaseEntity
    {
        public int ProductId { get; set; }
        public int WarehouseId { get; set; }
        public string MovementType { get; set; } // Incoming, Outgoing, Transfer
        public int Quantity { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        public virtual Product Product { get; set; }
        public virtual WarehouseLocation WarehouseLocation { get; set; }
    }
}