using ETradeAPI.Domain.Entities.Common;
using ETradeAPI.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeAPI.Domain.Entities
{
    public class Basket : BaseEntity
    {
        public Guid CustomerId { get; set; }

        public Customer Customer { get; set; }
        public ICollection<BasketItem> BasketItems { get; set; }
    }
}
