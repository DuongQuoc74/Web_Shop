using eShopsolutin.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShopsolutin.Data.Entities
{
    public class Category // phần Loại
    {
        public int Id { get; set; }
        public int SortOder { get; set; } // sắp xếp Oder
        public bool IsShowOnHome { get; set; } // Hiển thị trong trang chủ 
        public int? ParenId { get; set; } // id gốc sp này
        public Status Status { get; set;} // trạng thái

        public List<ProductInCategory> ProductInCategories { get; set; }

        public List<CategoryTranslation> CategoryTranslations { get; set; }
    }
}
