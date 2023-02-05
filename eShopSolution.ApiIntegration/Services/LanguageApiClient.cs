using eShopSolution.ViewModels.Common;
using eShopSolution.ViewModels.System.Language;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace eShopSolution.ApiIntegration.Services
{
    public class LanguageApiClient : BaseApiClient, ILanguageApiClient
    {
        public LanguageApiClient(IConfiguration configuration,
            IHttpClientFactory httpClientFactory,
            IHttpContextAccessor httpContextAccessor) : base(configuration, httpClientFactory, httpContextAccessor)
        {
        }
        public async Task<ApiResult<List<LanguageVm>>> GetAll()
        {
            return await  GetAsync<ApiResult<List<LanguageVm>>>("/api/languages");
        }
    }
}
