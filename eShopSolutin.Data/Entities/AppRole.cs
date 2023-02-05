using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShopsolution.Data.Entities
{
    public class AppRole : IdentityRole<Guid> // phần Vai trò
    {
        public string Description  { get; set; } //Mô tả
    }
}
