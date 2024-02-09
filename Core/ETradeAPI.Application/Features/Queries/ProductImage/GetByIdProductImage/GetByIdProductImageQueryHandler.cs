using ETradeAPI.Application.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P = ETradeAPI.Domain.Entities;
namespace ETradeAPI.Application.Features.Queries.ProductImage.GetByIdProductImage
{
    public class GetByIdProductImageQueryHandler : IRequestHandler<GetByIdProductImageQueryRequest, GetByIdProductImageQueryResponse>
    {
        readonly IProductReadRepository _productReadRepository;

        public GetByIdProductImageQueryHandler(IProductReadRepository productReadRepository)
        {
            _productReadRepository = productReadRepository;
        }

        public Task<GetByIdProductImageQueryResponse> Handle(GetByIdProductImageQueryRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        //public async Task<GetByIdProductImageQueryResponse> Handle(GetByIdProductImageQueryRequest request, CancellationToken cancellationToken)
        //{
        //    P.Product product = await _productReadRepository.Table.Include(o => o.Category)
        //       .FirstOrDefaultAsync(p => p.Id == (Guid.Parse(request.Id)));
        //    return new()
        //    {
        //        ProductImage= product.ImagePath,

        //    };
        //}
    }
}
