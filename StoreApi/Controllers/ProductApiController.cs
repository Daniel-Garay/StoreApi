using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreApi.BLL;
using StoreApi.Models.ApiModels.Request;
using StoreApi.Models.ApiModels.Response;
using Product = StoreApi.Models.ApiModels.Request.Product;

namespace StoreApi.Controllers
{
    [ApiController]
    public class ProductApiController : ControllerBase
    {

        private readonly IProductActions _productActions;
        private readonly ILoggerActions _loggerActions;


        public ProductApiController(IProductActions productActions, ILoggerActions loggerActions)
        {
            _productActions = productActions ?? throw new ArgumentNullException(nameof(productActions));
            _loggerActions = loggerActions ?? throw new ArgumentNullException(nameof(loggerActions));
        }

        [Route("CreateProduct")]
        [HttpPost]
        public IActionResult CreateProduct([FromBody] Product product)
        {
            try
            {
                var productCreated = _productActions.CreateProduct(product);
                return Ok(productCreated);
            }
            catch (Exception e)
            {
                Error error = new Error()
                {
                    EndPoint = "CreateProduct",
                    ErrorCode = 500,
                    Message = e.Message,
                    Reference = Guid.NewGuid().ToString(),
                    Body = Newtonsoft.Json.JsonConvert.SerializeObject(product),
                    QueryParameters = null,
                };
                _loggerActions.CreateLogger(error);
                return StatusCode(500, new
                {
                    error.ErrorCode,
                    error.Message,
                    error.Reference
                });
            }
        }

        [Route("GetCatalog")]
        [HttpGet]
        public IActionResult GetCatalog([FromQuery] FilterCatalog filterCatalog)
        {
            try
            {
                List<StoreApi.Models.ApiModels.Response.Product> ProductList = _productActions.GetCatalog(filterCatalog);
                return Ok(ProductList);
            }
            catch (Exception e)
            {
                Error error = new Error()
                {
                    EndPoint = "GetCatalog",
                    ErrorCode = 500,
                    Message = e.Message,
                    Reference = Guid.NewGuid().ToString(),
                    Body = null,
                    QueryParameters = Newtonsoft.Json.JsonConvert.SerializeObject(filterCatalog),
                };
                _loggerActions.CreateLogger(error);
                return StatusCode(500, new
                {
                    error.ErrorCode,
                    error.Message,
                    error.Reference
                });
            }
        }
    }
}
