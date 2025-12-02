namespace Whzan_API.EF.Models
{
    public class Currency
    {
        public int Id { get; set; }
        public required string Code { get; set; }
        public required string Name { get; set; }

        public ICollection<ProductCurrency> ProductCurrencies { get; set; } = new List<ProductCurrency>();
    }
}
