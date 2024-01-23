using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeAPI.Application.Features.Queries.Category.GetAllCategory
{
    public class GetAllCategoryQueryResponse
    {
        
        //public List<Domain.Entities.Category> CategoryData { get; set; } 
        public object data { get; set; }
        public int TotalCount { get; set; }

    }
}
