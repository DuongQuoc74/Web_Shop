using eShopSolution.ViewModels.Utilities.Slides;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace eShopSolutin.Application.System.Utilities.Slides
{
    public interface ISlideService
	{
		Task<List<SlideVm>> GetAll();
	}
}
