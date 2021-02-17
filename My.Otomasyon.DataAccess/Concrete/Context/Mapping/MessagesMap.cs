using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using My.Otomasyon.Entities.Concrete;

namespace My.Otomasyon.DataAccess.Concrete.Context.Mapping
{
    public class MessagesMap : IEntityTypeConfiguration<Messages>
    {
        public void Configure(EntityTypeBuilder<Messages> builder)
        {
            builder.HasKey(x => x.MessageId);
            builder.Property(x => x.Sender).HasMaxLength(60).IsRequired();
            builder.Property(x => x.Receiver).HasMaxLength(60).IsRequired();
            builder.Property(x => x.Content).HasMaxLength(500);
        }
    }
}
