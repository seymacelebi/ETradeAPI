using ETradeAPI.Application.Exceptions;
using ETradeAPI.Application.Features.Command.ProductImage.CreateProductImage;
using ETradeAPI.Application.Features.Command.ProductImage.DeleteProductımage;
using ETradeAPI.Application.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeAPI.Application.Features.Command.ProductImage.UpdateProductImage
{
    public class UpdateProductImageCommandHandler : IRequestHandler<UpdateProductImageCommandRequest, UpdateProductImageCommandResponse>
    {
        readonly IProductReadRepository _productReadRepository;
        readonly IProductWriteRepository _productWriteRepository;


        public UpdateProductImageCommandHandler(IProductReadRepository productReadRepository, IProductWriteRepository productWriteRepository)
        {
            _productWriteRepository = productWriteRepository;
            _productReadRepository = productReadRepository;

        }

        
        public async Task<UpdateProductImageCommandResponse> Handle(UpdateProductImageCommandRequest request, CancellationToken cancellationToken)
        {
            var entity = await _productReadRepository.Table.Where(x => x.Id == request.ProductId).SingleOrDefaultAsync();
            if (entity != null)
            {
                if (entity.ImagePath != null)
                {
                    // Replace the existing image path with the new one
                    entity.ImagePath = new List<string> { request.NewImagePath };
                }
                else
                {
                    entity.ImagePath = new List<string> { request.NewImagePath };
                }

                await _productWriteRepository.SaveAsync();

                var response = new UpdateProductImageCommandResponse
                {
                    // Set properties of the response object if needed.
                };

                return response;
            }
            else
            {
                // Handle the case where the product with the specified ID does not exist
                throw new NotFoundException("Product not found");
            }
        }

    }
}
