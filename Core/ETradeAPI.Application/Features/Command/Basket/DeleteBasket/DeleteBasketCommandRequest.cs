using ETradeAPI.Application.Features.Command.Basket.CreateBasket;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeAPI.Application.Features.Command.Basket.DeleteBasket
{
    public class DeleteBasketCommandRequest : IRequest<DeleteBasketCommandResponse>
    {
        public string BasketItemId { get; set; }
    }
}
