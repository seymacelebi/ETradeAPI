using ETradeAPI.Application.Features.Queries.Product.GetAllProduct;
using ETradeAPI.Application.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using P = ETradeAPI.Domain.Entities;

namespace ETradeAPI.Application.Features.Queries.Product.GetByIdProduct
{
    public class GetByIdProductQueryHandler : IRequestHandler<GetByIdProductQueryRequest, GetByIdProductQueryResponse>
    {
        readonly IProductReadRepository _productReadRepository;
        public GetByIdProductQueryHandler(IProductReadRepository productReadRepository)
        {
            _productReadRepository = productReadRepository;
        }
        public async Task<GetByIdProductQueryResponse> Handle(GetByIdProductQueryRequest request, CancellationToken cancellationToken)
        {
            //P.Product product = await _productReadRepository.GetByIdAsync(request.Id, false)
            //                            .Include(p => p.Category)
            //                            .FirstOrDefaultAsync();
            P.Product product = await _productReadRepository.Table.Include(o => o.Category)
                .FirstOrDefaultAsync(p => p.Id == (Int16.Parse(request.Id)));

            //Order? order = await _orderReadRepository.Table
            //    .Include(o => o.Basket)
            //    .ThenInclude(b => b.User)
            //    .FirstOrDefaultAsync(o => o.Id == Guid.Parse(id));

            return new()
            {
                Name = product.Name,
                Price = product.Price,
                Stock = product.Stock,
                Description = product.Description,
                CategoryName = product.Category?.Name
              
            };
        }
    }
}
