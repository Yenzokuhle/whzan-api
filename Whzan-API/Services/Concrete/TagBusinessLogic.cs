using Whzan_API.EF.Models;
using Whzan_API.Services.Abstraction;

namespace Whzan_API.Services.Concrete
{
    public class TagBusinessLogic : ITagBusinessLogic
    {
        private readonly ITagRepository _tagRepository;

        public TagBusinessLogic(ITagRepository tagRepository) 
        { 
            _tagRepository = tagRepository;
        }

        public async Task<int> Add(List<Tag> tags)
        {
            return await _tagRepository.Add(tags);
        }

        public async Task<int> Delete(int id)
        {
            return await _tagRepository.Delete(id);
        }

        public async Task<int> DeleteProductTags(int id)
        {
            return await _tagRepository.DeleteProductTags(id);
        }
    }
}
