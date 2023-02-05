using eShopsolutin.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.Data.Entities
{
    public class Slide // phần Trang
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public string Description { set; get; }// mô tả
        public string Url { set; get; } // đường dẫn

        public string Image { get; set; }//ảnh
        public int SortOrder { get; set; } // thứ tự sắp xếp
        public Status Status { set; get; }
    }
}