using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoreApi.Models;
using StoreApi.Models.ApiModels.Request;

namespace StoreApi.BLL
{
    /// <summary>
    /// Interface para las funcionalidades de Products en BLL
    /// </summary>
    public interface IProductActions
    {
        /// <summary>
        /// Método para obtener un listado de productos
        /// </summary>
        /// <param name="filterCatalog"></param>
        /// <returns></returns>
        public List<StoreApi.Models.ApiModels.Response.Product> GetCatalog(FilterCatalog filterCatalog);
        /// <summary>
        /// Método para crear un producto
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public StoreApi.Models.ApiModels.Response.Product CreateProduct(StoreApi.Models.ApiModels.Request.ProductCreate product);
        /// <summary>
        /// Método para actualizar un producto
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public StoreApi.Models.ApiModels.Response.Product UpdateProduct(StoreApi.Models.ApiModels.Request.ProductUpdate product, int productId);
        /// <summary>
        /// Método para borrar un producto
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public bool DeleteProduct( int productId);

    }
}