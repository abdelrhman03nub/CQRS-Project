
using System.ComponentModel.DataAnnotations;

namespace CQRS_Project.Application.DTOs
{
    public class CreateProductDto
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [Range(0.01, 1000000)]
        public decimal Price { get; set; }

        [Range(0, 1000000)]
        public int Stock { get; set; }    

        public int? CategoryId { get; set; }
    }
}
