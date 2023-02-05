using eShopsolutin.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShopsolution.Data.Entities
{
    public class ProductImage //phần Hình ảnh sản phẩm
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public string ImagePath { get; set; }//đường dẫn hình ảnh

        public string Caption { get; set; } // chú thích,tựa đề

        public bool IsDefault { get; set; }

        public DateTime DateCreated { get; set; }

        public int SortOrder { get; set; }

        public long FileSize { get; set; }
        public Product Product { get; set; }    
    }
}
