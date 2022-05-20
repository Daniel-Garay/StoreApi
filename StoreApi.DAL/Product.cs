using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApi.DAL
{
    public class Product : IProduct
    {
        public Task<List<Models.ApiModels.Request.Product>> GetCatalog()
        {
            List<Models.ApiModels.Request.Product> ProductList = new List<Models.ApiModels.Request.Product>();
            Models.ApiModels.Request.Product product = new Models.ApiModels.Request.Product() { Category = "Computer", Name = "Computador XP", Description = "Computador para uso Personal" };
            ProductList.Add(product);
            return Task.FromResult(ProductList);
        }
    }
}
