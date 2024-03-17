using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeAPI.Application.Features.Queries.Customer.GetAllCustomer
{
    public class GetAllCustomerQueryResponse
    {
        public object data { get; set; }
        public int TotalCount { get; set; }
    }
}
