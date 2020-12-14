using System;
using System.Net;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SampleProject.Application.Customers;
using SampleProject.Application.Customers.DeleteCustomer;
using SampleProject.Application.Customers.GetCustomerDetails;
using SampleProject.Application.Customers.RegisterCustomer;

namespace SampleProject.API.Customers
{
    [Route("api/customers")]
    [ApiController]
    public class CustomersController : Controller
    {
        private readonly IMediator _mediator;

        public CustomersController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        /// <summary>
        /// Register customer.
        /// </summary>
        [Route("")]
        [HttpPost]
        [ProducesResponseType(typeof(CustomerDto), (int)HttpStatusCode.Created)]
        public async Task<IActionResult> RegisterCustomer([FromBody] RegisterCustomerRequest request)
        {
            var customer = await _mediator.Send(new RegisterCustomerCommand(request.Age, request.Name));

            return Created(string.Empty, customer);
        }

        /// <summary>
        /// Register customer.
        /// </summary>
        [Route("")]
        [HttpPut]
        [ProducesResponseType(typeof(CustomerDto), (int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> UpdateCustomer([FromBody] UpdateCustomerRequest request)
        {
            await _mediator.Send(new UpdateCustomerCommand(request.Age, request.Name, request.Id));

            return NoContent();
        }

        /// <summary>
        /// Delete customer.
        /// </summary>
        [Route("{customerId}")]
        [HttpDelete]
        [ProducesResponseType(typeof(CustomerDto), (int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> DeleteCustomer([FromRoute] Guid customerId)
        {
            await _mediator.Send(new DeleteCustomerCommand(customerId));
            return NoContent();
        }

        /// <summary>
        /// Get customer details.
        /// </summary>
        /// <param name="customerId">Order ID.</param>
        [Route("{customerId}")]
        [HttpGet]
        [ProducesResponseType(typeof(CustomerDto), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetCustomerOrderDetails(
            [FromRoute] Guid customerId)
        {
            var customer = await _mediator.Send(new GetCustomerDetailsQuery(customerId));

            return Ok(customer);
        }

    }
}
