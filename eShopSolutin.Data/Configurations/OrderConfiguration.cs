using eShopsolutin.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShopsolution.Data.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).UseIdentityColumn(); // tạo cột nhận dạng tự động
            builder.Property(x => x.OrderDate);

            builder.Property(x => x.ShipEmail).IsRequired().IsUnicode(false).HasMaxLength(50);

            builder.Property(x => x.ShipAddress).IsRequired().HasMaxLength(200);//bắt phải nhập và có độ dài 200


            builder.Property(x => x.ShipName).IsRequired().HasMaxLength(200);


            builder.Property(x => x.ShipPhoneNumber).IsRequired().HasMaxLength(200);
        }
    }
}
