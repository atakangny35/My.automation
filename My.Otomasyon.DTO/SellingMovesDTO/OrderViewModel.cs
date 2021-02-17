using My.Otomasyon.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace My.Otomasyon.DTO.SellingMovesDTO
{
   public class OrderViewModel
    {
        public decimal Price { get; set; }
        public DateTime Date { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
