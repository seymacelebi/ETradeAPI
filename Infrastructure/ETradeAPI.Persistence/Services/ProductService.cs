using ETradeAPI.Application.Abstractions.Services;
using ETradeAPI.Application.DTOs.Product;
using ETradeAPI.Application.Repositories;
using ETradeAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeAPI.Persistence.Services
{
    public class ProductService : IProductService
    {
        readonly IProductReadRepository _productReadRepository;
        readonly IProductWriteRepository _productWriteRepository;
        readonly ICategoryReadRepository _categoryReadRepository;
        public ProductService(IProductReadRepository productReadRepository, IProductWriteRepository productWriteRepository, ICategoryReadRepository categoryReadRepository)
        {
            _productReadRepository= productReadRepository;
            _productWriteRepository= productWriteRepository;
            _categoryReadRepository= categoryReadRepository;
        }


        public async Task CreateProductAsync(CreateProduct createProduct)
        {
            var category = await _categoryReadRepository.GetByIdAsync(createProduct.CategoryId);

            if (category == null)
            {
                throw new Exception($"ID'si {createProduct.CategoryId} olan kategori bulunamadı.");
            }

            await _productWriteRepository.AddAsync(new Product
            {
                CategoryId = category.Id,
                //Category = category,
                Name = createProduct.Name,
                Price = createProduct.Price,
                Stock = createProduct.Stock,
                Description = createProduct.Description,
            });

            await _productWriteRepository.SaveAsync();
        }
    }
}
