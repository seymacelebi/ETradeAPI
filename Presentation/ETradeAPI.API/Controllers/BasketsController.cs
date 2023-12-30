using ETradeAPI.Application.Features.Command.Basket.CreateBasket;
using ETradeAPI.Application.Features.Command.Basket.DeleteBasket;
using ETradeAPI.Application.Features.Command.Basket.UpdateBasket;
using ETradeAPI.Application.Features.Queries.Basket.GetBasketItems;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETradeAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BasketsController : ControllerBase
    {
        readonly IMediator _mediator;

        public BasketsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetBasketItems([FromQuery]GetBasketItemsQueryRequest getBasketItemsQueryRequest)
        {
            List<GetBasketItemsQueryResponse> response = await _mediator.Send(getBasketItemsQueryRequest);
            return Ok(response);
        }
        [HttpPost]
        public async Task<IActionResult> AddItemToBasket(CreateBasketCommandRequest createBasketCommandRequest)
        {
            CreateBasketCommandResponse response  = await _mediator.Send(createBasketCommandRequest);
            return Ok(response);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateBasketItems(UpdateBasketCommandRequest updateBasketCommandRequest)
        {
            UpdateBasketCommandResponse response = await _mediator.Send(updateBasketCommandRequest);
            return Ok(response);
        }
        [HttpDelete("{BasketItemId}")]
        public async Task<IActionResult> RemoveBasketItem([FromRoute] DeleteBasketCommandRequest deleteBasketCommandRequest)
        {
            DeleteBasketCommandResponse response = await _mediator.Send(deleteBasketCommandRequest);
            return Ok(response);
        }
    }
}
