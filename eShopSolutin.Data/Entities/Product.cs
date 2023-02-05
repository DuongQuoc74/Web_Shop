using eShopsolution.Data.Entities;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShopsolutin.Data.Entities
{
    public class Product//phần Sản phẩm
    {
        public int Id { get; set; } 
        public decimal Price { get; set; }// giá
        public decimal OriginalPrice { get; set; }//giá Gốc
        public decimal Stock { get; set; } // tích trữ
        public int ViewCout { get; set; }// lượng xem
        public DateTime DateCreated { get; set; }// ngày tạo
        public bool? IsFeatured { set; get; }//đặc trưng, nỗi bật

        public List<ProductInCategory> ProductInCategories { get; set; }

        public List<OrderDetail> OrderDetails { get; set; }

        public List<Cart> Carts { get; set; }
       public List <ProductImage> ProductImages { set; get; } 

        public List<ProductTranslation> ProductTranslations { get; set; }

        
    }
}
