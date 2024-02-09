using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeAPI.Application.Features.Queries.ProductImage.GetAllProductImage
{
    public class GetAllProductImageQueryResponse
    {
        public int TotalCount { get; set; }
        public object ProductsImage { get; set; }
    }
}
