using Microsoft.EntityFrameworkCore;
using Whzan_API.DTOs.Response;
using Whzan_API.EF.Context;
using Whzan_API.EF.Models;
using Whzan_API.Services.Abstraction;

namespace Whzan_API.Services.Concrete
{
    public class WatchedRepository : IWatchedRepository
    {
        private readonly WhzanCatalogDBContext _whzanCatalogDBContext;

        public WatchedRepository(WhzanCatalogDBContext whzanCatalogDBContext)
        {
            _whzanCatalogDBContext = whzanCatalogDBContext;
        }

        public async Task<int> UpdateToFav(int productId)
        {
            var product = await _whzanCatalogDBContext.Product.FindAsync(productId);

            if (product == null)
                return 0;

            product.isWatched = !product.isWatched;
            product.UpdatedAt = DateTime.Now;

            await _whzanCatalogDBContext.SaveChangesAsync();
            return 1;
        }

        public async Task<List<ProductResponse>> GetAll()
        {
            var favourits = await _whzanCatalogDBContext.Product.Include(p => p.ProductImages)
                    .ThenInclude(pi => pi.Image).Where(p => p.isWatched == true).ToListAsync();

            return favourits.Select(product => new ProductResponse
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Brand = product.Brand,
                Price = product.Price,
                Currency = product.Currency,
                Rating = product.Rating,
                ReviewCount = product.ReviewCount,
                IsPredefined = product.IsPredefined,
                InStock = product.InStock,
                Images = product.ProductImages
                    .Select(pi => new ImageResponseDTO
                    {
                        Id = pi.Image.Id,
                        ImageURL = pi.Image.ImageURL
                    }).ToList()
            }).ToList();

        }
    }
}
