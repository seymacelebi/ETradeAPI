using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeAPI.Application.Features.Queries.Customer.GetByIdCustomer
{
    public class GetByIdCustomerQueryHandler : IRequestHandler<GetByIdCustomerQueryRequest, GetByIdCustomerQueryResponse>
    {
        public Task<GetByIdCustomerQueryResponse> Handle(GetByIdCustomerQueryRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
