using eShopSolution.ViewModels.Common;
using eShopSolution.ViewModels.System.Users;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace eShpsolution.Application.System.Users
{
    public interface IUserService
    {
        Task <ApiResult<string>> AuthencateAdmin(LoginRequest request);
        Task<ApiResult<string>> AuthencateUser(LoginRequest request);

        Task<ApiResult<bool>> Register(RegisterRequest request);
        Task<ApiResult<bool>> Update(Guid id, UserUpdateRequest request);
        Task<ApiResult<PagedResult<UserVm>>> GetUsersPading(GetUserPadingRequest request);  
        Task<ApiResult<UserVm>>GetUserById(Guid id);
        Task<ApiResult<bool>> Delete (Guid id);
        Task<ApiResult<bool>> RoleAssign(Guid id,RoleAssignRequest request);
    }
}
