using Whzan_API.EF.Context;
using Whzan_API.EF.Models;
using Whzan_API.Services.Abstraction;
using Image = Whzan_API.EF.Models.Image;

namespace Whzan_API.Services.Concrete
{
    public class ImageRepository : IImageRepository
    {
        private readonly WhzanCatalogDBContext _whzanCatalogDBContext;

        public ImageRepository(WhzanCatalogDBContext whzanCatalogDBContext)
        {
            _whzanCatalogDBContext = whzanCatalogDBContext;
        }

        public async Task<int> AddImageAsynce(Image image)
        {
            await _whzanCatalogDBContext.Image.AddAsync(image);
            await _whzanCatalogDBContext.SaveChangesAsync();

            return image.Id;
        }

        public async Task<int> AddImageProductAsync(ProductImage productImage)
        {
            await _whzanCatalogDBContext.ProductImage.AddAsync(productImage);
            await _whzanCatalogDBContext.SaveChangesAsync();

            return productImage.Id;
        }

        public async Task<int> UpdateProductImage(int imageId, string fullPath)
        {
            var image = await _whzanCatalogDBContext.Image.FindAsync(imageId);

            if (image == null)
                return 0;

            image.ImageURL = fullPath;

            await _whzanCatalogDBContext.SaveChangesAsync();
            return 1;
        }

    }
}
