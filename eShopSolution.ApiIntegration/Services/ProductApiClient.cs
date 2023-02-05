using eShopSolution.ViewModels.Catalog.Products;
using eShopSolution.ViewModels.Common;
using EshopSolution.Untilities.Constants;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace eShopSolution.ApiIntegration.Services
{
    public class ProductApiClient : BaseApiClient, IProductApiClient
    {
        private readonly IConfiguration _configuration;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public ProductApiClient (IConfiguration configuration,
            IHttpClientFactory httpClientFactory,
            IHttpContextAccessor httpContextAccessor) : base(configuration, httpClientFactory, httpContextAccessor  )
        {
            _configuration = configuration;
            _httpClientFactory = httpClientFactory;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<ApiResult<bool>> CategoryAssign(int id, CategoryAssignRequest request)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration[SystemConstants.AppSettings.BaseAddress]);

            var session = _httpContextAccessor.HttpContext.Session.GetString(SystemConstants.AppSettings.Token);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", session);

            var json = JsonConvert.SerializeObject(request);
            var httpcontent = new StringContent(json,Encoding.UTF8, "application/json");

            var reponse = await client.PutAsync($"/api/products/{id}/categories",httpcontent);
            var body = await reponse.Content.ReadAsStringAsync();
            if (reponse.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<ApiSuccessResult<bool>>(body);
            }
            return JsonConvert.DeserializeObject<ApiErrorResult<bool>>(body);
        }

        public async Task<bool> CreateProduct(ProductCreateRequest request)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration[SystemConstants.AppSettings.BaseAddress]);

            var session = _httpContextAccessor.HttpContext.Session.GetString(SystemConstants.AppSettings.Token);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", session);

            var requestcontent = new MultipartFormDataContent();
            var LanguageId = _httpContextAccessor.HttpContext.Session.GetString(SystemConstants.AppSettings.DefaultLanguageId);
            if (request.ThumbnailImage != null)
            {
                byte[] data;
                using (var br = new BinaryReader(request.ThumbnailImage.OpenReadStream()))
                {
                    data = br.ReadBytes((int)request.ThumbnailImage.OpenReadStream().Length);
                }
                ByteArrayContent bytes = new ByteArrayContent(data);
                requestcontent.Add(bytes, "ThumbnailImage", request.ThumbnailImage.FileName);
            }
            requestcontent.Add(new StringContent(request.Price.ToString()),"price" );
            requestcontent.Add(new StringContent(request.Stock.ToString()), "stock");
            requestcontent.Add(new StringContent(request.OriginalPrice.ToString()), "originalPrice");
            requestcontent.Add(new StringContent(request.Description.ToString()), "description");
            requestcontent.Add(new StringContent(request.Name.ToString()), "name");

            requestcontent.Add(new StringContent(request.Details.ToString()), "details");
            requestcontent.Add(new StringContent(request.SeoDescription.ToString()), "seoDescription");
            requestcontent.Add(new StringContent(request.SeoTitle.ToString()), "seoTitle");
            requestcontent.Add(new StringContent(request.SeoAlias.ToString()), "seoAlias");

            requestcontent.Add(new StringContent(LanguageId), "languageId");
            var reponse = await client.PostAsync($"/api/products", requestcontent);

            return reponse.IsSuccessStatusCode;

        }

		public async Task<bool> DeleteProduct(int productId)
		{
			var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration[SystemConstants.AppSettings.BaseAddress]);

            var session = _httpContextAccessor.HttpContext.Session.GetString(SystemConstants.AppSettings.Token);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", session);

            var response = await client.DeleteAsync($"/api/products/{productId}");
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
		}

		public async Task<ProductVm> GetById(int productId, string languageId)
        {
            var data = await GetAsync<ProductVm>($"/api/products/{productId}/{languageId}");

            return data;
        }

        public async Task<List<ProductVm>> GetFeaturedProducts(string languageId, int take)
        {
            var data = await GetListAsync<ProductVm>($"/api/products/featured/{languageId}/{take}");
            return data;
        }

		public async Task<List<ProductVm>> GetLatestProducts(string languageId, int take)
		{
			var data = await GetListAsync<ProductVm>($"/api/products/latest/{languageId}/{take}");
			return data;
		}

		public async Task<PagedResult<ProductVm>> GetPagings(GetManageProductPadingRequest request)
        {
            var data = await GetAsync<PagedResult<ProductVm>>($"/api/products/paging?pageIndex={request.PageIndex}" +
                $"&pageSize={request.PageSize}" +
                $"&keyword={request.KeyWord}&languageId={request.LanguageId}&categoryId={request.CategoryId}");
            return data;
        }

		public async Task<bool> UpdateProduct(ProductUpdateRequest request)
		{
			var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration[SystemConstants.AppSettings.BaseAddress]);

            var session = _httpContextAccessor.HttpContext.Session.GetString(SystemConstants.AppSettings.Token);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", session);

			var requestcontent = new MultipartFormDataContent();
			var LanguageId = _httpContextAccessor.HttpContext.Session.GetString(SystemConstants.AppSettings.DefaultLanguageId);
			if (request.ThumbnailImage != null)
			{
				byte[] data;
				using (var br = new BinaryReader(request.ThumbnailImage.OpenReadStream()))
				{
					data = br.ReadBytes((int)request.ThumbnailImage.OpenReadStream().Length);
				}
				ByteArrayContent bytes = new ByteArrayContent(data);
				requestcontent.Add(bytes, "ThumbnailImage", request.ThumbnailImage.FileName);
			}
			
			requestcontent.Add(new StringContent(request.Description.ToString()), "description");
			requestcontent.Add(new StringContent(request.Name.ToString()), "name");

			requestcontent.Add(new StringContent(request.Details.ToString()), "details");
			requestcontent.Add(new StringContent(request.SeoDescription.ToString()), "seoDescription");
			requestcontent.Add(new StringContent(request.SeoTitle.ToString()), "seoTitle");
			requestcontent.Add(new StringContent(request.SeoAlias.ToString()), "seoAlias");

			requestcontent.Add(new StringContent(LanguageId), "languageId");
			var reponse = await client.PutAsync($"/api/products/" + request.Id, requestcontent);

			return reponse.IsSuccessStatusCode;
		}
	}
}
