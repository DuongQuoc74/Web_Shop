using eShopSolution.ViewModels.Catalog.Categories;
using eShopSolution.ViewModels.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eShopSolution.ApiIntegration.Services
{
    public interface ICategoryApiClient
    {
        Task<List<CategoryVm>> GetAll(string languageId);
        Task<CategoryVm> GetById(int id, string languageId);
    }
}
