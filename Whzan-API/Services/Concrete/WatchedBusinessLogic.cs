using Whzan_API.DTOs.Response;
using Whzan_API.EF.Models;
using Whzan_API.Services.Abstraction;

namespace Whzan_API.Services.Concrete
{
    public class WatchedBusinessLogic : IWatchedBusinessLogic
    {
        public readonly IWatchedRepository _watchedRepository;
        public WatchedBusinessLogic(IWatchedRepository watchedRepository)
        {
            _watchedRepository = watchedRepository;
        }
        public Task<int> UpdateToFav(int productId)
        {
            return _watchedRepository.UpdateToFav(productId);
        }
        public Task<List<ProductResponse>> GetAll()
        {
            return _watchedRepository.GetAll();
        }
    }
}
