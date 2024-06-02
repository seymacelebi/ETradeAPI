using ETradeAPI.Application.Features.Command.Product.DeleteProduct;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeAPI.Application.Features.Command.ProductImage.DeleteProductımage
{
    public class DeleteProductImageCommandRequest : IRequest<DeleteProductImageCommandResponse>
    {
        public int ProductId { get; set; }
        public List<string> ImagePaths { get; set; }
    }
}
