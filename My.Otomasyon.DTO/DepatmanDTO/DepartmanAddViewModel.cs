using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace My.Otomasyon.DTO.DepatmanDTO
{
  public  class DepartmanAddViewModel
    {
        [Required]
        public string DepartmanAd { get; set; }
    }
}
