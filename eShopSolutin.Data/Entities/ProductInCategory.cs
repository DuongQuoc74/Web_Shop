using System;
using System.Collections.Generic;
using System.Text;

namespace eShopsolutin.Data.Entities
{
    public class ProductInCategory // phần Loại sản phẩm
    {
        public int ProductId { get; set; }

        public Product Product { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }
    }
}
