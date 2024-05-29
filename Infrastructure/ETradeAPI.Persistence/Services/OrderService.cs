using ETradeAPI.Application.Abstractions.Services;
using ETradeAPI.Application.DTOs.Order;
using ETradeAPI.Application.Repositories;
using ETradeAPI.Domain.Entities;
using ETradeAPI.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeAPI.Persistence.Services
{
    public class OrderService : IOrderService
    {
        readonly IOrderWriteRepository _orderWriteRepository;
        readonly IOrderReadRepository _orderReadRepository;

        public OrderService(IOrderWriteRepository orderWriteRepository, IOrderReadRepository orderReadRepository)
        {
            _orderWriteRepository = orderWriteRepository;
            _orderReadRepository = orderReadRepository;

        }

        public Task<(bool, CompletedOrderDTO)> CompleteOrderAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task CreateOrderAsync(CreateOrder createOrder)
        {
            throw new NotImplementedException();
        }

        public Task<ListOrder> GetAllOrdersAsync(int page, int size)
        {
            throw new NotImplementedException();
        }

        public Task<SingleOrder> GetOrderByIdAsync(string id)
        {
            throw new NotImplementedException();
        }
    }

}