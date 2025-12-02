using Microsoft.EntityFrameworkCore;
using Whzan_API.DTOs.Request;
using Whzan_API.EF.Context;
using Whzan_API.EF.Models;
using Whzan_API.Services.Abstraction;

namespace Whzan_API.Services.Concrete
{
    public class TagRepository : ITagRepository
    {
        private readonly WhzanCatalogDBContext _whzanCatalogDBContext;

        public TagRepository(WhzanCatalogDBContext whzanCatalogDBContext) 
        { 
            _whzanCatalogDBContext = whzanCatalogDBContext;
        }

        public async Task<int> Add(List<Tag> tags)
        {
            await _whzanCatalogDBContext.Tag.AddRangeAsync(tags);
            var saveFlag = await _whzanCatalogDBContext.SaveChangesAsync();

            return saveFlag;
        }

        public async Task<int> Delete(int id)
        {
            var entity = await _whzanCatalogDBContext.Tag.FindAsync(id);

            if (entity == null)
                return 0;

            _whzanCatalogDBContext.Tag.Remove(entity);
            var saveFlag = await _whzanCatalogDBContext.SaveChangesAsync();

            return saveFlag;
        }

        public async Task<int> DeleteProductTags(int id)
        {
            var bulkDelete = await _whzanCatalogDBContext.Tag.Where(x => x.ProductId == id).ExecuteDeleteAsync();

            return bulkDelete;
        }

        public async Task<int> Update(TagRequestDTO tag)
        {
            var entity = await _whzanCatalogDBContext.Tag.FindAsync(tag.Id);

            if (entity == null)
                return 0;

            entity.Name = tag.Name;

            var saveFlag = await _whzanCatalogDBContext.SaveChangesAsync();
            return saveFlag;

        }
    }
}
