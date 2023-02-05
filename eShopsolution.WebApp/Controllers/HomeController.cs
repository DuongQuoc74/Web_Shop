using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using eShopsolution.WebApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using LazZiya.ExpressLocalization;
using eShopSolution.WebApp.Models;
using eShopSolution.ApiIntegration.Services;
using System.Globalization;
using EshopSolution.Untilities.Constants;

namespace eShopsolution.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISildeAipClient _slideAipClient;
        private readonly IProductApiClient _productApiClient;
        private readonly ILogger<HomeController> _logger;
		private readonly ISharedCultureLocalizer _loc; // mutiple language 

		public HomeController(ILogger<HomeController> logger, ISildeAipClient slideApiClient, IProductApiClient productApiClient )
        {
            
            _logger = logger;
            _slideAipClient= slideApiClient;
            _productApiClient= productApiClient;
        }

        public async Task<IActionResult> Index()
        {
            var culture = CultureInfo.CurrentCulture.Name;
            var ViewModel = new HomeViewModel()
            {
                
                Slides = await _slideAipClient.GetAll(),
				FeaturedProducts = await _productApiClient.GetFeaturedProducts(culture,SystemConstants.ProductSettings.NumberOfFeatured),
                LatestProducts = await _productApiClient.GetLatestProducts(culture,SystemConstants.ProductSettings.NumberOfFeatured )
                
            };
            return View(ViewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        //Mutiple Language
		public IActionResult SetCultureCookie(string cltr, string returnUrl)
		{
			Response.Cookies.Append(
				CookieRequestCultureProvider.DefaultCookieName,
				CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(cltr)),
				new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
				);

			return LocalRedirect(returnUrl);
		}
        //Mutiple language End
	}
}
