using System.ComponentModel.DataAnnotations;

namespace OnlineStore.API.DTO.ProductDTO
{
    public class CreateProductDTO
    {
        [Required]
        public string title { get; set; } = string.Empty;

        [Required]
        public float price { get; set; }

        [Required]
        public string category { get; set; } = string.Empty;

        public string description { get; set; } = "No product description";

        public string image { get; set; } = string.Empty;
    }
}
