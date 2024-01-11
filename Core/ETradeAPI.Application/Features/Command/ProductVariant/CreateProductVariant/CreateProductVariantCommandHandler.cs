using ETradeAPI.Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public Task<CreateProductVariantCommandResponse> Handle(CreateProductVariantCommandRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
