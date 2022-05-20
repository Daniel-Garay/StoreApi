using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreApi.BLL;
using StoreApi.Models.ApiModels.Request;

namespace StoreApi.Controllers
{
    [ApiController]
    public class ProductApiController : ControllerBase
    {

        private readonly IProductActions _productActions;

        public ProductApiController(IProductActions productActions)
        {
            _productActions = productActions ?? throw new ArgumentNullException(nameof(productActions));
        }

        [Route("CreateProduct")]
        [HttpPost]
        public IActionResult CreateProduct([FromBody] Product product)
        {
            try
            {
                string sku = product.Name;
                return Ok();
            }
            catch (ArgumentException e)
            {
                return StatusCode(400, e.Message);
            }
        }

        [Route("GetCatalog")]
        [HttpGet]
        public async Task<IActionResult> GetCatalog(string? description, string? sku, string? category, int from = 0, int maxPageSize = 50)
        {
            try
            {
                List<StoreApi.Models.ApiModels.Request.Product> ProductList = await _productActions.GetCatalog();
                return Ok(ProductList);
            }
            catch (ArgumentException e)
            {
                return StatusCode(400, e.Message);
            }
        }
    }
}
