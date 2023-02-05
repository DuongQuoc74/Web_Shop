using eShopSolution.ViewModels.Utilities.Slides;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace eShopSolution.ApiIntegration.Services
{
    public interface ISildeAipClient
	{
		Task<List<SlideVm>> GetAll();
	}
}
