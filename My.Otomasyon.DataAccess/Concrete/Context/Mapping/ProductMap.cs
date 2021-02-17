using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using My.Otomasyon.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace My.Otomasyon.DataAccess.Concrete.Context.Mapping
{
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(x => x.BuyingPrice).IsRequired();
            builder.Property(x => x.SellingPrice).IsRequired();
            builder.Property(x => x.Marka).HasColumnType("Varchar(30)").HasMaxLength(30);
            builder.HasOne(c => c.Category).WithMany(x => x.Products).HasForeignKey(i => i.CategoryId);
            builder.HasMany(x => x.SellingMoves).WithOne(x => x.Products).HasForeignKey(y => y.ProductId);




        }
    }
}
