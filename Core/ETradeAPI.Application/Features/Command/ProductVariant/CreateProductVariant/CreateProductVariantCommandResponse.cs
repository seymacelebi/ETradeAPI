using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeAPI.Application.Features.Command.ProductVariant.CreateProductVariant
{
    public class CreateProductVariantCommandResponse
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public string VariantType { get; set; }
        public List<VariantOptionResponse> Options { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
    }
    public class VariantOptionResponse
    {
        public Guid Id { get; set; }
        public string OptionName { get; set; }
    }
}
