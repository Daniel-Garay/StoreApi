using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApi.BLL
{
    /// <summary>
    /// Interface para las funcionalidades de logger en BLL
    /// </summary>
    public interface ILoggerActions
    {
        /// <summary>
        /// Método para creación de los logs
        /// </summary>
        /// <param name="error"></param>
        public void CreateLogger(Models.InternalUse.Error error);
    }
}
