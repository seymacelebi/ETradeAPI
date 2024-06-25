using ETradeAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeAPI.Domain.Entities
{
    public class Product : BaseEntity
    {
        public int CategoryId { get; set; }
        public int BrandId { get; set; }
        public string Name { get; set; }
        public int Stock { get; set; }
        public float Price { get; set; }
        public string Description { get; set; }
        public ICollection<BasketItem> BasketItems { get; set; }
        public List<ProductVariant> Variants { get; set; }
        public Category Category { get; set; }
        public Brand Brand { get; set; }
        public List<string>? ImagePath { get; set; }

        public ICollection<ProductReview> ProductReviews { get; set; }
        public ICollection<ProductDiscount> ProductDiscounts { get; set; } // New relationship

        public ICollection<ProductSupplier> ProductSuppliers { get; set; }
        public ICollection<RecentlyViewedProduct> RecentlyViewedProducts { get; set; }

        public virtual ICollection<ProductTag> ProductTags { get; set; }
    }
}
