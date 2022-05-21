using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoreApi.DAL;
using StoreApi.Models.ApiModels.Request;

namespace StoreApi.BLL
{
    /// <summary>
    /// Clase que implementa las funcionalidades de Products en BLL
    /// </summary>
    public class ProductActions : IProductActions
    {
        /// <summary>
        /// Interface para implementar las funcionalidades de Products para DAL
        /// </summary>
        private readonly IProduct _product;
        /// <summary>
        /// Constructor para inyectar la dependencia de DAL Products en BLL
        /// </summary>
        /// <param name="product"></param>
        public ProductActions(IProduct product)
        {
            _product = product;
        }
        /// <summary>
        /// Método para obtener un listado de productos
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public List<Models.ApiModels.Response.Product> GetCatalog(FilterCatalog filterCatalog)
        {
            return _product.GetCatalog(filterCatalog);
        }
        /// <summary>
        /// Método para crear un producto
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public StoreApi.Models.ApiModels.Response.Product CreateProduct(StoreApi.Models.ApiModels.Request.ProductCreate product)
        {
            return _product.CreateProduct(product);
        }
        /// <summary>
        /// Método para actualizar un producto
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public StoreApi.Models.ApiModels.Response.Product UpdateProduct(StoreApi.Models.ApiModels.Request.ProductUpdate product, int productId)
        {
            return _product.UpdateProduct(product, productId);
        }

        /// <summary>
        /// Método para borrar un producto
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public bool DeleteProduct(int productId)
        {
            return _product.DeleteProduct(productId);
        }
    }
}