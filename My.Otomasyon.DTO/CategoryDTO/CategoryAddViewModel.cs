using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace My.Otomasyon.DTO.CategoryDTO
{
   public class CategoryAddViewModel
    {
        [StringLength(30)]
        [Required]
        public string CategoryName { get; set; }
        
    }
}
