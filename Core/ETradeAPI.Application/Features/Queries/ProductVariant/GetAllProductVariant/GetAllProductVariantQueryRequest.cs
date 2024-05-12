using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeAPI.Application.Features.Queries.ProductVariant.GetAllProductVariant
{
    public class GetAllProductVariantQueryRequest : IRequest<GetAllProductVariantQueryResponse>
    {
        public int Page { get; set; } = 0;
        public int Size { get; set; } = 5;
    }
}
