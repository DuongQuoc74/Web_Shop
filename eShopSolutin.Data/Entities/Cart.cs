using eShopSolution.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShopsolutin.Data.Entities
{
    public class Cart // phần Giỏ hàng
    {
        public int Id { set; get; }
        public int ProductId { set; get; } //id sản phẩm
        public int Quantity { set; get; } // số lượng
        public decimal Price { set; get; } // giá

        public Guid UserId { get; set; }

        public Product Product { get; set; }

        public DateTime DateCreated { get; set; }
        public AppUser AppUser { get; set; }   
    }
}
