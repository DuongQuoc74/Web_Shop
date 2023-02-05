using eShopSolution.ViewModels.Utilities.Slides;
using Microsoft.EntityFrameworkCore;
using ShopSolution.Data.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShopSolutin.Application.System.Utilities.Slides
{
    public class SlideService : ISlideService
	{
		private readonly EShopDbContext _context;
		public SlideService(EShopDbContext context) 
		{
			_context= context;
		}
		public async Task<List<SlideVm>> GetAll()
		{
			var slide = await _context.Slides.OrderBy(x => x.SortOrder)
				.Select(x => new SlideVm()
				{
					Id = x.Id,
					Name = x.Name,
					Description = x.Description,
					Image = x.Image,
					Url = x.Url
				}).ToListAsync();
			return slide;
		}
	}
}
