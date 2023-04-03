using AutoMapper;
using Contracts;
using Entities.DTOs;
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
        private readonly IMapper _mapper;
        public CustomersController(IRepositoryWrapper repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
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

                var customersResult = _mapper.Map<IEnumerable<CustomerDto>>(customers);

                return Ok(customersResult);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}", Name = "CustomerById")]
        public IActionResult GetCustomerById(string id)
        {
            try
            {
                var customer = _repository.Customer.GetCustomerById(id);
                if (customer == null)
                    return NotFound();
                else
                {
                    var customerResult = _mapper.Map<CustomerDto>(customer);
                    return Ok(customerResult);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
