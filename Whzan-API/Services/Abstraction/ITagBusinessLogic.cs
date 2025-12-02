using Whzan_API.EF.Models;

namespace Whzan_API.Services.Abstraction
{
    public interface ITagBusinessLogic
    {
        public Task<int> Add(List<Tag> tags);

        public Task<int> Delete(int id);

        public Task<int> DeleteProductTags(int id);
    }
}
