using ETradeAPI.Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeAPI.Application.Features.Command.Customer.CreateCustomer
{
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommandRequest, CreateCustomerCommandResponse>
    {
        readonly ICustomerWriteRepository _customerWriteRepository;

        public CreateCustomerCommandHandler(ICustomerWriteRepository customerWriteRepository)
        {
            _customerWriteRepository = customerWriteRepository;
        }

        public async Task<CreateCustomerCommandResponse> Handle(CreateCustomerCommandRequest request, CancellationToken cancellationToken)
        {
            await _customerWriteRepository.AddAsync(new()
            {
                FirstName= request.FirstName,
                LastName= request.LastName, 
                Email= request.Email,
                Phone= request.Phone,
                Adress= request.Adress,
            });
            await _customerWriteRepository.SaveAsync();
            return new();
        }
    }
}
