using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApi.DAL
{
    public interface IProduct
    {
        public Task<List<StoreApi.Models.ApiModels.Request.Product>> GetCatalog();
    }
}