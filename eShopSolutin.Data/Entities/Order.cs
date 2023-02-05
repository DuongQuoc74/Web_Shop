using eShopsolution.Data.Enums;
using eShopSolution.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShopsolutin.Data.Entities
{
    public class Order // phần Đơn hàng
    {
        public int Id { set; get; }
        public DateTime OrderDate { set; get; } // thời gian order
        public Guid UserId { set; get; }
        public string ShipName { set; get; } // tên giao hàng
        public string ShipAddress { set; get; } // địa chỉ giao hàng
        public string ShipEmail { set; get; }
        public string ShipPhoneNumber { set; get; }
        public OrderStatus Status { set; get; }

        public List<OrderDetail> OrderDetails { get; set; }
        public AppUser AppUser { set; get; }
    }
}
