using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiDemo.DataAccess;
using WebApiDemo.Entities;

namespace WebApiDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        private IProductDal _productDal;

        public ProductsController(IProductDal productDal)
        {
            _productDal = productDal;
        }

        [HttpGet("")]
        public IActionResult Get()
        {
            var products = _productDal.GetList();
            return Ok(products);
        }
        [HttpGet("{productId}")]
        public IActionResult Get(int productId)
        {
            try
            {
                var product = _productDal.Get(p => p.ProductId == productId);
                if (product == null)
                {
                    return NotFound($"There is no product with this ID : {productId}");
                }
                return Ok(product);
            }
            catch (Exception ex) { }
            return BadRequest();
        }

        [HttpPost("")]
        public IActionResult Post([FromForm]Product product)
        {
            try
            {
                _productDal.Add(product);
                return new StatusCodeResult(201);
            }
            catch (Exception ex) { }
            return BadRequest();
        }

        [HttpPut("")]
        public IActionResult Put(Product product)
        {
            try
            {
                _productDal.Update(product);
                return Ok();
            }
            catch (Exception ex) { }
            return BadRequest();
        }


        [HttpDelete("{productId}")]
        public IActionResult Delete(int productId)
        {
            try
            {
                _productDal.Delete(new Product { ProductId = productId });
                return NoContent();
            }
            catch { }
            return BadRequest();
        }

        [HttpGet("GetProductWithDetails")]
        public IActionResult GetProductsWithDetails()
        {
            try
            {
                var result = _productDal.GetProductWithDetails();
                return Ok(result);  
            }
            catch { }
            return BadRequest();
        }

    }
}
