using System;
using System.Collections.Generic;
using System.Text;

namespace eShopsolutin.Data.Entities
{
    public class OrderDetail//phần chi tiết đơn hàng
    {
        public int OrderId { set; get; }
        public int ProductId { set; get; }
        public int Quantity { set; get; }// số lượng
        public decimal Price { set; get; }// giá

        public Order Order { get; set; } // 1 thuộc tín trỏ đến order

        public Product Product { get; set; }
    }
}
