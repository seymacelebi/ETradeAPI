using ETradeAPI.Application.Features.Queries.Product.GetAllProduct;
using ETradeAPI.Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeAPI.Application.Features.Queries.ProductVariant.GetAllProductVariant
{
    public class GetAllProductVariantQueryHandler : IRequestHandler<GetAllProductVariantQueryRequest, GetAllProductVariantQueryResponse>
    {
        readonly IProductVariantWriteRepository _productVariantWriteRepository;
        readonly IProductVariantReadRepository _productVariantReadRepository;
        public GetAllProductVariantQueryHandler(IProductVariantReadRepository productVariantReadRepository)
        {
            _productVariantReadRepository = productVariantReadRepository;
        }
        //public async Task<GetAllProductVariantQueryResponse> Handle(GetAllProductVariantQueryRequest request, CancellationToken cancellationToken)
        //{
        //    var query = _productVariantReadRepository.GetAll(false);

        //    var totalCount = query.Count();

        //    var productVariant = query
        //        .Skip(request.Page * request.Size)
        //        .Take(request.Size)
        //        .Select(p => new
        //        {
        //           p.Id,
        //           p.VariantName,
        //           p.Price,
        //           p.StockQuantity,
        //        })
        //        .ToList();

        //    return new GetAllProductVariantQueryResponse
        //    {

        //        ProductsVariant = productVariant,
        //        TotalCount = totalCount
        //    };
        //}
        public async Task<GetAllProductVariantQueryResponse> Handle(GetAllProductVariantQueryRequest request, CancellationToken cancellationToken)
        {
            var query = _productVariantReadRepository.GetAll(false);

            var totalCount = query.Count();

            var productVariants = query
                .Skip(request.Page * request.Size)
                .Take(request.Size)
                .Select(p => new
                {
                    p.Id,
                    p.VariantName,
                    p.Price,
                    p.StockQuantity,
                    Options = p.Options.Select(o => new
                    {
                        o.Id,
                        o.OptionName
                    }).ToList()
                })
                .ToList();

            return new GetAllProductVariantQueryResponse
            {
                ProductsVariant = productVariants,
                TotalCount = totalCount
            };
        }

    }
}
