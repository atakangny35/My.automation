using My.Otomasyon.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace My.Otomasyon.Entities.Concrete
{
  public  class Product:Itable
    {
        public int Id { get; set; }
       
        [StringLength(30)]
        public string ProductName { get; set; }
        
        [StringLength(30)]
        public string Marka { get; set; }
        public short Stok { get; set; }
        public decimal BuyingPrice { get; set; }
        public decimal SellingPrice { get; set; }
        public bool LimitState { get; set; } = true;
        public string ProductPicture { get; set; }
        public string Condition { get; set; }
        public string Description { get; set; }
        //relations
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }


        public ICollection<SellingMoves> SellingMoves { get; set; }

    }
}
