using Contracts;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly IRepositoryWrapper _repository;
        public CustomersController(IRepositoryWrapper repository)
        {
            _repository = repository;
        }
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Customer>), StatusCodes.Status200OK)]
        public IActionResult GetCustomers([FromQuery] CustomerParameters customerParameters)
        {
            if (!customerParameters.ValidNameRange)
            {
                return BadRequest("Max customerId cannot be less than min customerId");
            }

            try
            {
                var customers = _repository.Customer.GetAllCustomers(customerParameters);

                var metadata = new
                {
                    customers.TotalCount,
                    customers.PageSize,
                    customers.CurrentPage,
                    customers.TotalPages,
                    customers.HasNext,
                    customers.HasPrevious
                };

                Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));

                return Ok(customers);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
