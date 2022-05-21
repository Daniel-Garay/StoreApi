using StoreApi.DAL.Models;
using StoreApi.Models.ApiModels.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApi.DAL
{
    public class Product : IProduct
    {
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
        public StoreApi.Models.ApiModels.Response.Product CreateProduct(StoreApi.Models.ApiModels.Request.Product product)
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
            };

        }
    }
}
