using ETradeAPI.Application.Abstractions.Hubs;
using ETradeAPI.Application.Abstractions.Services;
using ETradeAPI.Application.Repositories;
using ETradeAPI.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeAPI.Application.Features.Command.Order.CreateOrder
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommandRequest, CreateOrderCommandResponse>
    {
        readonly IOrderService _orderService;
        readonly IBasketService _basketService;
        readonly IOrderHubService _orderHubService;
        readonly ICustomerReadRepository _customerReadRepository;

        public CreateOrderCommandHandler(IOrderService orderService, IBasketService basketService, IOrderHubService orderHubService, ICustomerReadRepository customerReadRepository)
        {
            _orderService = orderService;
            _basketService = basketService;
            _orderHubService = orderHubService;
            _customerReadRepository = customerReadRepository;
        }

        public async Task<CreateOrderCommandResponse> Handle(CreateOrderCommandRequest request, CancellationToken cancellationToken)
        {
            var customerIdString = request.CustomerId?.ToString();

            var customer = await _customerReadRepository.GetByIdAsync(customerIdString);

            if (customer == null)
            {
                throw new Exception($"ID'si {request.CustomerId} olan kategori bulunamadı.");
            }

            await _orderService.CreateOrderAsync(new()
            {
                CustomerId = customerIdString,
                Address = request.Address,
                Description = request.Description,
                TotalAmount = request.TotalAmount,
                PaymentMethod = request.PaymentMethod,
                ShippingMethod = request.ShippingMethod,
                ShippingTrackingNumber = request.ShippingTrackingNumber,
                BasketId = _basketService.GetUserActiveBasket?.Id.ToString()
            });

            await _orderHubService.OrderAddedMessageAsync("Heyy, yeni bir sipariş geldi! :) ");

            return new();
        }
    }
}
