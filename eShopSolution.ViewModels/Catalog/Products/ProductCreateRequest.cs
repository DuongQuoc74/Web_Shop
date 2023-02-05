using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace eShopSolution.ViewModels.Catalog.Products
{
    public class ProductCreateRequest
    {
        [Display(Name="Giá")]
        public decimal Price { get; set; }
        [Display(Name="Số lượng")]
        public int Stock { get; set; }
        [Display(Name=("Giá gốc"))]
        public decimal OriginalPrice { get; set; }
        [Display(Name="Tên Sp")]
        [Required(ErrorMessage ="Bạn phải nhập tên")]
        public string Name { set; get; }
        [Display(Name = "Mô tả")]
		[Required(ErrorMessage = "Bạn phải nhập ")]
		public string Description { set; get; }
        [Display(Name="Chi tiết")]
		[Required(ErrorMessage = "Bạn phải nhập")]
		public string Details { set; get; }
		[Required(ErrorMessage = "Bạn phải nhập")]
		public string SeoDescription { set; get; }
		[Required(ErrorMessage = "Bạn phải nhập")]
		public string SeoTitle { set; get; }
		[Required(ErrorMessage = "Bạn phải nhập")]
		public string SeoAlias { get; set; }
        public string LanguageId { set; get; }
		public bool? IsFeatured { set; get; }

		public IFormFile ThumbnailImage { get; set; }
    }
}
