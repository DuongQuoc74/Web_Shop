using eShopSolution.ApiIntegration.Services;
using eShopSolution.ViewModels.Catalog.Products;
using eShopSolution.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace eShopSolution.WebApp.Controllers
{
	public class ProductController : Controller
	{

		public readonly ICategoryApiClient _categoryApiClient;
		public readonly IProductApiClient  _productApiClient;
		public ProductController(ICategoryApiClient categoryApiClient, IProductApiClient productApiClient)
		{
			_categoryApiClient = categoryApiClient;
			_productApiClient = productApiClient;
		}
		public async Task<IActionResult> Category(string culture, int id)
		{
			var products = await _productApiClient.GetPagings(new GetManageProductPadingRequest()
			{
				CategoryId = id,
				LanguageId = culture,
				PageIndex = 1,
				PageSize = 10
			});
			var productCategory = new ProductCategoryViewModel()
			{
				Category = await _categoryApiClient.GetById(id, culture),
				Product = products
			};

            return View(productCategory);
		}

		public async Task<IActionResult > Detail(string culture, int id)
		{
			var product = await _productApiClient.GetById(id, culture);
			var category = await _categoryApiClient.GetById(id, culture);
			var productDetail = new ProductDetailViewModel()
			{
				Product = product,
				Category = category
			};
			return View(productDetail);
		}
	}
}
