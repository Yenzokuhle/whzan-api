using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Whzan_API.DTOs.Request;
using Whzan_API.DTOs.Response;
using Whzan_API.EF.Models;
using Whzan_API.Services.Abstraction;
using Whzan_API.Services.Concrete;

namespace Whzan_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WatchedController : ControllerBase
    {
        private readonly IWatchedBusinessLogic _watchedBusinessLogic;
        public WatchedController(IWatchedBusinessLogic watchedBusinessLogic)
        {
            _watchedBusinessLogic = watchedBusinessLogic;
        }


        [HttpPatch]
        [Route("addWatched/{id}")]
        public async Task<ActionResult<DataResponse>> Add([FromRoute] int id)
        {
            var dataResponse = new DataResponse();

            try
            {
                var favId = await _watchedBusinessLogic.UpdateToFav(id);

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
                var favs = await _watchedBusinessLogic.GetAll();

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
