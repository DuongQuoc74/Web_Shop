using eShopSolution.ApiIntegration.Services;
using eShopSolution.ViewModels.Common;
using eShopSolution.ViewModels.System.Users;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace eShopSolution.AdminApp.Controllers
{
    public class UserController : BaseController
    {
        private readonly IUserApiClient _userApiClient;
        private readonly IRoleApiClient _roleApiClient;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UserController(IUserApiClient userApiClient, IConfiguration configuration,
            IHttpContextAccessor httpContextAccessor, IRoleApiClient roleApiClient)
        {
            _userApiClient = userApiClient;
            _roleApiClient = roleApiClient;
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<IActionResult>Index(string keyword, int pageIndex=1, int pageSize=5)
        {
            
            var request = new GetUserPadingRequest()
            {
              
                KeyWord = keyword,
                PageIndex = pageIndex,
                PageSize = pageSize
            };
            var data = await _userApiClient.GetUsersPagings(request);
            ViewBag.KeyWord = keyword;
            if (TempData["result"] != null)
            {
                ViewBag.SuccessMsg = TempData["result"];
            }
            return View(data.ResultObj);
        }

        

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(RegisterRequest request)
        {
            if (!ModelState.IsValid)
                return View();

            var result = await _userApiClient.RegisterUser(request);
            if(result.IsSuccessed)
            {
                TempData["result"] = "Tạo mới thành công.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", result.Message);
            return View(request);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var result = await _userApiClient.GetByIdUser(id);
            if (result.IsSuccessed)
            {
                var user = result.ResultObj;
                var updateRequest = new UserUpdateRequest()
                {
                    Dob = user.Dob,
                    Email = user.Email,
                    FirstName = user.FirstName,
                    Id = id,
                    LastName = user.LastName,
                    PhoneNumber = user.PhoneNumber,
                };

                return View(updateRequest);
            }
            return RedirectToAction("Error", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UserUpdateRequest request)
        {
            if (!ModelState.IsValid)
                return View();

            var result = await _userApiClient.UpdateUser(request.Id, request);
            if (result.IsSuccessed)
            {
                TempData["result"]="Chỉnh sửa thành công.";
                return RedirectToAction("Index");
            }    

            ModelState.AddModelError("", result.Message);
            return View(request);
        }

        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var result = await _userApiClient.GetByIdUser(id);
            return View(result.ResultObj);
        }

        [HttpGet]
        public IActionResult Delete (Guid id)
        {

            return View( new UserDeleteRequest()
            {
                Id=id,
            });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(UserDeleteRequest request)
        {
            if(!ModelState.IsValid)
                return View();
            var result = await _userApiClient.DeleteUser(request.Id);
            if(result.IsSuccessed)
            {
                TempData["result"]="Xóa thành công.";
                return RedirectToAction("Index");
            }    
            ModelState.AddModelError("",result.Message);
            return View(result);


        }

        [HttpGet]
        public async Task<IActionResult> RoleAssign(Guid id)
        {
            var roleAssignRequest = await GetRoleAssignRequest(id);
            return View(roleAssignRequest);
        }
        [HttpPost]
        public async Task <IActionResult> RoleAssign (RoleAssignRequest request)
        {
            if (!ModelState.IsValid)
                return View();
            var result = await _userApiClient.RoleAssign(request.Id, request);
            if(result.IsSuccessed)
            {
                TempData["result"] = "Gán quyền thành công";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", result.Message);
            var roleAssignRequest = await GetRoleAssignRequest(request.Id);
            return View(roleAssignRequest);
        }
        private async Task<RoleAssignRequest> GetRoleAssignRequest(Guid id)
        {
            var userObj =await _userApiClient.GetByIdUser(id);
            var roleObj = await _roleApiClient.GetAll();
            var roleAssignRequest = new RoleAssignRequest();
            foreach (var role in roleObj.ResultObj)
            {
                roleAssignRequest.Roles.Add(new SelectItem()
                {
                    Id = role.Id.ToString(),
                    Name = role.Name,
                    Selected = userObj.ResultObj.Roles.Contains(role.Name),

                });
            }
            return roleAssignRequest;
        }
        

    }
}
