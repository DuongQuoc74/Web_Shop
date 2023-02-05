using eShopsolutin.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShopsolution.Data.Configurations
{
    public class ProductInCategoryConfiguration : IEntityTypeConfiguration<ProductInCategory>
    {
        public void Configure(EntityTypeBuilder<ProductInCategory> builder)
        {  //tọa khóa ngoại quan hệ nhiều nhiều và config cả hả bên
           builder.HasKey(t => new {t.ProductId, t.CategoryId});
           builder.ToTable("ProductInCategories");
           builder.HasOne(t=> t.Product).WithMany(t=>t.ProductInCategories).HasForeignKey(t=>t.ProductId);
           builder.HasOne(t=> t.Category).WithMany(t=>t.ProductInCategories).HasForeignKey(t=>t.CategoryId);
        }
    }
}
