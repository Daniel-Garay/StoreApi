using StoreApi.Models.ApiModels.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoreApi.DAL;

namespace StoreApi.BLL
{
    public class LoggerActions : ILoggerActions
    {
        private readonly ILogger _logger;
        public LoggerActions(ILogger logger)
        {
            _logger = logger;
        }
        public void CreateLogger(Error error)
        {
            _logger.CreateLogger(error);
        }
    }
}
