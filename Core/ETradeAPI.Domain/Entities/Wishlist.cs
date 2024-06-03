using ETradeAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeAPI.Domain.Entities
{
    public class Wishlist :BaseEntity
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public List<WishlistItem> Items { get; set; }
    }
}
