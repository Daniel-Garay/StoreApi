using StoreApi.DAL.Models;
using StoreApi.Models.ApiModels.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApi.DAL
{
    /// <summary>
    /// Implementación de la interface IProduct en DAL
    /// </summary>
    public class Product : IProduct
    {
        /// <summary>
        /// Método para consultar un listado de productos en Base de datos
        /// </summary>
        /// <param name="filterCatalog"></param>
        /// <returns></returns>
        public List<StoreApi.Models.ApiModels.Response.Product> GetCatalog(FilterCatalog filterCatalog)
        {
            List<StoreApi.Models.ApiModels.Response.Product> ProductList = new List<StoreApi.Models.ApiModels.Response.Product>();

            var filterAction = (Models.Product product) =>
            {
                return
                  product.Name == (filterCatalog.name ?? product.Name) &&
                  product.Description == (filterCatalog.description ?? product.Description) &&
                  product.Category == (filterCatalog.category ?? product.Category);
            };

            var mappingAction = (Models.Product product) =>
            {
                return new StoreApi.Models.ApiModels.Response.Product()
                {
                    Id = product.Id,
                    CreationDate = product.CreationDate,
                    Description = product.Description,
                    Category = product.Category,
                    Name = product.Name,
                };
            };

            using (var context = new StoreContext())
            {

                var orderedProducts = filterCatalog.orderByProduct switch
                {
                    OrderByProduct.category_desc => context.Products.OrderByDescending(p => p.Category),
                    OrderByProduct.category_asc => context.Products.OrderBy(p => p.Category),
                    OrderByProduct.name_desc => context.Products.OrderByDescending(p => p.Name),
                    OrderByProduct.name_asc => context.Products.OrderBy(p => p.Name),
                    _ => context.Products.OrderBy(p => p.Id)
                };
                return orderedProducts.Where(filterAction).Skip(filterCatalog.from).Take(filterCatalog.maxPageSize).Select(mappingAction).ToList();

            }
        }
        /// <summary>
        /// Método para crear un producto en BD
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public StoreApi.Models.ApiModels.Response.Product CreateProduct(StoreApi.Models.ApiModels.Request.ProductCreate product)
        {
            Models.Product productAdd = new Models.Product()
            {
                Category = product.Category,
                Description = product.Description,
                Name = product.Name,
            };

            using (var context = new StoreContext())
            {

                context.Products.Add(productAdd);
                context.SaveChanges();
            }

            return new StoreApi.Models.ApiModels.Response.Product
            {
                Id = productAdd.Id,
                Category = product.Category,
                Description = product.Description,
                Name = product.Name,
                CreationDate = DateTime.UtcNow,
            };

        }
        /// <summary>
        /// Método para borrar un producto en BD
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public bool DeleteProduct(int productId)
        {

            using (var context = new StoreContext())
            {
                Models.Product product = (Models.Product)context.Products.Where(b => b.Id == productId).First();
                context.Products.Remove(product);
                context.SaveChanges();
            }
            return true;
        }
        /// <summary>
        /// Método para actualizar un producto en BD
        /// </summary>
        /// <param name="product"></param>
        /// <param name="productId"></param>
        /// <returns></returns>
        public StoreApi.Models.ApiModels.Response.Product UpdateProduct(StoreApi.Models.ApiModels.Request.ProductUpdate product, int productId)
        {
            Models.Product productUpdate = new Models.Product();
            Models.Product productActual = new Models.Product();

            using (var context = new StoreContext())
            {
                productActual = context.Products.FirstOrDefault(item => item.Id == productId);

            }

            using (var context = new StoreContext())
            {
                productUpdate.Id = productId;
                productUpdate.Category = (product?.Category != null) ? product.Category : productActual.Category;
                productUpdate.Description = (product?.Description != null) ? product.Description : productActual.Description;
                productUpdate.Name = (product?.Name != null) ? product.Name : productActual.Name;
                productUpdate.CreationDate = productActual.CreationDate;


                context.Products.Update(productUpdate);
                context.SaveChanges();
            }

            return new StoreApi.Models.ApiModels.Response.Product
            {
                Id = productUpdate.Id,
                Category = productUpdate.Category,
                Description = productUpdate.Description,
                Name = productUpdate.Name,
                CreationDate = productUpdate.CreationDate,
            };

        }
    }
}
