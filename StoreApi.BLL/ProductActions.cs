using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoreApi.DAL;

namespace StoreApi.BLL
{
    public class ProductActions : IProductActions
    {
        private readonly IProduct _product;
        public ProductActions(IProduct product)
        {
            _product = product;
        }
        public async Task<List<Models.ApiModels.Request.Product>> GetCatalog()
        {
            return await _product.GetCatalog();
        }
    }
}