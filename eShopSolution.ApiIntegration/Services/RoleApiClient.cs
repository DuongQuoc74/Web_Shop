using eShopSolution.ViewModels.Common;
using eShopSolution.ViewModels.System.Roles;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace eShopSolution.ApiIntegration.Services
{
    public class RoleApiClient : IRoleApiClient
    {
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IHttpClientFactory _httpClientFactory;
        public RoleApiClient(IConfiguration configuration, IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor)
        {
            _configuration= configuration;
            _httpContextAccessor= httpContextAccessor;
            _httpClientFactory= httpClientFactory;
        }
        public async Task<ApiResult<List<RoleVm>>> GetAll()
        {
            var client =  _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);

            var sessions = _httpContextAccessor.HttpContext.Session.GetString("Token");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);

            var reponse = await client.GetAsync($"/api/roles");
            var body = await reponse.Content.ReadAsStringAsync();
            if (reponse.IsSuccessStatusCode)
            {
                List<RoleVm> deserializeObject = (List<RoleVm>)JsonConvert.DeserializeObject(body, typeof(List<RoleVm>));
                return new ApiSuccessResult<List<RoleVm>>(deserializeObject);
            }
            return JsonConvert.DeserializeObject<ApiErrorResult<List<RoleVm>>>(body);
        }
    }
}
