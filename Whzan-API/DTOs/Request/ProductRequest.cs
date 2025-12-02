namespace Whzan_API.DTOs.Request
{
    public class ProductRequest
    {
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required string Brand { get; set; }
        public required string Currency { get; set; }
        public decimal Price { get; set; }
        public decimal Rating { get; set; }
        public int ReviewCount { get; set; } = 0;
        public bool InStock { get; set; } = true;
        public bool IsPredefined { get; set; } = false;
        public string? ImageURL { get; set; }
        public List<TagRequestDTO>? Tags { get; set; } = new List<TagRequestDTO>();
    }
}
