using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using DataAnnotationsExtensions;

namespace StoreApi.Models.ApiModels.Request
{
    public class FilterCatalog
    {
        public OrderByProduct? orderByProduct { get; set; }
        public string? description { get; set; }
        public string? category { get; set; }

        [Min(0)]
        public int from { get; set; } = 0;
        public string? name { get; set; }

        [Range(1, 50, ErrorMessage = "Value must be between 1 to 50")]
        public int maxPageSize { get; set; } = 50;
    }
}
