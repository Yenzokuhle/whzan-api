namespace Whzan_API.EF.Models
{
    public class Image
    {
        public int Id { get; set; }
        public required string ImageURL { get; set; }

        public ICollection<ProductImage> ProductImages { get; set; } = new List<ProductImage>();
    }
}
