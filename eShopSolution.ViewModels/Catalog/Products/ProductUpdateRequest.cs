using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace eShopSolution.ViewModels.Catalog.Products
{
    public class ProductUpdateRequest
    {
        public int Id { get; set; }
        [Display(Name= "Tên Sản Phẩm")]
		[Required(ErrorMessage = "Bạn phải nhập!")]
		public string Name { set; get; }
        [Display(Name= "Mô tả")]
		[Required(ErrorMessage = "Bạn phải nhập!")]
		public string Description { set; get; }
        [Display(Name= "Chi Tiết")]
		[Required(ErrorMessage = "Bạn phải nhập!")]
		public string Details { set; get; }
		[Required(ErrorMessage = "Bạn phải nhập!")]
		public string SeoDescription { set; get; }
		[Required(ErrorMessage = "Bạn phải nhập!")]
		public string SeoTitle { set; get; }

        [Required(ErrorMessage ="Bạn phải nhập!")]
        public string SeoAlias { get; set; }
        public string LanguageId { set; get; }
		public bool? IsFeatured { set; get; }

		public IFormFile ThumbnailImage { set; get; }

    }
}
