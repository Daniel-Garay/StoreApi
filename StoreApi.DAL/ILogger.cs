using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApi.DAL
{
    /// <summary>
    /// Interface para acceder a las funcionalidades de DAL Logger
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// Método para crear un Log en DAL
        /// </summary>
        /// <param name="error"></param>
        public void CreateLogger(StoreApi.Models.InternalUse.Error error);
    }
}
