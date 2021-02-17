using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace My.Otomasyon.DTO.ProductDTO
{
   public class ProductAddViewModel
    {
        [StringLength(30)]
        [Display(Name ="Product name")]
        public string ProductName { get; set; }
        
        [StringLength(30)]
        [Display(Name = "Brand")]
        public string Marka { get; set; }
        [Required]
        public short Stok { get; set; }
        [Required]
        [Display(Name = "Buying price")]
        public decimal BuyingPrice { get; set; }
        [Required]
        public decimal SellingPrice { get; set; }
        [Display(Name = "Picture")]
        public string ProductPicture { get; set; }
        public string Condition { get; set; }
        public string Description { get; set; }
        //relations
        [Required]
        [Display(Name = "Category")]
        public int CategoryId { get; set; }
        


        
    }
}
