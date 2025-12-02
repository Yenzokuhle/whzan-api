namespace Whzan_API.EF.Models
{
    public class ProductCurrency
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int CurrencyId { get; set; }

        public Product? Product { get; set; }
        public Currency? Currency { get; set; }
    }
}
