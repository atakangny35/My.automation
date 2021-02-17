using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using My.Otomasyon.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace My.Otomasyon.DataAccess.Concrete.Context.Mapping
{
    public class BillsMap : IEntityTypeConfiguration<Bills>
    {
        public void Configure(EntityTypeBuilder<Bills> builder)
        {
            builder.HasMany(x => x.FaturaKalems).WithOne(x => x.Bills).HasForeignKey(c => c.BillsId);
            builder.Property(c => c.BillSeriNo).HasColumnType("Char").HasMaxLength(1);
        }
    }
}
