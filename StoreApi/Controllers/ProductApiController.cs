using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreApi.BLL;
using StoreApi.Models.ApiModels.Request;
using StoreApi.Models.ApiModels.Response;
using Swashbuckle.AspNetCore.Annotations;
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

        /// <summary>
        /// Método para obtener el catalogo
        /// </summary>
        /// <param name="filterCatalog"></param>
        /// <returns></returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /GetCatalog
        /// </remarks>
        /// <response code="200">Returna una lista de productos páginada</response>
        /// <response code="500">Ocurrio un error interno</response>
        [SwaggerResponse(200, "Lista de productos", typeof(StoreApi.Models.ApiModels.Response.Product[]))]
        [SwaggerResponse(500, "Error interno", typeof(Models.ApiModels.Response.Error))]
        [Route("GetCatalog")]
        [Produces("application/json")]
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
                Models.InternalUse.Error error = new Models.InternalUse.Error()
                {
                    EndPoint = "GetCatalog",
                    ErrorCode = 500,
                    Message = e.Message,
                    Reference = Guid.NewGuid().ToString(),
                    Body = null,
                    QueryParameters = Newtonsoft.Json.JsonConvert.SerializeObject(filterCatalog),
                };
                _loggerActions.CreateLogger(error);
                return StatusCode(500, new Models.ApiModels.Response.Error
                {
                    ErrorCode = error.ErrorCode,
                    Message = error.Message,
                    Reference = error.Reference
                });
            }
        }

        /// <summary>
        ///   Método para crear producto  
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /CreateProduct
        ///     {
        ///        "name": "iPhone negro create",
        ///        "description": "Celular iPhone negro más negro",
        ///        "category": "Apple"
        ///     }
        /// </remarks>
        /// <response code="200">Retorna que el producto se creo correctamente</response>
        /// <response code="500">Ocurrio un error interno</response>
        [SwaggerResponse(200, "Producto creado", typeof(StoreApi.Models.ApiModels.Response.Product))]
        [SwaggerResponse(500, "Error interno", typeof(Models.ApiModels.Response.Error))]
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
                Models.InternalUse.Error error = new Models.InternalUse.Error()
                {
                    EndPoint = "CreateProduct",
                    ErrorCode = 500,
                    Message = e.Message,
                    Reference = Guid.NewGuid().ToString(),
                    Body = Newtonsoft.Json.JsonConvert.SerializeObject(product),
                    QueryParameters = null,
                };
                _loggerActions.CreateLogger(error);
                return StatusCode(500, new Models.ApiModels.Response.Error
                {
                    ErrorCode = error.ErrorCode,
                    Message = error.Message,
                    Reference = error.Reference
                });
            }
        }


        /// <summary>
        ///  Método para actualizar producto    
        /// </summary>
        /// <param name="product"></param>
        /// <param name="productId"></param>
        /// <returns></returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     PUT /UpdateProduct
        ///     {
        ///        "name": "iPhone negro update",
        ///        "description": "Celular iPhone negro más negro",
        ///        "category": "Apple"
        ///     }
        /// </remarks>
        /// <response code="200">Retorna que el producto se actualizo correctamente</response>
        /// <response code="500">Ocurrio un error interno</response>
        [SwaggerResponse(200, "Producto actualizado", typeof(StoreApi.Models.ApiModels.Response.Product))]
        [SwaggerResponse(500, "Error interno", typeof(Models.ApiModels.Response.Error))]
        [Route("UpdateProduct")]
        [HttpPut]
        public IActionResult UpdateProduct([FromBody] ProductUpdate product, [FromQuery] int productId)
        {
            try
            {
                var productCreated = _productActions.UpdateProduct(product, productId);
                return Ok(productCreated);
            }
            catch (Exception e)
            {
                Models.InternalUse.Error error = new Models.InternalUse.Error()
                {
                    EndPoint = "UpdateProduct",
                    ErrorCode = 500,
                    Message = e.Message,
                    Reference = Guid.NewGuid().ToString(),
                    Body = Newtonsoft.Json.JsonConvert.SerializeObject(product),
                    QueryParameters = null,
                };
                _loggerActions.CreateLogger(error);
                return StatusCode(500, new Models.ApiModels.Response.Error
                {
                    ErrorCode = error.ErrorCode,
                    Message = error.Message,
                    Reference = error.Reference
                });
            }
        }


        /// <summary>
        ///  Método para borrar producto
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     DELETE /DeleteProduct
        /// </remarks>
        /// <response code="200">Retorna que el producto se borro correctamente</response>
        /// <response code="500">Ocurrio un error interno</response>
        [SwaggerResponse(200, "Producto borrado", typeof(StoreApi.Models.ApiModels.Response.ResultOperation))]
        [SwaggerResponse(500, "Error interno", typeof(Models.ApiModels.Response.Error))]
        [Route("DeleteProduct")]
        [HttpDelete]
        public IActionResult DeleteProduct([FromQuery] int productId)
        {
            try
            {
                var deleted = _productActions.DeleteProduct(productId);
                if (deleted)
                    return Ok(new ResultOperation { Message = "se borro correctamente", Status = deleted });

                return Ok(new { Message = "El producto no se borro correctamente", Status = deleted });
            }
            catch (Exception e)
            {
                Models.InternalUse.Error error = new Models.InternalUse.Error()
                {
                    EndPoint = "UpdateProduct",
                    ErrorCode = 500,
                    Message = e.Message,
                    Reference = Guid.NewGuid().ToString(),
                    Body = null,
                    QueryParameters = Newtonsoft.Json.JsonConvert.SerializeObject(productId),
                };
                _loggerActions.CreateLogger(error);
                return StatusCode(500, new Models.ApiModels.Response.Error
                {
                    ErrorCode = error.ErrorCode,
                    Message = error.Message,
                    Reference = error.Reference
                });
            }
        }

    }
}
