using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeAPI.Application.Features.Command.Product.CreateProduct;

public class CreateProductCommandRequest : IRequest<CreateProductCommandResponse>
{
    public string CategoryId { get; set; }
    public string Name { get; set; }
    public int Stock { get; set; }
    public float Price { get; set; }
    public string Description { get; set; }
    public List<string> ImagePath { get; set; } // ImagePath özelliğini ekleyin.

}
