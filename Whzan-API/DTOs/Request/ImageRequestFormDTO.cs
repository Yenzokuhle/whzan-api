namespace Whzan_API.DTOs.Request
{
    public class ImageRequestFormDTO
    {
        public string ImageId { get; set; }
        public required IFormFile ProductImage { get; set; }
    }
}
