using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreApi.BLL;
using StoreApi.Models.ApiModels.Request;
using StoreApi.Models.ApiModels.Response;
using Product = StoreApi.Models.ApiModels.Request.ProductCreate;
using ProductUpdate = StoreApi.Models.ApiModels.Request.ProductUpdate;

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

        [Route("CreateProduct")]
        [HttpPost]
        public IActionResult CreateProduct([FromBody] ProductCreate product)
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

        [Route("UpdateProduct")]
        [HttpPut]
        public IActionResult UpdateProduct([FromBody] ProductUpdate product,[FromQuery] int productId)
        {
            try
            {
                var productCreated = _productActions.UpdateProduct(product, productId);
                return Ok(productCreated);
            }
            catch (Exception e)
            {
                Error error = new Error()
                {
                    EndPoint = "UpdateProduct",
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

        [Route("DeleteProduct")]
        [HttpDelete]
        public IActionResult DeleteProduct([FromQuery] int productId)
        {
            try
            {
                var deleted = _productActions.DeleteProduct(productId);
                if(deleted)
                return Ok(new { Message = "El producto se borro correctamente" , Status=deleted });

                return Ok(new { Message = "El producto no se borro correctamente" , Status=deleted });
            }
            catch (Exception e)
            {
                Error error = new Error()
                {
                    EndPoint = "UpdateProduct",
                    ErrorCode = 500,
                    Message = e.Message,
                    Reference = Guid.NewGuid().ToString(),
                    Body = null,
                    QueryParameters = Newtonsoft.Json.JsonConvert.SerializeObject(productId),
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
