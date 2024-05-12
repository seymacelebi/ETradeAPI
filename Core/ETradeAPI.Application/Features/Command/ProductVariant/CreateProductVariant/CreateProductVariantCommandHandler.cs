using ETradeAPI.Application.Repositories;
using ETradeAPI.Domain.Entities;
using MediatR;


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
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var productVariant = new Domain.Entities.ProductVariant
            {
                VariantName = request.VariantName,
                Price = request.Price,
                StockQuantity = request.StockQuantity
            };

            if (request.Options != null)
            {
                foreach (var optionDto in request.Options)
                {
                    if (optionDto == null)
                    {
                        continue;
                    }

                    var variantOption = new Domain.Entities.VariantOption
                    {
                        Id = Guid.NewGuid(),
                        OptionName = optionDto.OptionName,
                        ProductVariant = productVariant
                    };

                    if (productVariant.Options == null)
                    {
                        productVariant.Options = new List<Domain.Entities.VariantOption>();
                    }

                    productVariant.Options.Add(variantOption);
                }
            }

            if (_productVariantWriteRepository == null)
            {
                throw new InvalidOperationException("_productVariantWriteRepository is null");
            }

            await _productVariantWriteRepository.AddAsync(productVariant);

            // Dönüşüm: Domain.Entities.VariantOption'dan VariantOptionResponse'a
            var optionResponses = productVariant.Options.Select(opt =>
                new VariantOptionResponse
                {
                    Id = opt.Id,
                    OptionName = opt.OptionName,
                }).ToList();

            var response = new CreateProductVariantCommandResponse
            {
                Id = productVariant.Id,
                VariantName = productVariant.VariantName,
                Price = productVariant.Price,
                StockQuantity = productVariant.StockQuantity,
                Options = optionResponses  // Dönüştürülmüş liste response'a atanıyor
            };

            return response;
        }


        //public async Task<CreateProductVariantCommandResponse> Handle(CreateProductVariantCommandRequest request, CancellationToken cancellationToken)
        //{
        //    if (request == null)
        //    {
        //        throw new ArgumentNullException(nameof(request));
        //    }

        //    var productVariant = new Domain.Entities.ProductVariant
        //    {
        //        VariantName = request.VariantName,
        //        Price = request.Price,
        //        StockQuantity = request.StockQuantity
        //    };

        //    if (request.Options != null)
        //    {
        //        foreach (var optionDto in request.Options)
        //        {
        //            if (optionDto == null)
        //            {
        //                continue; // veya uygun bir işlem yapabilirsiniz
        //            }

        //            var variantOption = new Domain.Entities.VariantOption
        //            {
        //                Id = Guid.NewGuid(), // Yeni bir GUID oluşturuyoruz
        //                OptionName = optionDto.OptionName,
        //                ProductVariant = productVariant
        //            };

        //            if (productVariant.Options == null)
        //            {
        //                productVariant.Options = new List<Domain.Entities.VariantOption>();
        //            }

        //            productVariant.Options.Add(variantOption);
        //        }
        //    }

        //    if (_productVariantWriteRepository == null)
        //    {
        //        throw new InvalidOperationException("_productVariantWriteRepository is null");
        //    }

        //    await _productVariantWriteRepository.AddAsync(productVariant);

        //    var response = new CreateProductVariantCommandResponse
        //    {
        //        Id = productVariant.Id,
        //        VariantName = productVariant.VariantName,
        //        Price = productVariant.Price,
        //        StockQuantity = productVariant.StockQuantity,

        //};

        //    return response;
        //}



        //public async Task<CreateProductVariantCommandResponse> Handle(CreateProductVariantCommandRequest request, CancellationToken cancellationToken)
        //{
        //    var productVariant = new Domain.Entities.ProductVariant
        //    {

        //        VariantName = request.VariantName,
        //        Price = request.Price,
        //        StockQuantity = request.StockQuantity
        //    };

        //    foreach (var optionDto in request.Options)
        //    {
        //        var variantOption = new Domain.Entities.VariantOption
        //        {
        //            Id = new Guid(),
        //            OptionName = optionDto.OptionName,
        //            ProductVariant = productVariant,
        //        };

        //        productVariant.Options.Add(variantOption);
        //    }

        //    await _productVariantWriteRepository.AddAsync(productVariant);

        //    var response = new CreateProductVariantCommandResponse
        //    {
        //        Id = productVariant.Id,
        //    };

        //    return response;
        //}

    }
}
public class ProductVariantDto
{
    public Guid Id { get; set; }
    public string VariantName { get; set; }
    public List<VariantOption> Options { get; set; }
    public decimal Price { get; set; }
    public int StockQuantity { get; set; }
}