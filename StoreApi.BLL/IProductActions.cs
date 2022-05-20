using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoreApi.Models;

namespace StoreApi.BLL
{
    public interface IProductActions
    {
        public Task<List<StoreApi.Models.ApiModels.Request.Product>> GetCatalog();
    }
}
