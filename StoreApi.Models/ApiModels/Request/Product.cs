using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApi.Models.ApiModels.Request
{
    public class ProductCreate
    {
        [Required]
        [StringLength(maximumLength: 200, ErrorMessage = "El campo {0} no debe contener más de {1} carácteres.")]
        public string Name { get; set; }
        [Required]
        [StringLength(maximumLength: 200, ErrorMessage = "El campo {0} no debe contener más de {1} carácteres.")]
        public string Description { get; set; }

        [Required]
        [StringLength(maximumLength: 200, ErrorMessage = "El campo {0} no debe contener más de {1} carácteres.")]
        public string Category { get; set; }

    }

    public class ProductUpdate
    {
        [StringLength(maximumLength: 200, ErrorMessage = "El campo {0} no debe contener más de {1} carácteres.")]
        public string? Name { get; set; }

        [StringLength(maximumLength: 200, ErrorMessage = "El campo {0} no debe contener más de {1} carácteres.")]
        public string? Description { get; set; }

        [StringLength(maximumLength: 200, ErrorMessage = "El campo {0} no debe contener más de {1} carácteres.")]
        public string? Category { get; set; }

    }

    public enum OrderByProduct
    {
        category_desc,
        category_asc,
        name_desc,
        name_asc,
    }
}
