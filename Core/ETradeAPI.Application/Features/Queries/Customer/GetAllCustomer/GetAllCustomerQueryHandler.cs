using ETradeAPI.Application.Features.Queries.Category.GetAllCategory;
using ETradeAPI.Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeAPI.Application.Features.Queries.Customer.GetAllCustomer
{
    public class GetAllCustomerQueryHandler : IRequestHandler<GetAllCustomerQueryRequest, GetAllCustomerQueryResponse>
    {
        readonly ICustomerReadRepository _customerReadRepository;

        public GetAllCustomerQueryHandler(ICustomerReadRepository customerReadRepository)
        {
            _customerReadRepository = customerReadRepository;
        }

        public  async Task<GetAllCustomerQueryResponse> Handle(GetAllCustomerQueryRequest request, CancellationToken cancellationToken)
        {
            var query = _customerReadRepository.GetAll(false);

            var totalCount = query.Count();

            var data = query
                .Skip(request.Page * request.Size)
                .Take(request.Size)
                .Select(p => new
                {
                    p.Id,
                    FullName = p.FirstName + " " + p.LastName,
                    p.Phone,
                    p.Email
                })
                .ToList();

            return new GetAllCustomerQueryResponse
            {

                data = data,
                TotalCount = data.Count,
            };
        }
    }
}
