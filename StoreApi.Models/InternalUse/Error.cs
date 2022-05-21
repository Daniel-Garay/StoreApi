using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApi.Models.InternalUse
{
    public class Error : StoreApi.Models.ApiModels.Response.Error
    {
        public string EndPoint { get; set; }
        public string? Body { get; set; }
        public string? QueryParameters { get; set; }
    }
}
