using eShopSolution.ViewModels.System.Language;
using System.Collections.Generic;

namespace eShopSolution.AdminApp.Models
{
    public class NavigationViewModel
    {
        public List<LanguageVm> Laguages { get; set; }
        public string CurrenLangugeId { get; set; }
        public string ReturnUrl { get; set; } //load tại chỗ
    }
}
