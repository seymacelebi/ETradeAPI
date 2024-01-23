using ETradeAPI.Application.Features.Queries.Category.GetAllCategory;
using ETradeAPI.Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeAPI.Application.Features.Queries.Category.GetByIdCategory
{
    public class GetByIdCategoryQueryHandler : IRequestHandler<GetByIdCategoryQueryRequest, GetByIdCategoryQueryResponse>
    {
        readonly ICategoryReadRepository _categoryReadRepository;

        public GetByIdCategoryQueryHandler(ICategoryReadRepository categoryReadRepository)
        {
            _categoryReadRepository = categoryReadRepository;
        }

       
        public async Task<GetByIdCategoryQueryResponse> Handle(GetByIdCategoryQueryRequest request, CancellationToken cancellationToken)
        {
            Domain.Entities.Category category = await _categoryReadRepository.GetByIdAsync(request.Id, false);

            if (category == null)
            {
                // Handle the case where the category is not found, return appropriate response or throw an exception.
                // For example:
                // throw new NotFoundException($"Category with Id {request.Id} not found");
            }

            GetByIdCategoryQueryResponse response = new GetByIdCategoryQueryResponse
            {
                data = new
                {
                    Id = category.Id,
                    Name = category.Name
                }
            };

            return response;
        }


    }
}
