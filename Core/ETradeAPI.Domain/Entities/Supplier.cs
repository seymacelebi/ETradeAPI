using ETradeAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeAPI.Domain.Entities
{
    public class Supplier : BaseEntity
    {
        public string Name { get; set; }
        public string ContactName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Email { get; set; }

        public ICollection<ProductSupplier> ProductSuppliers { get; set; }

    }
}
