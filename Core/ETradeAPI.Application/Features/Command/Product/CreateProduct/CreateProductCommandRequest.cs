using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeAPI.Application.Features.Command.Product.CreateProduct
{
    public class CreateProductCommandRequest : IRequest<CreateProductCommandResponse >
    {
        public string Name { get; set; }
        public int Stock { get; set; }
        public float Price { get; set; }

        public static implicit operator CreateProductCommandRequest(CreateProductCommandResponse v)
        {
            throw new NotImplementedException();
        }
    }
}
