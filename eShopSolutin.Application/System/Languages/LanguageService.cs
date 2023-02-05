using eShopsolutin.Data.Entities;
using eShopSolution.Data.EF;
using eShopSolution.ViewModels.Common;
using eShopSolution.ViewModels.System.Language;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ShopSolution.Data.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShpsolution.Application.System.Languages
{
    public class LanguageService : ILanguageService
    {
       
        private readonly EShopDbContext _context;
        public LanguageService(EShopDbContext context)
        {
            _context = context;
        }
        public async Task<ApiResult<List<LanguageVm>>> GetAll()
        {
            var languages = await _context.Languages.Select(x => new LanguageVm()
            {
               Id= x.Id,
               Name= x.Name,
            }).ToListAsync();
            return new ApiSuccessResult<List<LanguageVm>>(languages);
        }
    }
}
