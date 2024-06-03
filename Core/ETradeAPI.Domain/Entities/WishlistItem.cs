using ETradeAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeAPI.Domain.Entities
{
    public class WishlistItem :BaseEntity
    {
        public int WishlistId { get; set; }
        public int ProductId { get; set; }

        // Navigation properties
        public Wishlist Wishlist { get; set; }
        public Product Product { get; set; }
    }
}
