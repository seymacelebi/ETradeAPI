using ETradeAPI.Application.Features.Command.Product.CreateProduct;
using ETradeAPI.Application.Repositories;
using ETradeAPI.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Google.Apis.Requests.BatchRequest;

namespace ETradeAPI.Application.Features.Command.ProductVariant.CreateProductVariant
{
    public class CreateProductVariantCommandHandler : IRequestHandler<CreateProductVariantCommandRequest, CreateProductVariantCommandResponse>
    {
        readonly IProductVariantWriteRepository _productVariantWriteRepository;
        readonly IProductVariantReadRepository _productVariantReadRepository;

        public CreateProductVariantCommandHandler(IProductVariantReadRepository productVariantReadRepository, IProductVariantWriteRepository productVariantWriteRepository)
        {
            _productVariantReadRepository = productVariantReadRepository;
            _productVariantWriteRepository = productVariantWriteRepository;
        }

        //public async Task<CreateProductVariantCommandResponse> Handle(CreateProductVariantCommandRequest request, CancellationToken cancellationToken)
        //{
        //   await _productVariantWriteRepository.AddAsync(new Domain.Entities.ProductVariant
        //   {
        //       ProductId= request.ProductId,

        //       VariantType= request.VariantType,
        //       Options = request.Options.Select(opt => new Domain.Entities.VariantOption { OptionName = opt.OptionName }).ToList(),
        //       Price = request.Price,
        //       StockQuantity= request.StockQuantity,    
        //   });

        //    await _productVariantWriteRepository.SaveAsync();

        //    var response = new CreateProductVariantCommandResponse
        //    {
        //        // Set properties of the response object if needed.
        //    };

        //    return response;
        //}
        public async Task<CreateProductVariantCommandResponse> Handle(CreateProductVariantCommandRequest request, CancellationToken cancellationToken)
        {
            // ...

            // Options özelliğini dönüştürerek uygun türde bir listeye çevirme.
            var variantOptions = request.Options.Select(opt => new Domain.Entities.VariantOption { OptionName = opt.OptionName }).ToList();

            var newProductVariant = new Domain.Entities.ProductVariant
            {
                Id = Guid.NewGuid(), // Set a new GUID for the Id property
                ProductId = request.ProductId,
                VariantType = request.VariantType,
                Options = variantOptions, // Uygun türdeki listeyi atama.
                Price = request.Price,
                StockQuantity = request.StockQuantity,
            };

            await _productVariantWriteRepository.AddAsync(newProductVariant);

            await _productVariantWriteRepository.SaveAsync();

            // ...

            var response = new CreateProductVariantCommandResponse
            {
                // Set properties of the response object if needed.
                Id = newProductVariant.Id, // Assign the Id of the newly created ProductVariant
            };

            return response;
        }



    }
}
