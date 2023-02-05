
using eShopSolution.ViewModels.Catalog.Categories;
using eShopSolution.ViewModels.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace eShopSolution.ApiIntegration.Services
{
    public class CategoryApiClient : BaseApiClient, ICategoryApiClient
    {
        public CategoryApiClient (IConfiguration configuration, IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor)
            : base(configuration, httpClientFactory, httpContextAccessor)
        { }
        public async Task<List<CategoryVm>> GetAll( string languageId)
        {
            return await GetListAsync<CategoryVm>($"/api/categories?languageId="+ languageId); // "?" là lấy theo dạng querystring
                                                                                                      // "/" là lấy theo dạng routing 
        }

        public async Task<CategoryVm> GetById(int id, string languageId)
        {
            return await GetAsync<CategoryVm>($"/api/categories/{id}/{languageId}");
        }
    }
}
