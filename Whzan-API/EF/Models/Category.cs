namespace Whzan_API.EF.Models
{
    public class Category
    {
        public int Id { get; set; }
        public required string Name { get; set; }

        public ICollection<ProductCategory> ProductCategories { get; set; } = new List<ProductCategory>();
    }
}
