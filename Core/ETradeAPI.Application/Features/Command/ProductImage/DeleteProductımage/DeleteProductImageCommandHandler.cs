using ETradeAPI.Application.Features.Command.Product.DeleteProduct;
using ETradeAPI.Application.Features.Command.ProductImage.CreateProductImage;
using ETradeAPI.Application.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeAPI.Application.Features.Command.ProductImage.DeleteProductımage
{
    public class DeleteProductImageCommandHandler : IRequestHandler<DeleteProductImageCommandRequest, DeleteProductImageCommandResponse>
    {
        readonly IProductReadRepository _productReadRepository;
        readonly IProductWriteRepository _productWriteRepository;

        public DeleteProductImageCommandHandler(IProductWriteRepository productWriteRepository, IProductReadRepository productReadRepository)
        {
            _productWriteRepository = productWriteRepository;
            _productReadRepository = productReadRepository;
        }

        public async Task<DeleteProductImageCommandResponse> Handle(DeleteProductImageCommandRequest request, CancellationToken cancellationToken)
        {
           
            var entity = await _productReadRepository.Table.Where(x => x.Id == request.ProductId).SingleAsync();

            if (entity.ImagePath != null && entity.ImagePath.Any())
            {
                entity.ImagePath.RemoveAll(path => request.ImagePaths.Contains(path));
            }
            await _productWriteRepository.SaveAsync();
            var response = new DeleteProductImageCommandResponse
            {

            };
            return response;
        }
    }
}
