using eShopSolution.ViewModels.Catalog.Products;
using eShopSolution.ViewModels.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eShopSolution.ApiIntegration.Services
{
    public interface IProductApiClient
    {
        Task<PagedResult<ProductVm>> GetPagings(GetManageProductPadingRequest request);
        Task<bool> CreateProduct(ProductCreateRequest request);
        Task<bool> UpdateProduct( ProductUpdateRequest request);
        Task<bool> DeleteProduct(int productId);
        Task<ApiResult<bool> >CategoryAssign(int id, CategoryAssignRequest request);
        Task<ProductVm> GetById(int productId, string languageId);
        Task<List<ProductVm>> GetFeaturedProducts(string languageId, int take);  
        Task<List<ProductVm>> GetLatestProducts(string languageId, int take);
    }
}
