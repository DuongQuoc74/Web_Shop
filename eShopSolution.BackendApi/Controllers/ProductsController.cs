using eShopsolutin.Data.Entities;
using eShopSolution.ViewModels.Catalog.ProductImages;
using eShopSolution.ViewModels.Catalog.Products;
using eShpsolution.Application.Catalog.Products;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace eShopSolution.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class ProductsController : ControllerBase
    {

       
        private readonly IProductService _productService;
        public ProductsController(IProductService productService)
        {
          
            _productService = productService;
        }

        //[HttpGet("public-pading/{languageId}")]
        //public async Task<IActionResult> GetAllPading(string languageId, [FromQuery] GetPublicProductPadingRequest request)
        //{
        //    var product = await _ProductService.GetAllByCategoryId(languageId, request);
        //    return Ok(product);
        //}

        [HttpGet("paging")]
        [AllowAnonymous]
        public async Task<IActionResult> GetPagings([FromQuery] GetManageProductPadingRequest request)
        {
            var products = await _productService.GetAllPaging(request);
            return Ok(products);
        }

        //Manage
        [HttpGet("{productId}/{languageId}")]
        public async Task<IActionResult> GetById( int productId, string languageId)
        {
            var product = await _productService.GetById(productId, languageId);
            if (product == null)
                return BadRequest("can't find product");
            return Ok(product);
        }

        [HttpPost]
        [Consumes("multipart/form-data")] // chấp nhận formform thay vì formquery
        [Authorize]//muốn sử dụng thì bắt buộc đăng nhập kèm token
        public async Task<IActionResult> Create([FromForm] ProductCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var productId = await _productService.Create(request);
            if (productId == 0)
                return BadRequest();
            var product = await _productService.GetById(productId, request.LanguageId);
            return CreatedAtAction(nameof(GetById), new {id=productId}, product);

        }

        [HttpPut("{productId}")]
		[Consumes("multipart/form-data")]
        [Authorize]//muốn sử dụng thì bắt buộc đăng nhập kèm token
        public async Task<IActionResult> UpDate( [FromRoute]int productId,[FromForm] ProductUpdateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
			request.Id = productId;
			var affectedResult = await _productService.Update(request);
         
            if (affectedResult == 0)
                return BadRequest();
            return Ok();
        }

        [HttpDelete("{productId}")]
        [Authorize]//muốn sử dụng thì bắt buộc đăng nhập kèm token

        public async Task<IActionResult> Delete(int productId)
        {
            var affectedResult = await _productService.Delete(productId);
            if (affectedResult == 0)
                return BadRequest();
            return Ok();
        }

        [HttpPatch("{productId}/{newPrice}")]
        [Authorize]//muốn sử dụng thì bắt buộc đăng nhập kèm token
        public async Task<IActionResult> UpdatePrice(int productId, decimal newPrice)
        {
            var isSuccessful = await _productService.UpdatePrice(productId, newPrice);
            if (isSuccessful)
                return Ok();
            return BadRequest();
        }

        //Images
        [HttpPost("{productId}/images")]
        [Authorize]//muốn sử dụng thì bắt buộc đăng nhập kèm token
        public async Task<IActionResult> CreateImage(int productId, [FromForm] ProductImageCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var imageId = await _productService.AddImage(productId, request);
            if (imageId == 0)
                return BadRequest();

            var image = await _productService.GetImageById(imageId);

            return CreatedAtAction(nameof(GetImageById), new { id = imageId }, image);
        }

        [HttpPut("{productId}/images/{imageId}")]
        [Authorize]//muốn sử dụng thì bắt buộc đăng nhập kèm token

        public async Task<IActionResult> UpdateImage(int imageId, [FromForm] ProductImageUpdateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _productService.UpdateImage(imageId, request);
            if (result == 0)
                return BadRequest();

            return Ok();
        }

        [HttpDelete("{productId}/images/{imageId}")]
        [Authorize]//muốn sử dụng thì bắt buộc đăng nhập kèm token

        public async Task<IActionResult> RemoveImage(int imageId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _productService.RemoveImage(imageId);
            if (result == 0)
                return BadRequest();

            return Ok();
        }

        [HttpGet("{productId}/images/{imageId}")]
        public async Task<IActionResult> GetImageById(int productId, int imageId)
        {
            var image = await _productService.GetImageById(imageId);
            if (image == null)
                return BadRequest("Cannot find product");
            return Ok(image);
        }

        [HttpPut("{id}/categories")]

        public async Task<IActionResult> CategoryAssign(int id, [FromBody] CategoryAssignRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _productService.CategoryAssign(id, request);
            if (!result.IsSuccessed)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpGet("featured/{languageId}/{take}")]
       
        public async Task<IActionResult> GetFeaturedProducts(string languageId, int take)
        {
            var featuredProduct = await _productService.GetFeaturedProducts(languageId, take);
            return Ok(featuredProduct);
        }

		[HttpGet("latest/{languageId}/{take}")]
		public async Task<IActionResult> GetLatestProducts(string languageId, int take)
		{
			var latestproduct = await _productService.GetLatestProducts(languageId, take);
			return Ok(latestproduct);
		}

	}
}
