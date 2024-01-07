using ETradeAPI.Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeAPI.Application.Features.Queries.Category.GetAllCategory
{
    public class GetAllCategoryQueryHandler : IRequestHandler<GetAllCategoryQueryRequest, GetAllCategoryQueryResponse>
    {
        readonly ICategoryReadRepository _categoryReadRepository;

        public GetAllCategoryQueryHandler(ICategoryReadRepository categoryReadRepository)
        {
            _categoryReadRepository = categoryReadRepository;
        }

        //public async Task<GetAllCategoryQueryResponse> Handle(GetAllCategoryQueryRequest request, CancellationToken cancellationToken)
        //{
        //    var categories = _categoryReadRepository.GetAll(false);

        //    // Assuming you have a method in _categoryReadRepository to get category names
        //    var categoryNames = categories.Select(c => c.Name).ToList();

        //    var response = new GetAllCategoryQueryResponse
        //    {
        //        TotalCount = categoryNames.Count,
        //        CategoryName = categoryNames
        //    };

        //    return response; // Return the response directly, no need to create a new instance
        //}
        public async Task<GetAllCategoryQueryResponse> Handle(GetAllCategoryQueryRequest request, CancellationToken cancellationToken)
        {
            var categories = _categoryReadRepository.GetAll(false);

            var categoryData = categories.Select(c => new Domain.Entities.Category
            {
                Id = c.Id,
                Name = c.Name,
              
            }).ToList();

            var response = new GetAllCategoryQueryResponse
            {
                TotalCount = categoryData.Count,
                CategoryData = categoryData
            };

            return response;
        }
    }
}
