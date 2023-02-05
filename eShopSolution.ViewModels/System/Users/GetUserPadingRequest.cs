using eShopSolution.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.ViewModels.System.Users
{
    public class GetUserPadingRequest : PadingRequestBase
    {
        public string KeyWord { get; set; }
    }
}
