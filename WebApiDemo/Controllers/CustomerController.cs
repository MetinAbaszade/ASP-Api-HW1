using Microsoft.AspNetCore.Mvc;
using WebApiDemo.DataAccess;
using WebApiDemo.Entities;

namespace WebApiDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private ICustomerDal customerDal;

        public CustomerController(ICustomerDal customerDal)
        {
            this.customerDal = customerDal;
        }

        // GET: api/<CustomerController>
        [HttpGet]
        public IActionResult Get()
        {
            var customers = customerDal.GetList();
            return Ok(customers);
        }

        // GET api/<CustomerController>/5
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            try
            {
                var customer = customerDal.Get(c => c.CustomerID == id);
                if (customer == null)
                {
                    return NotFound($"There is no customer with this ID : {id}");
                }
                return Ok(customer);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}/Orders")]
        public IActionResult GetCustomerOrders(string id)
        {
            try
            {
                var Orders = customerDal.GetCustomerOrders(id);
                return Ok(Orders);
            }
            catch (Exception ex)
            {
                return(BadRequest(ex.Message));
            }

        }

        [HttpGet("Customers/Alphabetic/{isAlphabetic}")]
        public IActionResult GetCustomerAlphabetic(bool isAlphabetic)
        {
            try
            {
                var Customers = customerDal.GetList().OrderBy(c => c.CompanyName);
                return Ok(Customers);
            }
            catch (Exception ex)
            {
                return (BadRequest(ex.Message));
            }

        }

        // POST api/<CustomerController>
        [HttpPost]
        public IActionResult Post([FromBody] Customer customer)
        {
            try
            {
                customerDal.Add(customer);
                return new StatusCodeResult(201);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<CustomerController>/5
        [HttpPut("")]
        public IActionResult Put([FromBody] Customer customer)
        {
            try
            {
                customerDal.Update(customer);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<CustomerController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            try
            {
                customerDal.Delete(new Customer { CustomerID = id });
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
