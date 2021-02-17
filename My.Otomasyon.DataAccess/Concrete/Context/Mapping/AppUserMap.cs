using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using My.Otomasyon.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace My.Otomasyon.DataAccess.Concrete.Context.Mapping
{
    public class AppUserMap : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.Property(i => i.Name).HasMaxLength(100).IsRequired();
            builder.HasOne(x => x.Departman).WithMany(d => d.Perconels).HasForeignKey(x => x.DepartmanId);
            builder.HasMany(x => x.SellingMoves).WithOne(x => x.Cariler).HasForeignKey(y => y.AppUserId);

        }
    }
}
