using ETradeAPI.Application.Abstractions.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeAPI.Application.Features.Command.Basket.UpdateBasket
{
    public class UpdateBasketCommandHandler : IRequestHandler<UpdateBasketCommandRequest, UpdateBasketCommandResponse>
    {
        readonly IBasketService _basketService;

        public UpdateBasketCommandHandler(IBasketService basketService)
        {
            _basketService = basketService;
        }

        public async Task<UpdateBasketCommandResponse> Handle(UpdateBasketCommandRequest request, CancellationToken cancellationToken)
        {
            await _basketService.UpdateQuantityAsync(new()
            {
                BasketItemId= request.BasketItemId, 
                Quantity= request.Quantity,
            });
            return new();
        }
    }
}
