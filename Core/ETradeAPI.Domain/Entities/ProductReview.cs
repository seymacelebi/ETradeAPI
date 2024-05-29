using ETradeAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeAPI.Domain.Entities
{
    public class ProductReview : BaseEntity
    {
        public int ProductId {  get; set; }
        public int CsustomerId { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }

        public Product Product { get; set; }
        public Customer Customer { get; set; }
    }
}
