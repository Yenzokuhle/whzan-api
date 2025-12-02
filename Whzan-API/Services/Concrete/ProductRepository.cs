using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.Linq;
using Whzan_API.DTOs.Request;
using Whzan_API.DTOs.Response;
using Whzan_API.EF.Context;
using Whzan_API.EF.Models;
using Whzan_API.Services.Abstraction;

namespace Whzan_API.Services.Concrete
{
    public class ProductRepository : IProductRepository
    {
        private readonly WhzanCatalogDBContext _whzanCatalogDBContext;

        public ProductRepository(WhzanCatalogDBContext whzanCatalogDBContext)
        {
            _whzanCatalogDBContext = whzanCatalogDBContext;
        }

        public async Task<int> AddAsync(Product product)
        {
            await _whzanCatalogDBContext.Product.AddAsync(product);
            await _whzanCatalogDBContext.SaveChangesAsync();
            return product.Id;
        }

        public async Task<int> AllProductsInFilter(ProductFilterRequest? filter)
        {
            var query = _whzanCatalogDBContext.Product
                .AsQueryable();

            if (filter != null)
            {
                if (!string.IsNullOrEmpty(filter.Name))
                    query = query.Where(p => p.Name.Contains(filter.Name));

                if (filter.InStock.HasValue)
                    query = query.Where(p => p.InStock == filter.InStock);

                if (filter.Brands != null && filter.Brands.Any())
                    query = query.Where(p => filter.Brands.Contains(p.Brand));

                if (!string.IsNullOrEmpty(filter.Currency))
                    query = query.Where(p => p.Currency.Contains(filter.Currency));

                if (filter.MinPrice.HasValue)
                    query = query.Where(p => p.Price >= filter.MinPrice);

                if (filter.MaxPrice.HasValue)
                    query = query.Where(p => p.Price <= filter.MaxPrice);
            }

           

            var products = await query.ToListAsync();
            return products.Count();
        }


        public async Task<List<ProductResponse>> AllProducts(ProductFilterRequest? filter)
        {
            var query = _whzanCatalogDBContext.Product
                .Include(p => p.ProductImages)
                    .ThenInclude(pi => pi.Image)
                .Include(p => p.Tags)
                .AsQueryable();

            if (filter != null)
            {
                if (!string.IsNullOrEmpty(filter.Name))
                    query = query.Where(p => p.Name.Contains(filter.Name));

                if (filter.InStock.HasValue)
                    query = query.Where(p => p.InStock == filter.InStock);

                if (filter.Brands != null && filter.Brands.Any())
                    query = query.Where(p => filter.Brands.Contains(p.Brand));

                if (!string.IsNullOrEmpty(filter.Currency))
                    query = query.Where(p => p.Currency.Contains(filter.Currency));

                if (filter.MinPrice.HasValue)
                    query = query.Where(p => p.Price >= filter.MinPrice);

                if (filter.MaxPrice.HasValue)
                    query = query.Where(p => p.Price <= filter.MaxPrice);
            }

            // Apply pagination
            int skip = (filter?.PageNumber - 1 ?? 0) * (filter?.PageSize ?? 20);
            query = query.Skip(skip).Take(filter?.PageSize ?? 20);

            var products = await query.ToListAsync();

            return products.Select(product => new ProductResponse
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
                Tags = product.Tags.Select(p => new TagsResponseDTO()
                {
                    Id = p.Id,
                    Name = p.Name,
                }).ToList(),
                Images = product.ProductImages
                    .Select(pi => new ImageResponseDTO
                    {
                        Id = pi.Image.Id,
                        ImageURL = pi.Image.ImageURL
                    }).ToList()
            }).ToList();
        }



