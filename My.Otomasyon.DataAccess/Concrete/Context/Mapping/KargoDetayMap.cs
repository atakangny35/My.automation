using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using My.Otomasyon.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace My.Otomasyon.DataAccess.Concrete.Context.Mapping
{
    public class KargoDetayMap : IEntityTypeConfiguration<KargoDetay>
    {
        public void Configure(EntityTypeBuilder<KargoDetay> builder)
        {
            builder.HasKey(x => x.CargoDetailid);
            builder.Property(x => x.TrackNumber).IsRequired().HasMaxLength(12);

            
                
        }
    }
}
