using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using My.Otomasyon.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace My.Otomasyon.DataAccess.Concrete.Context.Mapping
{
    public class KargoTrackMap : IEntityTypeConfiguration<KargoTrack>
    {
        public void Configure(EntityTypeBuilder<KargoTrack> builder)
        {
            builder.HasKey(x => x.KargoDetailid);
            builder.Property(x => x.TrackNumber).HasMaxLength(12).IsRequired();

        }
    }
}
