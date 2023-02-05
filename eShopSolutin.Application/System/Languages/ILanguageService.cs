using eShopSolution.ViewModels.Common;
using eShopSolution.ViewModels.System.Language;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace eShpsolution.Application.System.Languages
{
    public interface ILanguageService
    {
        Task<ApiResult <List<LanguageVm>>> GetAll();
    }
}
