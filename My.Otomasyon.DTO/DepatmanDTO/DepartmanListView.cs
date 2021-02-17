using My.Otomasyon.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace My.Otomasyon.DTO.DepatmanDTO
{
   public class DepartmanListView
    {
        public int Id { get; set; }

        [StringLength(30)]
        [Required]
        public string DepartmanName { get; set; }
        
        public ICollection<AppUser> Perconels { get; set; }
    }
}
