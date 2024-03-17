using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ETradeAPI.Application.Features.Command.Customer.CreateCustomer;
using ETradeAPI.Application.Features.Queries.Category.GetAllCategory;
using ETradeAPI.Application.Features.Queries.Customer.GetAllCustomer;

namespace ETradeAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        readonly IMediator _mediator;

        public CustomersController(IMediator mediator)
        {
           _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetAllCustomerQueryRequest getAllCustomerQueryRequest)
        {
            GetAllCustomerQueryResponse response = await _mediator.Send(getAllCustomerQueryRequest);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateCustomerCommandRequest createCustomerCommandRequest)
        {
            CreateCustomerCommandResponse response = await _mediator.Send(createCustomerCommandRequest);
            return Ok(response);
        }
    }
}
