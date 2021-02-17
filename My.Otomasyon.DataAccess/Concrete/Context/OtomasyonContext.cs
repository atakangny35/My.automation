using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using My.Otomasyon.DataAccess.Concrete.Context.Mapping;
using My.Otomasyon.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace My.Otomasyon.DataAccess.Concrete.Context
{
   public class OtomasyonContext:IdentityDbContext<AppUser,AppRole,int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=(localdb)\\mssqllocaldb; database=OtomasyonDb; Trusted_Connection=True; MultipleActiveResultSets=true");

            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ProductMap());
            builder.ApplyConfiguration(new AppUserMap());
            builder.ApplyConfiguration(new BillsMap());
            builder.ApplyConfiguration(new KargoDetayMap());
            builder.ApplyConfiguration(new KargoTrackMap());
            builder.ApplyConfiguration(new MessagesMap());



            base.OnModelCreating(builder);
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Bills> Bills { get; set; }
        public DbSet<Departman> Departmen { get; set; }
        public DbSet<FaturaKalem> FaturaKalems { get; set; }
        public DbSet<KargoDetay> KargoDetays { get; set; }
        public DbSet<KargoTrack> KargoTracks { get; set; }
        public DbSet<Messages> Messages { get; set; }
        public DbSet<SellingMoves> sellingMoves { get; set; }
        public DbSet<Stok> Stoks { get; set; }
    }
}
