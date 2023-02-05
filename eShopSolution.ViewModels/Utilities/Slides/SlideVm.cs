using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.ViewModels.Utilities.Slides
{
    public class SlideVm
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public string Description { set; get; }// mô tả
        public string Url { set; get; } // đường dẫn

        public string Image { get; set; }//ảnh
        public int SortOrder { get; set; }
    }
}
