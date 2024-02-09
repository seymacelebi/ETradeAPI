using ETradeAPI.Application.Features.Queries.Product.GetAllProduct;
using ETradeAPI.Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeAPI.Application.Features.Queries.ProductImage.GetAllProductImage
{
    public class GetAllProductImageQueryHandler : IRequestHandler<GetAllProductImageQueryRequest, GetAllProductImageQueryResponse>
    {
        readonly IProductReadRepository _productReadRepository;

        public GetAllProductImageQueryHandler(IProductReadRepository productReadRepository)
        {
            _productReadRepository = productReadRepository;
        }

        public async Task<GetAllProductImageQueryResponse> Handle(GetAllProductImageQueryRequest request, CancellationToken cancellationToken)
        {
            var query = _productReadRepository.GetAll(false);

            var totalCount = query.Count();
            var productImage = query
               .Skip(request.Page * request.Size)
               .Take(request.Size)
               .Select(p => new
               {
                  p.ImagePath
               })
               .ToList();

            return new GetAllProductImageQueryResponse
            {
               ProductsImage = productImage,
                TotalCount = totalCount
            };
        }
    }
}
