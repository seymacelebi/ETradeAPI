using ETradeAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeAPI.Domain.Entities
{
    public class ProductVariant : BaseEntity
    {
        
        public string VariantName { get; set; }
        public List<VariantOption> Options { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }

    }
    //public class ProductVariant : BaseEntity
    //{
    //    //public Guid ProductId { get; set; }
    //    //public string VariantType { get; set; }
    //    //public List<VariantOption> Options { get; set; }
    //    //public Product Product { get; set; }
    //    //public decimal Price { get; set; }
    //    //public int StockQuantity { get; set; }
    //    public string VariantName { get; set; }
    //    public List<VariantOption> Options { get; set; }
    //    public decimal Price { get; set; }
    //    public int StockQuantity { get; set; }

    //}
}
