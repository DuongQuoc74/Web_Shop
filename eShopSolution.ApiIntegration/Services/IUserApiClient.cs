using eShopSolution.ViewModels.Common;
using eShopSolution.ViewModels.System.Users;
using Microsoft.CodeAnalysis;
using System;
using System.Threading.Tasks;

namespace eShopSolution.ApiIntegration.Services
{
    public interface IUserApiClient
    {
        Task <ApiResult <string>> AuthenticateAdmin(LoginRequest request);
        Task<ApiResult<string>> AuthenticateUser(LoginRequest request);
        Task < ApiResult<PagedResult<UserVm>>> GetUsersPagings(GetUserPadingRequest request); 
        Task <ApiResult<bool>> RegisterUser (RegisterRequest request);
        Task <ApiResult<bool>> UpdateUser (Guid id, UserUpdateRequest request);
        Task<ApiResult<UserVm>> GetByIdUser (Guid id);
        Task<ApiResult<bool>> DeleteUser(Guid id);
        Task<ApiResult<bool>> RoleAssign(Guid id, RoleAssignRequest request);
        
    }
}
