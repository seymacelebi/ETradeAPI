using ETradeAPI.Application.Features.Command.Product.CreateProduct;
using ETradeAPI.Application.Features.Queries.Product.GetAllProduct;
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
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            return Ok( await _productReadRepository.GetByIdAsync(id, false));
        }
        [HttpPost]
        public async Task<IActionResult> Post(CreateProductCommandRequest createProductCommandRequest)
        {
          CreateProductCommandRequest response =  await _mediator.Send(createProductCommandRequest);
            return Ok(response);
        }
        [HttpPut]
        public async Task<IActionResult> Put(VM_Update_Product model)
        {
            Product product = await _productReadRepository.GetByIdAsync(model.Id);
            product.Stock = model.Stock;    
            product.Price = model.Price;
            product.Name = model.Name;
           await  _productWriteRepository.SaveAsync();
            return Ok();   

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _productWriteRepository.RemoveAsync(id);
            await _productWriteRepository.SaveAsync();
            return Ok();
        }
        //[HttpPost("[action]")]
        //public async Task<IActionResult> Upload()
        //{
        //    string uploadPath = Path.Combine(_webHostEnvironment.WebRootPath, "resource/product-images");
        //    if (!Directory.Exists(uploadPath))
        //    {
        //        Directory.CreateDirectory(uploadPath);
        //    }
        //    Random r = new();
        //    foreach(IFormFile file in Request.Form.Files)
        //    {
        //        string fullPath = Path.Combine(uploadPath, $"{r.NextDouble()}{Path.GetExtension(file.FileName)}");

        //        using FileStream fileStream = new(fullPath, FileMode.Create, FileAccess.Write, FileShare.None, 1024*1024, useAsync:false );
        //       await file.CopyToAsync(fileStream);
        //        await fileStream.FlushAsync();

        //    }
        //    return Ok();
        //}
        [HttpPost("[action]")]
        public async Task<IActionResult> Upload()
        {
            _fileService.UploadFileAsync("resource//product-images", Request.Form.Files);
            return Ok();    
        }
    }
}
