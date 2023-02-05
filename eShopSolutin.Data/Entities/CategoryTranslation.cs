using System;
using System.Collections.Generic;
using System.Text;

namespace eShopsolutin.Data.Entities
{
    public class CategoryTranslation // phần dịch thuật loại danh mục
    {
        public int Id { set; get; }
        public int CategoryId { set; get; }
        public string Name { set; get; }
        public string SeoDescription { set; get; }// mô tả Seo.  "Seo là công cụ của marketing. giúp tối ưu hoá mấy từ khoá tìm kiếm của web "
        public string SeoTitle { set; get; }//tiêu đề Seo
        public string LanguageId { set; get; }
        public string SeoAlias { set; get; }// biệt danh Seo

        public Category Category { get; set; }

        public Language Language { get; set; }
    }
}
