using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeAPI.Application.Features.Queries.Category.GetAllCategory
{
    public class GetAllCategoryQueryResponse
    {
        public int TotalCount { get; set; }

        public List<Domain.Entities.Category> CategoryData { get; set; } // Change property type to List<Category>
    }
}
