using StoreApi.Models.ApiModels.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoreApi.DAL;

namespace StoreApi.BLL
{
    /// <summary>
    /// Clase que implementa las funcionalidades de logger en BLL
    /// </summary>
    public class LoggerActions : ILoggerActions
    {
        /// <summary>
        /// Interface para implementar las funcionalidades de logger para DAL
        /// </summary>
        private readonly ILogger _logger;
        /// <summary>
        /// Constructor para inyectar la dependencia de DAL logger en BLL
        /// </summary>
        /// <param name="logger"></param>
        public LoggerActions(ILogger logger)
        {
            _logger = logger;
        }
        /// <summary>
        /// Método de implementación para creación de los logs
        /// </summary>
        /// <param name="error"></param>
        public void CreateLogger(Models.InternalUse.Error error)
        {
            _logger.CreateLogger(error);
        }
    }
}
