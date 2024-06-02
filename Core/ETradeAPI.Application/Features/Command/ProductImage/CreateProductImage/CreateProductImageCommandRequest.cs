using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeAPI.Application.Features.Command.ProductImage.CreateProductImage
{
    public class CreateProductImageCommandRequest : IRequest<CreateProductImageCommandResponse>
    {
        public int ProductId { get; set; }
        public List<string> ImagePaths { get; set; }

    }
}
