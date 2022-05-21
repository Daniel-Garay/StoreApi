using System;
using System.Collections.Generic;

namespace StoreApi.DAL.Models
{
    public partial class ApiLog
    {
        public int Id { get; set; }
        public string EndPoint { get; set; } = null!;
        public string Message { get; set; } = null!;
        public string Reference { get; set; } = null!;
        public string? Body { get; set; }
        public string? QueryParameters { get; set; }
    }
}
