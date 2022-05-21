using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoreApi.DAL;
using StoreApi.Models.ApiModels.Request;

namespace StoreApi.BLL
{
    public class ProductActions : IProductActions
    {
        private readonly IProduct _product;
        public ProductActions(IProduct product)
        {
            _product = product;
        }
        public List<Models.ApiModels.Response.Product> GetCatalog(FilterCatalog filterCatalog)
        {
            return _product.GetCatalog(filterCatalog);
        }

        public StoreApi.Models.ApiModels.Response.Product CreateProduct(StoreApi.Models.ApiModels.Request.ProductCreate product)
        {
            return _product.CreateProduct(product);
        }

        public StoreApi.Models.ApiModels.Response.Product UpdateProduct(StoreApi.Models.ApiModels.Request.ProductUpdate product, int productId)
        {
            return _product.UpdateProduct(product,productId);
        }

        public bool DeleteProduct(int productId)
        {
            return _product.DeleteProduct(productId);
        }
    }
}