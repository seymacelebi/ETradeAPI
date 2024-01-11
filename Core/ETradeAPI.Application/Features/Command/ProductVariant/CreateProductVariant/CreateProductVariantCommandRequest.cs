using ETradeAPI.Application.Features.Command.Product.CreateProduct;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeAPI.Application.Features.Command.ProductVariant.CreateProductVariant
{
    public class CreateProductVariantCommandRequest : IRequest<CreateProductVariantCommandResponse>
    {
        public string VariantType { get; set; }
        //public List<VariantOptionCreateRequest> Options { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
    }
}
