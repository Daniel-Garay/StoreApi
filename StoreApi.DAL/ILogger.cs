using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApi.DAL
{
    public interface ILogger
    {
        public void CreateLogger(StoreApi.Models.InternalUse.Error error);
    }
}
