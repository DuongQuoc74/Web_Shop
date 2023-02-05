using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.ViewModels.Catalog.Products
{
    public class ProductVm
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public decimal OriginalPrice { get; set; }
        public decimal Stock { get; set; }
        public int ViewCout { get; set; }
        public DateTime DateCreated { get; set; }

        public string Name { set; get; }
        public string Description { set; get; }
        public string Details { set; get; }
        public string SeoDescription { set; get; }
        public string SeoTitle { set; get; }

        public string SeoAlias { get; set; }
        public string LanguageId { set; get; }
		public bool? IsFeatured { set; get; }
		public string ThumbnailImage { get; set; }

		public List<string> Categories { set; get; } = new List<string>();
    }
}
