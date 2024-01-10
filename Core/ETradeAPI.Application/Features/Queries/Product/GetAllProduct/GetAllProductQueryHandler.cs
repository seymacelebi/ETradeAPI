using ETradeAPI.Application.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeAPI.Application.Features.Queries.Product.GetAllProduct
{
    public class GetAllProductQueryHandler : IRequestHandler<GetAllProductQueryRequest, GetAllProductQueryResponse>
    {
        readonly IProductReadRepository _productReadRepository;
        readonly ICategoryReadRepository _categoryReadRepository;
        public GetAllProductQueryHandler(IProductReadRepository productReadRepository, ICategoryReadRepository categoryReadRepository)
        {
            _productReadRepository = productReadRepository;
            _categoryReadRepository = categoryReadRepository;
        }
        public async Task<GetAllProductQueryResponse> Handle(GetAllProductQueryRequest request, CancellationToken cancellationToken)
        {
            var query = _productReadRepository.GetAll(false);

            var totalCount = query.Count();

            var products = query
                .Skip(request.Page * request.Size)
                .Take(request.Size)
                .Select(p => new
                {
                    p.Id,
                    p.Name,
                    p.Stock,
                    p.Price,
                    p.Description,
                    CategoryName = p.Category.Name, 
                })
                .ToList();

            return new GetAllProductQueryResponse
            {
                Products = products,
                TotalCount = totalCount
            };
        }


        //public async Task<GetAllProductQueryResponse> Handle(GetAllProductQueryRequest request, CancellationToken cancellationToken)
        //{

        //   var totalCount = _productReadRepository.GetAll(false).Count();
        //    var products = _productReadRepository.GetAll(false).Skip(request.Page * request.Size).Take(request.Size).Select(p => new
        //    {
        //        p.Id, 
        //        p.Name,
        //        p.Stock,
        //        p.Price, 
        //        p.Description,
        //        p.Category.Name,

        //    }).ToList();
        //    return new()
        //    {
        //        Products = products,
        //        TotalCount = totalCount
        //    };
        //}
    }
}
