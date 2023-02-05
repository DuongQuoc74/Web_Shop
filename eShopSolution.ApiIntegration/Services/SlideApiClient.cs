using eShopSolution.ViewModels.Utilities.Slides;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace eShopSolution.ApiIntegration.Services
{
    public class SlideApiClient : BaseApiClient, ISildeAipClient
	{
		public SlideApiClient(IConfiguration configuration, IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor)
			: base(configuration, httpClientFactory, httpContextAccessor)
		{ }
		public async Task<List<SlideVm>> GetAll()
		{
			return await GetListAsync<SlideVm>("/api/slides");
		}
	}
}
