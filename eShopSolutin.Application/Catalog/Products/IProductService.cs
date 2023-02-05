using eShopSolution.ViewModels.Catalog.ProductImages;
using eShopSolution.ViewModels.Catalog.Products;
using eShopSolution.ViewModels.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eShpsolution.Application.Catalog.Products
{
    public interface IProductService // interface cho adim
    {
        Task<PagedResult<ProductVm>> GetAllByCategoryId(string languageId, GetPublicProductPadingRequest request);
        // Task<List<ProductVm>> GetAll(string languageId);
        Task<int> Create(ProductCreateRequest request);// Trả về mã khác của sản phẩm vừa tạo.
        Task<int> Update ( ProductUpdateRequest request );
        Task<int> Delete(int productId);
        Task<bool> UpdatePrice(int productId, decimal newPrice);
        Task<bool>UpdateStock(int productId, decimal AddedQuantity);
        Task AddViewCount(int productId);
        Task <ProductVm> GetById (int productId, string languageId);
        //Task<List<ProductViewModel>> GetAll();// lấy ra các danh sách thuộc tính mà muốn hiển thị lên
        Task< PagedResult<ProductVm>> GetAllPaging(GetManageProductPadingRequest request);// lấy ra danh sách r trả về theo size
        
        Task <int> AddImage(int productId, ProductImageCreateRequest request);
        Task<int> RemoveImage(int imageId);
        Task<int> UpdateImage(int imageId, ProductImageUpdateRequest request);
        Task<ProductImageViewModel> GetImageById (int imageId);
        Task<List<ProductImageViewModel>> GetListImages(int productId);
        Task<ApiResult<bool>> CategoryAssign(int id, CategoryAssignRequest request);
        Task<List<ProductVm>> GetFeaturedProducts(string languageId, int take);
        Task< List<ProductVm>>GetLatestProducts(string languageId, int take);
    }
}
