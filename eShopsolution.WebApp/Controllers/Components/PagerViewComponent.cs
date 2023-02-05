using eShopSolution.ViewModels.Common;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace eShopSolution.WebApp.Controllers.Components
{


	public class PagerViewComponent : ViewComponent //phân trang
	{
		public Task<IViewComponentResult> InvokeAsync(PagedResultBase result)
		{
			return Task.FromResult((IViewComponentResult)View("Default", result));
		}
	}

}

