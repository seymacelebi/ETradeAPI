﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeAPI.Application.Features.Queries.ProductImage.GetByIdProductImage
{
    public class GetByIdProductImageQueryRequest : IRequest<GetByIdProductImageQueryResponse>
    {
        public string Id { get; set; }
    }
}
