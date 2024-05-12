using ETradeAPI.Application.Consts;
using ETradeAPI.Application.CustomAttributes;
using ETradeAPI.Application.Enums;
using ETradeAPI.Application.Features.Command.Product.CreateProduct;
using ETradeAPI.Application.Features.Command.ProductVariant.CreateProductVariant;
using ETradeAPI.Application.Features.Queries.Product.GetAllProduct;
using ETradeAPI.Application.Features.Queries.ProductVariant.GetAllProductVariant;
using ETradeAPI.Application.Repositories;
using ETradeAPI.Application.Services;
using ETradeAPI.Persistence.Repositories;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETradeAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Admin")]
    public class ProductVariantsController : ControllerBase
    {
        readonly private IProductVariantReadRepository _productVariantReadRepository;
        readonly private IProductVariantWriteRepository _productVariantWriteRepository;
        readonly IMediator _mediator;

        public ProductVariantsController(IProductVariantReadRepository productVariantReadRepository,
               IProductVariantWriteRepository productVariantWriteRepository, IMediator mediator)
        {
            _productVariantReadRepository = productVariantReadRepository;
            _productVariantWriteRepository = productVariantWriteRepository;
           
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetAllProductVariantQueryRequest getAllProductVariantQueryRequest)
        {
            GetAllProductVariantQueryResponse response = await _mediator.Send(getAllProductVariantQueryRequest);
            return Ok(response);
        }
        [HttpPost]
        [AuthorizeDefinition(Menu = "Create Product Variant", ActionType = ActionType.Writing, Definition = "Create Product Variant")]
        public async Task<IActionResult> Post(CreateProductVariantCommandRequest createProductVariantCommandRequest)
        {
            CreateProductVariantCommandResponse response = await _mediator.Send(createProductVariantCommandRequest);
            return Ok(response);
        }

    }
}
