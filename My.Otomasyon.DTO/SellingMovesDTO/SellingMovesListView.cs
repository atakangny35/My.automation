using My.Otomasyon.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace My.Otomasyon.DTO.SellingMovesDTO
{
  public  class SellingMovesListView
    {   

        public int Id { get; set; }
        [Required]
        public int Adet { get; set; }
        [Required]
        public decimal Price { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime Date { get; set; } 
        public int ProductId { get; set; }
        public virtual Product Products { get; set; }
        public int AppUserId { get; set; }
        public virtual AppUser Cariler { get; set; }
    }
}
