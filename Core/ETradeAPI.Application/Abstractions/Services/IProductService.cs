using ETradeAPI.Application.DTOs.Order;
using ETradeAPI.Application.DTOs.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeAPI.Application.Abstractions.Services
{
    public interface IProductService
    {
        Task CreateProductAsync(CreateProduct createProduct);

    }
}
