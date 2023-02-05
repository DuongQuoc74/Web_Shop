using eShopSolution.AdminApp.Models;
using eShopSolution.ApiIntegration.Services;
using EshopSolution.Untilities.Constants;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace eShopSolution.AdminApp.Controllers.Components
{
    public class NavigationViewComponent : ViewComponent
    {
        private readonly ILanguageApiClient _languageApiClient;
        public NavigationViewComponent(ILanguageApiClient languageApiClient)
        {
            _languageApiClient = languageApiClient;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var languages = await _languageApiClient.GetAll();
            var navigationVm = new NavigationViewModel()
            {
                CurrenLangugeId = HttpContext.Session.GetString(SystemConstants.AppSettings.DefaultLanguageId),
                Laguages = languages.ResultObj
            };
            return View("Default",navigationVm); //quyết định trang nào sẽ đc gọi đến trong phần View Component
        }
    }
}
