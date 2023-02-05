using eShopsolutin.Data.Entities;
using eShopsolution.Data.Entities;
using eShopSolution.Data.EF;
using eShopSolution.ViewModels.System.Roles;
using FluentValidation.Resources;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShpsolution.Application.System.Roles
{
    
    public class RoleService : IRoleService
    {
        private readonly RoleManager<AppRole> _roleManager;
        
        public RoleService(RoleManager<AppRole> roleManager) {
            _roleManager= roleManager; 
        }
        
        public async Task<List<RoleVm>> GetAll()
        {
            var roles = await _roleManager.Roles.Select(x => new RoleVm()
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
            }).ToListAsync();
            return roles;
        }
    }
}
