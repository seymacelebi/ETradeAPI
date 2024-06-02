using ETradeAPI.Application.Features.Command.ProductImage.DeleteProductımage;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeAPI.Application.Features.Command.ProductImage.UpdateProductImage
{
    public class UpdateProductImageCommandRequest : IRequest<UpdateProductImageCommandResponse>
    {
        public int ProductId { get; set; }
        public string NewImagePath { get; set; } // Rename it to NewImagePath to indicate it's for updating
    }
}
