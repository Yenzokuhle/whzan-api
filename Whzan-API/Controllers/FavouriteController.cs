using Microsoft.AspNetCore.Mvc;
using Whzan_API.DTOs.Response;
using Whzan_API.Services.Abstraction;

namespace Whzan_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavouriteController : ControllerBase
    {
        private readonly IFavouriteBusinessLogic _favouriteBusinessLogic;
        public FavouriteController(IFavouriteBusinessLogic favouriteBusinessLogic) 
        {
            _favouriteBusinessLogic = favouriteBusinessLogic;
        }

        [HttpPatch]
        [Route("addFav/{id}")]
        public async Task<ActionResult<DataResponse>> Add([FromRoute] int id)
        {
            var dataResponse = new DataResponse();

            try
            {
               var favId = await _favouriteBusinessLogic.UpdateToFav(id);

                dataResponse.Data = id;
                dataResponse.Message = "Favourite Added";
                dataResponse.IsSuccess = true;

                return Ok(dataResponse);
            }
            catch (Exception ex) 
            {
                dataResponse.Data = null;
                dataResponse.Message = "Favourite Not Added";
                dataResponse.IsSuccess = false;

                return StatusCode(500, dataResponse);
            }
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<ActionResult<DataResponse>> GetAll()
        {
            var dataResponse = new DataResponse();

            try
            {
                var favs = await _favouriteBusinessLogic.GetAll();

                dataResponse.Data = favs;
                dataResponse.Message = "Favourite Added";
                dataResponse.IsSuccess = true;

                return Ok(dataResponse);

            }
            catch (Exception ex) 
            {
                dataResponse.Data = null;
                dataResponse.Message = "No Favourites.";
                dataResponse.IsSuccess = false;

                return StatusCode(500, dataResponse);
            }
        }
    }
}
