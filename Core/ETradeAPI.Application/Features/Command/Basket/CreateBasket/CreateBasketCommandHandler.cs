using ETradeAPI.Application.Abstractions.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeAPI.Application.Features.Command.Basket.CreateBasket
{
    public class CreateBasketCommandHandler : IRequestHandler<CreateBasketCommandRequest, CreateBasketCommandResponse>
    {
        readonly IBasketService _basketService;

        public CreateBasketCommandHandler(IBasketService basketService)
        {
            _basketService = basketService;
        }

        public async Task<CreateBasketCommandResponse> Handle(CreateBasketCommandRequest request, CancellationToken cancellationToken)
        {
          await  _basketService.AddItemToBasketAsync(new()
            {
                ProductId= request.ProductId,
                Quantity= request.Quantity,
            });
            return new();
        }
    }
}
