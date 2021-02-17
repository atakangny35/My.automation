using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace My.Otomasyon.DTO.CategoryDTO
{
  public  class CategoryListViewModel
    {
        [StringLength(30)]
        [Required]
        public string CategoryName { get; set; }
        public int Id { get; set; }

    }
}
