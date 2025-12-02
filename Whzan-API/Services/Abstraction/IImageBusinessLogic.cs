using Whzan_API.EF.Models;

namespace Whzan_API.Services.Abstraction
{
    public interface IImageBusinessLogic
    {
        public Task<int> AddImageAsynce(Image image);

        public Task<int> AddImageProductAsync(ProductImage productImage);
        public Task<int> UpdateProductImage(int imageId, string fullPath);
    }
}
