using Microsoft.AspNetCore.Http;
using StoreApi.Models.ApiModels.Request;
using Microsoft.AspNetCore.Mvc;

namespace StoreApi.Controllers
{
    [ApiController]
    public class ProductApiController : ControllerBase
    {

        [Route("CreateProduct")]
        [HttpPost]
        public IActionResult CreateProduct([FromBody] Product product)
        {
            try
            {
                string sku = product.SKU;
                return Ok();
            }
            catch (ArgumentException e)
            {
                return StatusCode(400, e.Message);
            }
        }
    }
}
