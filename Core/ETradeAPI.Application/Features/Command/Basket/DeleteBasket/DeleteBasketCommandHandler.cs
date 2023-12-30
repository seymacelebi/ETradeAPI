using ETradeAPI.Application.Abstractions.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeAPI.Application.Features.Command.Basket.DeleteBasket;


public class DeleteBasketCommandHandler : IRequestHandler<DeleteBasketCommandRequest, DeleteBasketCommandResponse>
{
    readonly IBasketService _basketService;

    public DeleteBasketCommandHandler(IBasketService basketService)
    {
        _basketService = basketService;
    }

    public async Task<DeleteBasketCommandResponse> Handle(DeleteBasketCommandRequest request, CancellationToken cancellationToken)
    {
        await _basketService.DeleteBasketItemAsync(request.BasketItemId);
        return new();
    }
}
