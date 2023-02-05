using eShopSolution.ViewModels.Catalog.Products;
using EshopSolution.Untilities.Constants;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using Microsoft.Extensions.Configuration;
using eShopSolution.ViewModels.Common;
using eShopSolution.ApiIntegration.Services;

namespace eShopSolution.AdminApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductApiClient _productApiClient;
        private readonly ICategoryApiClient _categoryApiClient;
        private readonly IConfiguration _configuration;
        public ProductController(IProductApiClient productApiClient,
            ICategoryApiClient categoryApiClient, IConfiguration configuration)
        {
            _productApiClient = productApiClient;
            _categoryApiClient = categoryApiClient;
            _configuration = configuration;
        }
        public async Task<IActionResult> Index(string keyword, int? categoryId, int pageIndex = 1, int pageSize = 5)
        {
            var languageId = HttpContext.Session.GetString(SystemConstants.AppSettings.DefaultLanguageId);
            var request = new GetManageProductPadingRequest()
            {
                KeyWord = keyword,
                PageSize = pageSize,
                PageIndex = pageIndex,
                LanguageId = languageId,
                CategoryId = categoryId
            };




            var data = await _productApiClient.GetPagings(request);
            ViewBag.KeyWord = keyword;//giữ từ khóa tìm kiếm trên ô tìm kiếm

            var categories = await _categoryApiClient.GetAll(languageId);
            ViewBag.Categories = categories.Select(x => new SelectListItem()
            {
                Text = x.Name,
                Value = x.Id.ToString()
            });

            if (TempData["result"] != null)
            {
                ViewBag.SuccessMsg = TempData["result"];
            }
            return View(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Create([FromForm] ProductCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return View(request);
            }
            var result = await _productApiClient.CreateProduct(request);
            if (result)
            {
                TempData["result"] = "Thêm sản phẩm thành công.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Thêm sản phẩm thất bại.");
            return View(request);
        }

        [HttpGet]
        public async Task<IActionResult> CategoryAssign(int id)
        {
            var categoryAssignRequest = await GetCategoryAssignRequest(id);
            return View(categoryAssignRequest);
        }

        [HttpPost]
        public async Task<IActionResult> CategoryAssign(CategoryAssignRequest request)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var resullt = await _productApiClient.CategoryAssign(request.Id, request);
            if (resullt.IsSuccessed)
            {
                TempData["result"] = "Gán danh mục thành công";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", resullt.Message);
            var categoryAssignrequest= await GetCategoryAssignRequest(request.Id);
            return View(categoryAssignrequest);

        }

        private async Task<CategoryAssignRequest> GetCategoryAssignRequest(int id)
        {
            var languageId = HttpContext.Session.GetString(SystemConstants.AppSettings.DefaultLanguageId);

            var productObj =await _productApiClient.GetById(id, languageId);
            var categories = await _categoryApiClient.GetAll(languageId);
            var categoryAssignRequest = new CategoryAssignRequest();
            foreach (var role in categories)
            {
                categoryAssignRequest.Categories.Add(new SelectItem()
                {
                    Id=role.Id.ToString(),
                    Name=role.Name,
                    Selected= productObj.Categories.Contains(role.Name)
                    
                });
            }
            return categoryAssignRequest;
        }

        [HttpGet]
        public async Task<IActionResult> Edit( int id)
        {
            var languageId = HttpContext.Session.GetString(SystemConstants.AppSettings.DefaultLanguageId);
            var product = await _productApiClient.GetById(id, languageId);
            var updateProduct = new ProductUpdateRequest()
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                SeoAlias = product.SeoAlias,
                Details = product.Details,
                SeoDescription = product.SeoDescription,
                SeoTitle = product.SeoTitle,
            };
            return View(updateProduct);
        }
        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Edit([FromForm] ProductUpdateRequest request)
        {
            if(!ModelState.IsValid)
            {
                return View(request);
            }
			var result = await _productApiClient.UpdateProduct(request);
			if (result)
			{
				TempData["result"] = "Cập nhật sản phẩm thành công.";
				return RedirectToAction("Index");
			}
			ModelState.AddModelError("", "Cập nhật sản phẩm thất bại.");
			return View(request);

		}

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var data = new ProductDeleteRequest()
            {
                ProductId = id
            };
            return View(data);
        }

        [HttpPost]
        public async Task<ActionResult> Delete(ProductDeleteRequest request)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }
            var result = await _productApiClient.DeleteProduct(request.ProductId);
            if (result)
            {
                TempData["result"] = "Xóa sản phẩm thành công.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Xóa sản phẩm không thành công");
            return View(request);
        }
    }
}
