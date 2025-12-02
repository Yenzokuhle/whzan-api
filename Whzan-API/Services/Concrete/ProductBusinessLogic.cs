using Whzan_API.DTOs.Request;
using Whzan_API.DTOs.Response;
using Whzan_API.EF.Context;
using Whzan_API.EF.Models;
using Whzan_API.Services.Abstraction;

namespace Whzan_API.Services.Concrete
{
    public class ProductBusinessLogic : IProductBusinessLogic
    {
        private readonly IProductRepository _productRepository;
        public ProductBusinessLogic(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<int> AddAsync(Product product)
        {
            return await _productRepository.AddAsync(product);
        }

        public async Task<List<ProductResponse>> AllProducts(ProductFilterRequest? filter)
        {
            return await _productRepository.AllProducts(filter);
        }

        public async Task<ProductResponse> GetProductById(int id)
        {
            return await _productRepository.GetProductById(id);
        }

        public async Task<int> UpdateAsync(ProductUpdateRequest dto)
        {
            return await _productRepository.UpdateAsync(dto);
        }

        public async Task<int> DeleteAsync(int id)
        {
            return await _productRepository.DeleteAsync(id);
        }

        public async Task<Product?> GetProductEntityById(int id)
        {
            return await _productRepository.GetProductEntityById(id);
        }

        public async Task<int> UpdateEntityAsync(Product product)
        {
            return await _productRepository.UpdateEntityAsync(product);
        }

        public async Task<List<Product>> FilterProductsAsync(ProductFilterRequest filter)
        {
            return await _productRepository.FilterProductsAsync(filter);
        }

        public async Task<List<ProductResponse>> SearchProductByName(string name)
        {
            return await _productRepository.SearchProductByName(name);
        }

        public async Task<int> TotalNumberOfProductsAsync()
        {
            return await _productRepository.TotalNumberOfProductsAsync();
        }

        public async Task<List<string>> GetBrands()
        {
            return await _productRepository.GetBrands();
        }

        public async Task<int> AllProductsInFilter(ProductFilterRequest? filter)
        {
            return await _productRepository.AllProductsInFilter(filter);
        }
    }
}
