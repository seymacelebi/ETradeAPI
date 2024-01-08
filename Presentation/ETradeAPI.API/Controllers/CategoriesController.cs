using ETradeAPI.Application.Features.Command.Category;
using ETradeAPI.Application.Features.Command.Category.CreateCategory;
using ETradeAPI.Application.Features.Command.Product.CreateProduct;
using ETradeAPI.Application.Features.Queries.Category.GetAllCategory;
using ETradeAPI.Application.Features.Queries.Category.GetByIdCategory;
using ETradeAPI.Application.Features.Queries.Product.GetAllProduct;
using ETradeAPI.Application.Features.Queries.Product.GetByIdProduct;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETradeAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Admin")]
    public class CategoriesController : ControllerBase
    {
        readonly IMediator _mediator;

        public CategoriesController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetAllCategoryQueryRequest getAllCategoryQueryRequest)
        {
            GetAllCategoryQueryResponse response = await _mediator.Send(getAllCategoryQueryRequest);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateCategoryCommandRequest createCategoryCommandRequest)
        {
            CreateCategoryCommandResponse response = await _mediator.Send(createCategoryCommandRequest);
            return Ok(response);
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> Get([FromRoute] GetByIdCategoryQueryRequest getByIdCategoryQueryRequest)
        {
            GetByIdCategoryQueryResponse response = await _mediator.Send(getByIdCategoryQueryRequest);
            return Ok(response);
        }
    }
}
