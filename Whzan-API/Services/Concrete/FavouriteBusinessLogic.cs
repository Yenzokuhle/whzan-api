using Whzan_API.DTOs.Response;
using Whzan_API.EF.Models;
using Whzan_API.Services.Abstraction;

namespace Whzan_API.Services.Concrete
{
    public class FavouriteBusinessLogic : IFavouriteBusinessLogic
    {

        private readonly IFavouriteRepository _favouriteRepository;

        public FavouriteBusinessLogic(IFavouriteRepository favouriteRepository)
        {
            _favouriteRepository = favouriteRepository;
        }


        public Task<int> UpdateToFav(int productId)
        {
            return _favouriteRepository.UpdateToFav(productId);
        }
        public Task<List<ProductResponse>> GetAll() 
        {  
            return _favouriteRepository.GetAll(); 
        }
    }
}
