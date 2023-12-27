using ETradeAPI.Application.Abstractions.Services;
using ETradeAPI.Application.ViewModels.Baskets;
using ETradeAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeAPI.Persistence.Services
{
    public class BasketService : IBasketService
    {
        public Task AddItemToBasketAsync(VM_Create_BasketItem basketItem)
        {
            throw new NotImplementedException();

        }

        public Task<List<BasketItem>> GetBasketItemsAsync()
        {
            throw new NotImplementedException();
        }

        public Task RemoveBasketItemAsync(string basketItemId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateQuantityAsync(VM_Update_BasketItem basketItem)
        {
            throw new NotImplementedException();
        }
    }
}
