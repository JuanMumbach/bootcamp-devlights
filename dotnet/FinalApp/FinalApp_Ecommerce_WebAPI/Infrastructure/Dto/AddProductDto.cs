using System.ComponentModel.DataAnnotations;

namespace FinalApp_Ecommerce_WebAPI.Infrastructure.Dto
{
    public class AddProductDto
    {
        public string Name { get; set; }
        
        [Length(0, 250)]
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public string? ImageUrl { get; set; }
        public int Stock { get; set; }
        public int CategoryId { get; set; }
    }
}
