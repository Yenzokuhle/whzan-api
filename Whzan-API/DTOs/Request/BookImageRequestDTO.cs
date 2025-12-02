namespace Whzan_API.DTOs.Request
{
    public class ProductImageRequestDTO
    {
        public required string ProductId { get; set; }

        public required IFormFile BookImage { get; set; }
    }
}
