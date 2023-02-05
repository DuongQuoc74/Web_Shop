using System;
using System.Collections.Generic;
using System.Text;

namespace eShopsolutin.Data.Entities
{
    public class Language  // phần Ngôn ngữ
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public bool IsDefault { get; set; } //Mặc định

        public List<ProductTranslation> ProductTranslations { get; set; }

        public List<CategoryTranslation> CategoryTranslations { get; set; }
    }
}