        public async Task<ProductResponse> GetProductById(int id)
        {
            var product = await _whzanCatalogDBContext.Product
                .Include(p => p.ProductImages)
                    .ThenInclude(pi => pi.Image)
                .Include(p => p.Tags)
                .Where(p => p.Id == id)
                .FirstOrDefaultAsync();

            var productDTO = new ProductResponse()
            {
                Description = product.Description,
                Brand = product.Brand,
                Currency = product.Currency,
                Id = product.Id,
                Name = product.Name,
                Rating = product.Rating,
                ReviewCount = product.ReviewCount,
                Price = product.Price,
                IsPredefined = product.IsPredefined,
                InStock= product.InStock,
                Tags = product.Tags.Select(pt => new TagsResponseDTO
                {
                    Id = pt.Id,
                    Name=pt.Name,
                }).ToList(),
                Images = product.ProductImages.Select(op => new ImageResponseDTO
                {
                    Id = op.Image.Id,
                    ImageURL = op.Image.ImageURL,
                    
                }).ToList(),
            };

            return productDTO;
        }

        public async Task<Product?> GetProductEntityById(int id)
        {
            return await _whzanCatalogDBContext.Product.FindAsync(id);
        }

        public async Task<int> UpdateEntityAsync(Product product)
        {
            _whzanCatalogDBContext.Product.Update(product);
            return await _whzanCatalogDBContext.SaveChangesAsync();
        }

        public async Task<int> UpdateAsync(ProductUpdateRequest dto)
        {
            var entity = await _whzanCatalogDBContext.Product.FindAsync(dto.Id);

            if (entity == null)
                return 0;

            entity.Name = dto.Name;
            entity.Description = dto.Description;
            entity.Price = dto.Price;
            entity.Rating = dto.Rating;
            entity.ReviewCount = dto.ReviewCount;
            entity.InStock = dto.InStock;
            entity.ImageURL = dto.ImageURL;

            var saveFlag = await _whzanCatalogDBContext.SaveChangesAsync();
            return saveFlag;
        }

        public async Task<int> DeleteAsync(int id)
        {
            var entity = await _whzanCatalogDBContext.Product.FindAsync(id);

            if (entity == null)
                return 0;

            _whzanCatalogDBContext.Product.Remove(entity);
            var saveFlag = await _whzanCatalogDBContext.SaveChangesAsync();

            return saveFlag;
        }

        public async Task<List<Product>> FilterProductsAsync(ProductFilterRequest filter)
        {
            var query = _whzanCatalogDBContext.Product.AsQueryable();

            if (!string.IsNullOrEmpty(filter.Name))
                query = query.Where(p => p.Name.Contains(filter.Name));

            if (filter.InStock.HasValue)
                query = query.Where(p => p.InStock == filter.InStock);

            if (filter.Brands != null && filter.Brands.Any())
                query = query.Where(p => filter.Brands.Contains(p.Brand));

            if (!string.IsNullOrEmpty(filter.Currency))
                query = query.Where(p => p.Currency == filter.Currency);

            if (filter.MinPrice.HasValue)
                query = query.Where(p => p.Price >= filter.MinPrice);

            if (filter.MaxPrice.HasValue)
                query = query.Where(p => p.Price <= filter.MaxPrice);

            return await query.ToListAsync();
        }

        public async Task<List<ProductResponse>> SearchProductByName(string name)
        {
            var searchedProducts = await _whzanCatalogDBContext.Product.Where(product => product.Name.Contains(name)).ToListAsync();

            //var searchedProductDTOs = searchedProducts.Select(product => new );
            var searchedProductDTOs = searchedProducts.Select(product => new ProductResponse()
            {
                Description = product.Description,
                Brand = product.Brand,
                Currency = product.Currency,
                Id = product.Id,
                Name = product.Name,
                Rating = product.Rating,
                ReviewCount = product.ReviewCount,
                Price = product.Price,
            }).ToList();

            return searchedProductDTOs;
        }

        public async Task<int> TotalNumberOfProductsAsync()
        {
            return await _whzanCatalogDBContext.Product.CountAsync();
        }

        public async Task<List<string>> GetBrands()
        {
            return await _whzanCatalogDBContext.Product
                .Select(p => p.Brand)
                .Distinct()
                .ToListAsync();
        }

    }
}
