namespace Whzan_API.DTOs.Request
{
    public class ProductFilterRequest
    {
        public string? Name { get; set; }
        public bool? InStock { get; set; }
        public List<string>? Brands { get; set; }
        public string? Currency { get; set; }

        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }

        //Pagination
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 8;
    }
}
