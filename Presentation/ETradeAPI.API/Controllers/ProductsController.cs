using ETradeAPI.Application.Features.Command.Product.CreateProduct;
using ETradeAPI.Application.Features.Command.Product.DeleteProduct;
using ETradeAPI.Application.Features.Command.Product.UpdateProduct;
using ETradeAPI.Application.Features.Queries.Product.GetAllProduct;
using ETradeAPI.Application.Features.Queries.Product.GetByIdProduct;
using ETradeAPI.Application.Repositories;
using ETradeAPI.Application.RequestParameters;
using ETradeAPI.Application.Services;
using ETradeAPI.Application.ViewModels.Products;
using ETradeAPI.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ETradeAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        readonly private IProductWriteRepository _productWriteRepository;
        readonly private IProductReadRepository _productReadRepository;
        readonly private IFileService _fileService;
        private IWebHostEnvironment _webHostEnvironment;

        readonly IMediator _mediator;
        public ProductsController(IProductReadRepository productReadRepository,
                IProductWriteRepository productWriteRepository, IWebHostEnvironment webHostEnvironment, IFileService fileService, IMediator mediator)
        {
            _productReadRepository = productReadRepository;
            _productWriteRepository = productWriteRepository;
            _webHostEnvironment = webHostEnvironment;
            _fileService = fileService;
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetAllProductQueryRequest getAllProductQueryRequest)
        {
         GetAllProductQueryResponse response =  await _mediator.Send(getAllProductQueryRequest);
            return Ok(response);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> Get([FromRoute] GetByIdProductQueryRequest getByIdProductQueryRequest)
        {
            GetByIdProductQueryResponse response = await _mediator.Send(getByIdProductQueryRequest);
            return Ok(response);
        }
        [HttpPost]
        public async Task<IActionResult> Post(CreateProductCommandRequest createProductCommandRequest)
        {
            CreateProductCommandResponse response = await _mediator.Send(createProductCommandRequest);
            return Ok(response);
        }
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdateProductCommandRequest updateProductCommandRequest)
        {
            UpdateProductCommandResponse response = await _mediator.Send(updateProductCommandRequest);
            return Ok(response);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteProductCommandRequest deleteProductCommandRequest)
        {
            DeleteProductCommandResponse response = await _mediator.Send(deleteProductCommandRequest);
            return Ok(response);
        }
      
        //[HttpDelete("[action]/{Id}")]
        //public async Task<IActionResult> DeleteProductImage([FromQuery, FromRoute]DeleteProductImageCommandRequest  deleteProductImageCommandRequest)
        //{

        //}

        //[HttpPost("[action]")]
        //public async Task<IActionResult> Upload()
        //{
        //    _fileService.UploadFileAsync("resource//product-images", Request.Form.Files);
        //    return Ok();    
        //}
    }
}
