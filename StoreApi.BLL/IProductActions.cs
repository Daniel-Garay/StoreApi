using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoreApi.Models;
using StoreApi.Models.ApiModels.Request;

namespace StoreApi.BLL
{
    public interface IProductActions
    {
        public List<StoreApi.Models.ApiModels.Response.Product> GetCatalog(FilterCatalog filterCatalog);
        public StoreApi.Models.ApiModels.Response.Product CreateProduct(StoreApi.Models.ApiModels.Request.ProductCreate product);
        public StoreApi.Models.ApiModels.Response.Product UpdateProduct(StoreApi.Models.ApiModels.Request.ProductUpdate product, int productId);

    }
}