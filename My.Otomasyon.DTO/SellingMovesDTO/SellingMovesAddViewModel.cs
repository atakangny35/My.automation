using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace My.Otomasyon.DTO.SellingMovesDTO
{
   public class SellingMovesAddViewModel
    {
        [Required]
        public int Adet { get; set; }
        [Required]
        public decimal Price { get; set; }
       
        public DateTime Date { get; set; }
        [Required]
        public int ProductId { get; set; }

        [Required]
        public int AppUserId { get; set; }
       
    }
}
