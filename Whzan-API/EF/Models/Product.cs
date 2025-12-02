namespace Whzan_API.EF.Models
{
    public class Product
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required string Brand { get; set; }
        public required string Currency {  get; set; }
        public decimal Price { get; set; }
        public decimal Rating { get; set; }
        public int ReviewCount { get; set; }
        public bool InStock { get; set; }
        public bool IsPredefined { get; set; }
        public bool IsFavourite { get; set; } = false;
        public bool isWatched { get; set; } = false;
        public string? ImageURL { get; set; }
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public Watched? WatchedProduct { get; set; }
        public Favourite? Favourite { get; set; }

        public ICollection<Tag> Tags { get; set; } = new List<Tag>();
        public ICollection<ProductImage> ProductImages { get; set; } = new List<ProductImage>();
        public ICollection<ProductCategory> ProductCategories { get; set; } = new List<ProductCategory>();
        public ICollection<ProductCurrency> ProductCurrencies { get; set; } = new List<ProductCurrency>();
    }
}
