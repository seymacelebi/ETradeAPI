using ETradeAPI.Application.Features.Queries.Product.GetAllProduct;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeAPI.Application.Features.Queries.ProductImage.GetAllProductImage
{
    public class GetAllProductImageQueryRequest : IRequest<GetAllProductImageQueryResponse>
    {
        public int Page { get; set; } = 0;
        public int Size { get; set; } = 5;
    }
}
