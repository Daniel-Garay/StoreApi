using StoreApi.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoreApi.Models.ApiModels.Request;

namespace StoreApi.DAL
{
    public interface IProduct
    {
        public List<StoreApi.Models.ApiModels.Response.Product> GetCatalog(FilterCatalog filterCatalog);
        public StoreApi.Models.ApiModels.Response.Product CreateProduct(StoreApi.Models.ApiModels.Request.Product product);
    }
}