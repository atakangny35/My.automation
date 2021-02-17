using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace My.Otomasyon.DTO.SellingMovesDTO
{
   public class SellingMovesUpdateViewModel
    {
        public int Id { get; set; }
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
