using ETradeAPI.Application.Features.Queries.Product.GetByIdProduct;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeAPI.Application.Features.Queries.Category.GetByIdCategory
{
    public class GetByIdCategoryQueryRequest : IRequest<GetByIdCategoryQueryResponse>
    {
        public string Id { get; set; }
    }
}
