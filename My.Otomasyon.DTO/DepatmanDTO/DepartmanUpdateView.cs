using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace My.Otomasyon.DTO.DepatmanDTO
{
   public  class DepartmanUpdateView
    {
        public int Id { get; set; }

        [StringLength(30)]
        public string DepartmanName { get; set; }
    }
}
