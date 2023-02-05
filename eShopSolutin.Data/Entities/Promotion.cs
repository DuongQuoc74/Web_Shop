using eShopsolutin.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShopsolutin.Data.Entities
{
    public class Promotion//phần Khuyên mãi
    {
        public int Id { set; get; }
        public DateTime FromDate { set; get; }//từ ngày
        public DateTime ToDate { set; get; }//đến ngày
        public bool ApplyForAll { set; get; }//áp dụng cho tất cả
        public int? DiscountPercent { set; get; }//phần trăm giảm giá
        public decimal? DiscountAmount { set; get; } // số tiền chiết khấu
        public string ProductIds { set; get; }
        public string ProductCategoryIds { set; get; }
        public Status Status { set; get; }
        public string Name { set; get; }
    }
}
