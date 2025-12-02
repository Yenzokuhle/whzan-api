using Microsoft.AspNetCore.Mvc;
using Whzan_API.DTOs.Request;
using Whzan_API.DTOs.Response;
using Whzan_API.EF.Context;
using Whzan_API.EF.Models;
using Whzan_API.Services.Abstraction;

namespace Whzan_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductBusinessLogic _productBusinessLogic;
        private readonly IWebHostEnvironment _hostingEnv;
        private readonly IImageBusinessLogic _imageBusinessLogic;
        private readonly ITagBusinessLogic _tagBusinessLogic;

        public ProductController(
            IProductBusinessLogic productBusinessLogic,
            IImageBusinessLogic imageBusinessLogic,
            IWebHostEnvironment hostingEnv,
            ITagBusinessLogic tagBusinessLogic)
        {
            _productBusinessLogic = productBusinessLogic;
            _hostingEnv = hostingEnv;
            _imageBusinessLogic = imageBusinessLogic;
            _tagBusinessLogic = tagBusinessLogic;
        }

        [HttpGet]
        [Route("Ping")]
        public ActionResult<DataResponse> HealthCheck()
        {

            var dataResponse = new DataResponse();

            dataResponse.IsSuccess = true;
            dataResponse.Data = "Alive and kicking";
            dataResponse.Message = "Product Added";

            return Ok(dataResponse);
        }

        [HttpPost]
        [Route("Add")]
        public async Task<ActionResult<DataResponse>> Add([FromBody] ProductRequest productRequest)
        {
            var dataResponse = new DataResponse();

            try
            {
                var product = new Product()
                {
                    Name = productRequest.Name,
                    Description = productRequest.Description,
                    Brand = productRequest.Brand,
                    Currency = productRequest.Currency,
                    InStock = productRequest.InStock,
                    IsPredefined = false,
                    Price = productRequest.Price,
                    Rating = productRequest.Rating,
                    ReviewCount = productRequest.ReviewCount,
                };

                var productId = await _productBusinessLogic.AddAsync(product);

                var tags = productRequest.Tags.Select(tag => new Tag() 
                { 
                    Name = tag.Name, 
                    ProductId = productId 
                }).ToList();

                var tageFlag = await _tagBusinessLogic.Add(tags);

                dataResponse.IsSuccess = true;
                dataResponse.Data = new { ProductId  = productId };
                dataResponse.Message = $"Product Added";

                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                dataResponse.IsSuccess = true;
                dataResponse.Data = null;
                dataResponse.Message = $"No products recieved. Issue:  {ex.Message}";

                return StatusCode(500, dataResponse);
            }
        }

        [HttpPost]
        [Route("GetAll")]
        public async Task<ActionResult<DataResponse>> GetAll([FromBody] ProductFilterRequest filter) 
        {
            var dataResponse = new DataResponse();

            try
            {

                var totalProduct = await _productBusinessLogic.AllProductsInFilter(filter);
                var products = await _productBusinessLogic.AllProducts(filter);

                dataResponse.IsSuccess = true;
                dataResponse.Data = new {TotalProduct = totalProduct, Products = products};
                dataResponse.Message = $"All products";

                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                dataResponse.IsSuccess = true;
                dataResponse.Data = null;
                dataResponse.Message = $"No products recieved. Issue:  {ex.Message}";

                return StatusCode(500, dataResponse);
            }
        }

        [HttpGet]
        [Route("GetProdutById/{id}")]
        public async Task<ActionResult<DataResponse>> GetAll([FromRoute] int id)
        {
            var dataResponse = new DataResponse();

            try
            {
                var product = await _productBusinessLogic.GetProductById(id);

                if (product == null)
                {
                    dataResponse.IsSuccess = true;
                    dataResponse.Data = product;
                    dataResponse.Message = $"No Product with such Id";

                    return NotFound(dataResponse);
                }

                dataResponse.IsSuccess = true;
                dataResponse.Data = product;
                dataResponse.Message = $"Got product";

                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                dataResponse.IsSuccess = true;
                dataResponse.Data = null;
                dataResponse.Message = $"No product recieved. Issue:  {ex.Message}";

                return StatusCode(500, dataResponse);
            }
        }

        [HttpPatch]
        [Route("Update")]
        public async Task<ActionResult<DataResponse>> Update([FromBody] ProductUpdateRequest productPartialUpdateDTO)
        {
            var dataResponse = new DataResponse();

            try
            {
                var updateFlag = await _productBusinessLogic.UpdateAsync(productPartialUpdateDTO);

                var tags = productPartialUpdateDTO.Tags.Select(tag => new Tag()
                {
                    Name = tag.Name,
                    ProductId = productPartialUpdateDTO.Id
                }).ToList();

                var productDeltedTags = await _tagBusinessLogic.DeleteProductTags(productPartialUpdateDTO.Id);

                var addedTags = await _tagBusinessLogic.Add(tags);

                dataResponse.Message = "Product Updated.";
                dataResponse.IsSuccess = true;
                dataResponse.Data = new { ProductId = productPartialUpdateDTO.Id };

                return Ok(dataResponse);

            }
            catch (Exception ex)
            {
                dataResponse.Message = $"Could Not Update Product. Something went wrong {ex.Message}";
                dataResponse.IsSuccess = false;
                dataResponse.Data = null;

                return StatusCode(500, dataResponse);
            }
        }


        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task<ActionResult<DataResponse>> Delete([FromRoute] int  id)
        {
            var dataResponse = new DataResponse();

            try
            {
                var updateFlag = await _productBusinessLogic.DeleteAsync(id);

                dataResponse.Message = "Product Updated.";
                dataResponse.IsSuccess = true;
                dataResponse.Data = new { ProductId = id };

                return Ok(dataResponse);

            }
            catch (Exception ex)
            {
                dataResponse.Message = $"Could Not Update Product. Something went wrong {ex.Message}";
                dataResponse.IsSuccess = false;
                dataResponse.Data = null;

                return StatusCode(500, dataResponse);
            }
        }

        [HttpPost]
        [Route("UploadImage")]
        public async Task<DataResponse> UploadImage([FromForm] ProductImageRequestDTO productImageContent)
        {

            var responseData = new DataResponse();

            try
            {
                //Save the uploaded file
                var savedImageName = await SaveFileImageToImageFolder(productImageContent.BookImage);

                if (string.IsNullOrEmpty(savedImageName))
                {
                    responseData.Message = "Could not upload image";
                    responseData.Data = null;
                    responseData.IsSuccess = false;
                    return responseData;
                }

                //Parse product ID
                if (!int.TryParse(productImageContent.ProductId, out int productId))
                {
                    responseData.Message = "Invalid Product ID";
                    responseData.Data = null;
                    responseData.IsSuccess = false;
                    return responseData;
                }

                //Retrieve EF entity
                var product = await _productBusinessLogic.GetProductEntityById(productId);



                if (product == null)
                {
                    responseData.Message = "Product not found";
                    responseData.Data = null;
                    responseData.IsSuccess = false;
                    return responseData;
                }

                //Delete old image if exists
                //if (!string.IsNullOrEmpty(product.ImageURL))
                //{
                //    var oldImageName = Path.GetFileName(product.ImageURL);
                //    DeleteImage(oldImageName);
                //}

                //Update ImageURL and timestamp
                product.ImageURL = GetImageFilePath(savedImageName);
                product.UpdatedAt = DateTime.Now;

                //Save changes to database
                await _productBusinessLogic.UpdateEntityAsync(product);

                var imageUrl = GetImageFilePath(savedImageName);

                var imageEntity = new Image { ImageURL = imageUrl };

                var imageId = await _imageBusinessLogic.AddImageAsynce(imageEntity);

                var productImage = new ProductImage
                {
                    ProductId = productId,
                    ImageId = imageId
                };

                var productImageId = await _imageBusinessLogic.AddImageProductAsync(productImage);

                //Return success response
                responseData.Message = "Image uploaded successfully";
                responseData.Data = new { ProductId = product.Id, ImageURL = product.ImageURL };
                responseData.IsSuccess = true;
                return responseData;
            }
            catch (Exception ex)
            {
                responseData.Message = $"Something went wrong: {ex.Message}";
                responseData.Data = null;
                responseData.IsSuccess = false;
                return responseData;
            }
        }


        [HttpPost]
        [Route("UploadProductImages")]
        public async Task<DataResponse> UploadProductImages([FromForm] List<ProductImageRequestDTO> imageRequests)
        {
            var responseData = new DataResponse();
            var results = new List<object>();

            try
            {
                foreach (var dto in imageRequests)
                {
                    // Parse product ID
                    if (!int.TryParse(dto.ProductId, out int productId))
                        continue;

                    // Get EF entity
                    var product = await _productBusinessLogic.GetProductEntityById(productId);
                    if (product == null) continue;

                    // Save file_
                    var savedImageName = await SaveFileImageToImageFolder(dto.BookImage);
                    if (string.IsNullOrEmpty(savedImageName)) continue;

                    var imageUrl = GetImageFilePath(savedImageName);

                    // Create Image entity
                    var imageEntity = new Image { ImageURL = imageUrl };

                    // Create ProductImage linking Product and Image
                   

                    // Add to DbContext
                    var imageId = await _imageBusinessLogic.AddImageAsynce(imageEntity);

                    var productImage = new ProductImage
                    {
                        ProductId = productId,
                        ImageId = imageId
                    };

                    var productImageId = await _imageBusinessLogic.AddImageProductAsync(productImage);

                    results.Add(new { ProductId = product.Id, ImageURL = imageUrl });
                }

                responseData.Message = "Images uploaded successfully";
                responseData.Data = results;
                responseData.IsSuccess = true;
                return responseData;
            }
            catch (Exception ex)
            {
                responseData.Message = $"Something went wrong: {ex.Message}";
                responseData.Data = null;
                responseData.IsSuccess = false;
                return responseData;
            }
        }

        [HttpPost]
        [Route("Filter")]
        public async Task<ActionResult<DataResponse>> FilterProducts([FromBody] ProductFilterRequest filter)
        {
            var response = new DataResponse();

            try
            {
                var products = await _productBusinessLogic.FilterProductsAsync(filter);

                response.IsSuccess = true;
                response.Message = "Products filtered successfully.";
                response.Data = products;

                return Ok(response);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = $"Error: {ex.Message}";
                return StatusCode(500, response);
            }
        }

        [HttpGet]
        [Route("Search/{name}")]
        public async Task<ActionResult<DataResponse>> Delete([FromRoute] string name)
        {
            var dataResponse = new DataResponse();

            try
            {
                var product = await _productBusinessLogic.SearchProductByName(name);

                if (product == null)
                {
                    dataResponse.IsSuccess = true;
                    dataResponse.Data = product;
                    dataResponse.Message = $"No Product with such Id";

                    return NotFound(dataResponse);
                }

                dataResponse.IsSuccess = true;
                dataResponse.Data = product;
                dataResponse.Message = $"Got product";

                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                dataResponse.IsSuccess = true;
                dataResponse.Data = null;
                dataResponse.Message = $"No product recieved. Issue:  {ex.Message}";

                return StatusCode(500, dataResponse);
            }
        }


        [HttpGet]
        [Route("GetAllBrands")]
        public async Task<ActionResult<DataResponse>> GetAllBrands()
        {
            var dataResponse = new DataResponse();

            try
            {
                var product = await _productBusinessLogic.GetBrands();

                if (product == null)
                {
                    dataResponse.IsSuccess = true;
                    dataResponse.Data = product;
                    dataResponse.Message = $"No Product Brands";

                    return NotFound(dataResponse);
                }

                dataResponse.IsSuccess = true;
                dataResponse.Data = product;
                dataResponse.Message = $"Got product brands";

                return Ok(dataResponse);
            }
            catch (Exception ex)
            {
                dataResponse.IsSuccess = true;
                dataResponse.Data = null;
                dataResponse.Message = $"No product brands recieved. Issue:  {ex.Message}";

                return StatusCode(500, dataResponse);
            }
        }

        [HttpPatch]
        [Route("UpdateImageById")]
        public async Task<ActionResult<DataResponse>> UpdateImageById([FromForm] ImageRequestFormDTO imageRequestDTO)
        {
            var responseData = new DataResponse();

            try
            {

                var savedImageName = await SaveFileImageToImageFolder(imageRequestDTO.ProductImage);

                if (!int.TryParse(imageRequestDTO.ImageId, out int imageId))
                {
                    responseData.Message = "Invalid Product ID";
                    responseData.Data = null;
                    responseData.IsSuccess = false;
                    return responseData;
                }

                var imagFullPath = GetImageFilePath(savedImageName);

                await _imageBusinessLogic.UpdateProductImage(imageId, imagFullPath);

                responseData.IsSuccess = true;
                responseData.Data = imageId;
                responseData.Message = $"Got product brands";

                return Ok(responseData);
            }
            catch (Exception ex)
            {
                responseData.IsSuccess = true;
                responseData.Data = null;
                responseData.Message = $"No product brands recieved. Issue:  {ex.Message}";

                return StatusCode(500, responseData);
            }
        }

        [HttpDelete]
        [Route("DeleteProductTag/{tagId}")]
        public async Task<ActionResult<DataResponse>> UpdateImageById([FromRoute] int tagId)
        {

            var dataResponse = new DataResponse();

            try
            {
                var deletedFlag = await _tagBusinessLogic.DeleteProductTags(tagId);

                dataResponse.Message = "Tag Deleted.";
                dataResponse.IsSuccess = true;
                dataResponse.Data = new { TagId = tagId };

                return Ok(dataResponse);

            }
            catch (Exception ex)
            {
                dataResponse.Message = $"Could Not Delete Tag. Something went wrong {ex.Message}";
                dataResponse.IsSuccess = false;
                dataResponse.Data = null;

                return StatusCode(500, dataResponse);
            }

        }


        private async Task<string> SaveFileImageToImageFolder(IFormFile imageFile)
        {
            string imageName = new String(Path.GetFileNameWithoutExtension(imageFile.FileName).Take(10).ToArray()).Replace(' ', '-');
            imageName = imageName + DateTime.Now.ToString("yymmssfff") + Path.GetExtension(imageFile.FileName);

            var imagePath = Path.Combine(_hostingEnv.ContentRootPath, "images", imageName);

            using (var fileStream = new FileStream(imagePath, FileMode.Create))
            {
                await imageFile.CopyToAsync(fileStream);
            }
            return imageName;
        }

        private string GetImageFilePath(string imageName)
        {
            var filePath = String.Format("{0}://{1}{2}/images/{3}", Request.Scheme, Request.Host, Request.PathBase, imageName);
            return filePath;
        }

        private void DeleteImage(string imageName)
        {
            var imagePath = Path.Combine(_hostingEnv.ContentRootPath, "images", imageName);
            if (System.IO.File.Exists(imagePath))
                System.IO.File.Delete(imagePath);
        }

    }
}
