using My.Otomasyon.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace My.Otomasyon.Entities.Concrete
{
   public class SellingMoves:Itable
    {
        public int Id { get; set; }
        //ürün
        //cari
        //personel
        public int Adet { get; set; }
        public decimal Price { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime Date { get; set; } 

        public int ProductId { get; set; }
        public virtual Product Products { get; set; }

        public int AppUserId { get; set; }
        public virtual AppUser Cariler { get; set; }

        



    }
}
