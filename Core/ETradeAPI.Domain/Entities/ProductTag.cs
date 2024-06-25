using ETradeAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeAPI.Domain.Entities
{
    public class ProductTag : BaseEntity
    {
        public int ProductId { get; set; }
        public string Tag { get; set; }

        public virtual Product Product { get; set; }
    }
}
