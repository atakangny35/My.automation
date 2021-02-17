using My.Otomasyon.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace My.Otomasyon.Entities.Concrete
{
   public class Category:Itable
    {
        public int Id { get; set; }
        public bool LimitState { get; set; } = true;
        [StringLength(30)]
       
        public string CategoryName { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
