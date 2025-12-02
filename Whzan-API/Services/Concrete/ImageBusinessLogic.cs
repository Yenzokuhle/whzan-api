using Whzan_API.EF.Models;
using Whzan_API.Services.Abstraction;

namespace Whzan_API.Services.Concrete
{
    public class ImageBusinessLogic : IImageBusinessLogic
    {

        private readonly IImageRepository _imageRepository;
        public ImageBusinessLogic(IImageRepository imageRepository) 
        { 
            _imageRepository = imageRepository;
        }

        public async Task<int> AddImageAsynce(Image image)
        {
            return await _imageRepository.AddImageAsynce(image);
        }

        public async Task<int> AddImageProductAsync(ProductImage productImage)
        {
            return await _imageRepository.AddImageProductAsync(productImage);
        }
        public async Task<int> UpdateProductImage(int imageId, string fullPath)
        {
            return await _imageRepository.UpdateProductImage(imageId, fullPath);
        }
    }
}
