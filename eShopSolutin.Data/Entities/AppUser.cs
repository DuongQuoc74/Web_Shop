using eShopsolutin.Data.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.Data.Entities
{
    public class AppUser : IdentityUser<Guid> // phần Người dùng
    {
        public string FirstName { get; set; } //Tên Đầu 

        public string LastName { get; set; } // Tên cuối

        public DateTime Dob { get; set; } // Sinh nhật khách hàng

        public List<Cart> Carts { get; set; } // giỏ hàng

        public List<Order> Orders { get; set; } // lệnh(mua)

        public List<Transaction> Transactions { get; set; } // giao dịch
    }
}