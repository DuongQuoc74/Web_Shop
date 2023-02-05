using eShopSolutin.Application.System.Utilities.Slides;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace eShopSolution.BackendApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[Authorize]
	public class SlidesController : ControllerBase
	{
		private readonly ISlideService _slideService;
		public SlidesController(ISlideService slideService) 
		{
			_slideService = slideService;
		}
		[HttpGet]
		[AllowAnonymous]
		public async Task<IActionResult> Slides()
		{
			var slide = await _slideService.GetAll();
			return Ok(slide);
		}
	}
}
