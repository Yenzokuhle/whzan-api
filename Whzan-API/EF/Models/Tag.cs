namespace Whzan_API.EF.Models
{
    public class Tag
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public int ProductId { get; set; }

        public Product? Product { get; set; }
    }
}
