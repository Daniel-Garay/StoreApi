using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApi.BLL
{
    public interface ILoggerActions
    {
        public void CreateLogger(StoreApi.Models.ApiModels.Response.Error error);
    }
}
