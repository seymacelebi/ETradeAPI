﻿using ETradeAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeAPI.Domain.Entities
{
    public class ProductDiscount : BaseEntity
    {
        public int ProductId { get; set; }
        public int DiscountId { get; set; }

        public Discount Discount { get; set; }
        public Product Product { get; set; }


    }
}
