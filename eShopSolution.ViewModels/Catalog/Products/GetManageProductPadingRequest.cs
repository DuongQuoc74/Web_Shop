using eShopSolution.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.ViewModels.Catalog.Products
{
    public class GetManageProductPadingRequest : PadingRequestBase
    {
        public string LanguageId { get; set; }
        public string KeyWord { get; set; }
        public int? CategoryId { get; set; }
    }
}
