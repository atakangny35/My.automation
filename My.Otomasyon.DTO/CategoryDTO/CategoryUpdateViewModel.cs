using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace My.Otomasyon.DTO.CategoryDTO
{
   public class CategoryUpdateViewModel
    {
        public int Id { get; set; }
        [Required]
        public string CategoryName { get; set; }
    }
}
