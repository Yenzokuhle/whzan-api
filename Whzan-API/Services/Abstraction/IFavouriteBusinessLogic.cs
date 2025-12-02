using Whzan_API.DTOs.Response;
using Whzan_API.EF.Models;

namespace Whzan_API.Services.Abstraction
{
    public interface IFavouriteBusinessLogic
    {
        public Task<int> UpdateToFav(int productId);
        public Task<List<ProductResponse>> GetAll();
    }
}
