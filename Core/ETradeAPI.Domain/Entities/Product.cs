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
        public Guid CategoryId { get; set; }
        public string Name { get; set; }
        public int Stock { get; set; }
        public float Price { get; set; }
        public string Description { get; set; }
        //public ICollection<Order> Orders { get; set;}
        public ICollection<BasketItem> BasketItems { get; set; }
        public List<ProductVariant> Variants { get; set; }
        public Category Category { get; set; }
        public List<string>? ImagePath { get; set; }


    }
}
