namespace Whzan_API.DTOs.Response
{
    public class ProductResponse
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required string Brand { get; set; }
        public required string Currency { get; set; }
        public decimal Price { get; set; }
        public decimal Rating { get; set; }
        public int ReviewCount { get; set; }
        public bool InStock { get; set; }
        public bool IsPredefined { get; set; }
        public string? ImageURL { get; set; }
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public List<TagsResponseDTO> Tags { get; set; }
        public List<ImageResponseDTO> Images { get; set; } = new();
    }
}
