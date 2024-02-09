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


        public async Task<CreateProductVariantCommandResponse> Handle(CreateProductVariantCommandRequest request, CancellationToken cancellationToken)
        {
            var productVariant = new Domain.Entities.ProductVariant
            {

                VariantName = request.VariantName,
                Price = request.Price,
                StockQuantity = request.StockQuantity
            };

            foreach (var optionDto in request.Options)
            {
                var variantOption = new Domain.Entities.VariantOption
                {
                    Id = optionDto.OptionId,
                    OptionName = optionDto.OptionName,
                    ProductVariant = productVariant,
                };

                productVariant.Options.Add(variantOption);
            }

            await _productVariantWriteRepository.AddAsync(productVariant);

            var response = new CreateProductVariantCommandResponse
            {
                Id = productVariant.Id,
            };

            return response;
        }
        //public async Task<CreateProductVariantCommandResponse> Handle(CreateProductVariantCommandRequest request, CancellationToken cancellationToken)
        //{
        //    var entity = new Domain.Entities.ProductVariant
        //    {
        //        VariantName = request.VariantName,
        //        Price = request.Price,
        //        StockQuantity = request.StockQuantity,
        //        Options = request.Options.Distinct().Select(x => new VariantOption
        //        {
        //            OptionId = x.OptionId,
        //            OptionName = x.OptionName,
        //        }).ToList()

        //    };
        //    await _productVariantWriteRepository.AddAsync(entity);

        //}
    }
}
