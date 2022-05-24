using Microsoft.Extensions.Configuration;
using StoreApi.DAL.Models;
using StoreApi.Models.ApiModels.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApi.DAL
{
    /// <summary>
    /// Implementación de la interface ILogger en DAL
    /// </summary>
    public class Logger : ILogger
    {

        private readonly IConfiguration _config;

        public Logger(IConfiguration config)
        {
            _config = config;
        }

        /// <summary>
        /// Método para crear un Log en Base de datos
        /// </summary>
        /// <param name="error"></param>
        public void CreateLogger(StoreApi.Models.InternalUse.Error error)
        {
            Models.ApiLog apiLogAdd = new Models.ApiLog()
            {
                Reference = error.Reference,
                Body = error.Body,
                EndPoint = error.EndPoint,
                Message = error.Message,
                QueryParameters = error.QueryParameters,
            };

            using (var context = new StoreContext(_config))
            {

                context.ApiLogs.Add(apiLogAdd);
                context.SaveChanges();
            }
        }
    }
}
