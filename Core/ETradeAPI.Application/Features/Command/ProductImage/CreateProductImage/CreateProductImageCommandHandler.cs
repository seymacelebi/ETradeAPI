using ETradeAPI.Application.Features.Command.Product.CreateProduct;
using ETradeAPI.Application.Repositories;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeAPI.Application.Features.Command.ProductImage.CreateProductImage
{
    public class CreateProductImageCommandHandler : IRequestHandler<CreateProductImageCommandRequest, CreateProductImageCommandResponse>
    {
        readonly IProductReadRepository _productReadRepository;
        readonly IProductWriteRepository _productWriteRepository;

        public CreateProductImageCommandHandler(IProductReadRepository productReadRepository, IProductWriteRepository productWriteRepository)
        {
            _productReadRepository = productReadRepository;
            _productWriteRepository = productWriteRepository;
        }

        public async Task<CreateProductImageCommandResponse> Handle(CreateProductImageCommandRequest request, CancellationToken cancellationToken)
        {
          var entity = await _productReadRepository.Table.Where(x => x.Id == request.ProductId).SingleAsync();
            if (entity.ImagePath == null)
                entity.ImagePath = new List<string>();
            foreach (var imagePath in request.ImagePaths)
            {
                if (!entity.ImagePath.Contains(imagePath))
                {
                    entity.ImagePath.Add(imagePath);
                }
            }
          
            await _productWriteRepository.SaveAsync();
            var response = new CreateProductImageCommandResponse
            {
                // Set properties of the response object if needed.
            };

            return response;
        }
    }
}
