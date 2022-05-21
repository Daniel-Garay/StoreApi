using System;
using System.Collections.Generic;

namespace StoreApi.DAL.Models
{
    public partial class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Category { get; set; } = null!;
        public DateTime CreationDate { get; set; }
    }
}
