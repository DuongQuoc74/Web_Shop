using System;
using System.Collections.Generic;
using System.Text;

namespace eShopsolutin.Data.Entities
{
    public class ProductTranslation // dịch thuật sản phẩm
    {
        public int Id { get; set; }
        public int ProductId { set; get; }
        public string Name { set; get; }
        public string Description { set; get; }//mô tả
        public string Details { set; get; }// chi tiết
        public string SeoDescription { set; get; }//mô tả Seo.  "Seo là công cụ của marketing. giúp tối ưu hoá mấy từ khoá tìm kiếm của web
        public string SeoTitle { set; get; }

        public string SeoAlias { get; set; }
        public string LanguageId { set; get; }

        public Product Product { get; set; }

        public Language Language { get; set; }
    }
}
