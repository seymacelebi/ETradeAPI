using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeAPI.Application.Features.Queries.ProductVariant.GetAllProductVariant
{
    public class GetAllProductVariantQueryResponse
    {
        public int TotalCount { get; set; }
        public object ProductsVariant { get; set; }
    }
}
