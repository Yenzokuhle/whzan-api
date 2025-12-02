using Whzan_API.DTOs.Request;
using Whzan_API.DTOs.Response;
using Whzan_API.EF.Models;

namespace Whzan_API.Services.Abstraction
{
    public interface IProductRepository
    {
        public Task<int> AddAsync(Product product);
        public Task<List<ProductResponse>> AllProducts(ProductFilterRequest? filter);
        public Task<ProductResponse> GetProductById(int id);
        public Task<int> UpdateAsync(ProductUpdateRequest dto);
        public Task<int> DeleteAsync(int id);

        public Task<Product?> GetProductEntityById(int id);
        public Task<int> UpdateEntityAsync(Product product);
        public Task<List<Product>> FilterProductsAsync(ProductFilterRequest filter);

        public Task<List<ProductResponse>> SearchProductByName(string name);

        public Task<int> TotalNumberOfProductsAsync();
        public Task<int> AllProductsInFilter(ProductFilterRequest? filter);

        public Task<List<string>> GetBrands();
    }
}
