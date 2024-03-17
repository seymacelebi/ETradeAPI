using ETradeAPI.Application.Abstractions.Services;
using ETradeAPI.Application.DTOs.Product;
using ETradeAPI.Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ETradeAPI.Domain.Entities;

namespace ETradeAPI.Application.Features.Command.Product.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommandRequest, CreateProductCommandResponse>
    {
        readonly IProductWriteRepository _productWriteRepository;
        readonly IProductReadRepository _productReadRepository;
        readonly IProductService _productService;
        readonly ICategoryReadRepository _categoryReadRepository;
        public CreateProductCommandHandler(IProductReadRepository productReadRepository, IProductWriteRepository productWriteRepository, IProductService productService, ICategoryReadRepository categoryReadRepository)
        {
            _productWriteRepository = productWriteRepository;
            _productService = productService;
            _categoryReadRepository = categoryReadRepository;
            _productReadRepository = productReadRepository;


        }
        public async Task<CreateProductCommandResponse> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
        {
            var category = await _categoryReadRepository.GetByIdAsync(request.CategoryId);

            if (category == null)
            {
                throw new Exception($"ID'si {request.CategoryId} olan kategori bulunamadı.");
            }

            await _productWriteRepository.AddAsync(new Domain.Entities.Product
            {
                CategoryId = category.Id,
                Name = request.Name,
                Price = request.Price,
                Stock = request.Stock,
                Description = request.Description,
                ImagePath = request.ImagePath
            });

            await _productWriteRepository.SaveAsync();

          
            var response = new CreateProductCommandResponse
            {
                // Set properties of the response object if needed.
            };

            return response; // or return null; depending on your use case.
        }



        //public async Task<CreateProductCommandResponse> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
        //{
        //    //await  _productWriteRepository.AddAsync(new()
        //    //  {
        //    //      CategoryId= request.CategoryId,
        //    //      Name = request.Name,
        //    //      Price = request.Price,
        //    //      Stock = request.Stock,
        //    //      Description = request.Description,
        //    //  });
        //    //  await _productWriteRepository.SaveAsync();
        //    //  return new();
        //    //await _productService.CreateProductAsync(new()
        //    //{
        //    //    Name= request.Name,
        //    //    Description= request.Description,
        //    //    Price= request.Price,
        //    //    Stock= request.Stock,
        //    //    CategoryId= request.CategoryId
        //    //});
        //    //return new();
        //    var category = await _categoryReadRepository.GetByIdAsync(request.CategoryId);

        //    if (category == null)
        //    {
        //        throw new Exception($"ID'si {request.CategoryId} olan kategori bulunamadı.");
        //    }

        //    await _productWriteRepository.AddAsync(new Product
        //    {
        //        CategoryId = category.Id,
        //        //Category = category,
        //        Name = request.Name,
        //        Price = request.Price,
        //        Stock = request.Stock,
        //        Description = request.Description,
        //    });

        //    await _productWriteRepository.SaveAsync();
        //}
    }
}
